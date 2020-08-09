using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace ImOrg
{
    public partial class Form1 : Form
    {
        // TODO: 
        // Add F key or menu toggle to add the new filename at the end of existing filename name or at the start

        #region Constants, globals
        /// <summary>
        /// A list of all viewable files in the selected directory. Key is full path, value is item class with originalFilename, newFilename etc. 
        /// </summary>
        private Dictionary<int, itemInfo> items = new Dictionary<int, itemInfo>();

        private bool isDebug = false;
        private bool isDebugDontMove = false;
        private string newFilenameTemp = "";
        private string previousNewFilenameTemp = "";
        private Color textColor = Color.White;
        private Color backgroundColor = Color.Black;
        private static List<string> logq = new List<string>();
        private int previouslySelectedItem = -1;
        private int videoSkipSeconds = 5;
        private class itemInfo
        {
            public string filename;
            public string fullpath;
            public string originalFullpath;
            public string newFilenameTemp;
            public string extension;
            public bool toRename;
            public itemType type;
        }
        private enum itemType
        {
           noExtension,
           directory,
           image,
           video,
           text,
           unsupported
        }
        #endregion

        #region utilities
        public void log(string in_)
        {
            richTextBox1.Text = $"{richTextBox1.Text}\n[{DateTime.Now.ToString("hhmmss")}] {in_}";

            if (isDebug)
                Console.WriteLine($"[{DateTime.Now.ToString("hhmmss.fff")}] {in_}");

        }
        public static bool WriteCsv(List<string> in_, string file)
        {
            var fileOut = new FileInfo(file);
            if (File.Exists(file))
                File.Delete(file);

            int i = -1;
            try
            {
                using (var csvStream = fileOut.OpenWrite())
                using (var csvWriter = new StreamWriter(csvStream))
                {
                    foreach (var a in in_)
                    {
                        csvStream.Position = csvStream.Length;
                        csvWriter.WriteLine(a);
                        i++;
                    }
                }
            }
            catch
            {
                return false;
            }

            return true;

        }
        #endregion
        public Form1()
        {
            InitializeComponent();

            GetDrivesList(); // check all available drives and display them

            SetAppColors();

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom; // best view mode

            richTextBox1.Hide(); // hide debug text window, only show when clicking on the status bar label

            // set default video jump seconds length
            // change videoSkipSeconds for the default value
            toolStripTextBox1.Text = "5";

            if (isDebug)
            {
                button_debug_rename.Show();
                log($"DEBUG: isDebug {isDebug}");
                treeView_folders.Nodes[3].Expand();
                treeView_folders.SelectedNode = treeView_folders.Nodes[3].Nodes[3]; // badev
            }
        }
        private void GetDrivesList()
        {
            // todo: change to a proper way to get the list of available drives instead of going A 0x41 to Z 0x58

            treeView_folders.BeginUpdate();

            for (int i = 0x41; i < 0x5B; i++) // A 0x41 to Z 0x58
            {
                var drive = (char)i;
                if (Directory.Exists($"{drive}:"))
                    treeView_folders.Nodes.Add($"{drive}:");
            }

            treeView_folders.EndUpdate();

            foreach (var node in treeView_folders.Nodes)
            {
                var currentNode = (TreeNode)node;

                var driveName = $"{currentNode.Text}";

                var folders = Directory.EnumerateDirectories($"{driveName}\\"); // weird bug here, if it has no backslash, it won't enumerate E but only E drive

                foreach (var folder in folders)
                {
                    var folder_ = new FileInfo(folder);
                    var folderName = folder_.Name;
                    currentNode.Nodes.Add(folderName);
                    // add an empty node for the extension button to appear (box with + sign) to expand the sub tree
                    currentNode.Nodes[currentNode.Nodes.Count - 1].Nodes.Add("");
                }
            }

        }
        private void SetAppColors()
        { 
            pictureBox1.BackColor = backgroundColor;
            listBox_files.BackColor = backgroundColor;
            listBox_files.ForeColor = textColor;
            treeView_folders.BackColor = backgroundColor;
            treeView_folders.ForeColor = textColor;
            this.BackColor = backgroundColor;
            this.ForeColor = textColor;
            ToolStrip.BackColor = Color.White;
            ToolStrip.ForeColor = Color.Black;
            richTextBox1.BackColor = backgroundColor;
            richTextBox1.ForeColor = textColor;

        }
        private void TreeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            // folder has been expanded, find all the folders in it
            var currentNode = e.Node;

            e.Node.Nodes.Clear();

            var fullPath = e.Node.FullPath;

            IEnumerable<string> folders = null;
            try
            {
                folders = Directory.EnumerateDirectories($"{fullPath}\\"); 
            }
            catch (Exception e_cannotReadFolder)
            {
                throw new Exception(e_cannotReadFolder.Message);
            }

            foreach (var folder_ in folders)
            {
                var folderInfo = new FileInfo(folder_);
                var folderName = folderInfo.Name;
                currentNode.Nodes.Add(folderName);
                // add an empty node for the extension button to appear (box with + sign) to expand the sub tree
                currentNode.Nodes[currentNode.Nodes.Count - 1].Nodes.Add("");

            }

            var s = (TreeView)sender;
        }
        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e) // a folder has been selected, scan for all supported files
        {
            listBox_files.Items.Clear();
            items.Clear();

            var files = Directory.EnumerateFiles($"{e.Node.FullPath}\\");
            var files2 = files.ToList();
            files2.Sort();
            files = files2;

            // add all files with supported extensions

            // add dropdown menu toggle to add files in order or by type
            // bad design, ended up with forcing the type order

            var items2 = new List<itemInfo>();

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                var ext = fileInfo.Extension;
                items2.Add(new itemInfo
                {
                    filename = fileInfo.Name,
                    fullpath = fileInfo.FullName,
                    originalFullpath = fileInfo.FullName,
                    newFilenameTemp = "",
                    toRename = false,
                    extension = ext,
                    type = getFileType(ext)
                });
            }

            // cool we can now add any kind of sorting here
            if (sortFilesByTypeToolStripMenuItem.Checked)
                items2 = items2.OrderBy(x => x.type).ToList();

            int i = 0;
            foreach (var a in items2)
            {
                if (!allowAnyFiletypeToolStripMenuItem.Checked)
                    if (!(a.type == itemType.image || a.type == itemType.video))
                        continue;

                items.Add(i, a);
                listBox_files.Items.Add(a.filename);
                i++;
            }

            if (isDebug)
                foreach (var a in items)
                    Console.WriteLine($"{a.Key} {a.Value.extension}");

        }
        private void ListBox_files_SelectedIndexChanged(object sender, EventArgs e) // click an image in the list
        {
            var currentFile = (ListBox)sender;
            if (currentFile.SelectedItem == null)
                return;

            if (currentFile.SelectedIndex == previouslySelectedItem)
                return;

            ToolStrip.Text = $"Name reset.";

            var fullPath = items[currentFile.SelectedIndex].fullpath;

            if (!File.Exists(fullPath))
            {
                ToolStrip.Text = $"ERROR: cannot find {fullPath}";
                return;
            }

            // verify if it's a video
            if (getFileType(new FileInfo(fullPath).Extension) == itemType.video)
            {
                loadVideo(fullPath);
                pictureBox1.Hide();
            }
            else
            {
                if (isVideoPlayerUnavailable() != true) // stop an already playing video
                {
                    unloadVideo();
                    pictureBox1.LoadAsync(fullPath);
                    pictureBox1.Show();
                }
            }

            // check if this should be placed after RenameFile(); or not
            previouslySelectedItem = currentFile.SelectedIndex;

            // let's try renaming the files here, after viewing a new item
            // nope, causes a temporary freeze when viewing videos
            // RenameFile();

            // try to scroll the files list further to see the next files
            // ...
            // can't find any method to increment scroll by one

        }
        private void ListBox_files_KeyDown(object sender, KeyEventArgs e) // press a key
        {
            if (listBox_files.SelectedItem == null)
                return;

            var oldFileName = listBox_files.SelectedItem.ToString();

            if (false) // debug
                if (e.KeyCode != Keys.ShiftKey)
                    ToolStrip.Text = $"{e.KeyCode},{e.KeyData},{e.KeyValue}";

            switch (e.KeyCode)
            {
                case Keys.Alt:
                case Keys.ShiftKey:
                case Keys.ControlKey:
                    break;

                case Keys.Left:
                    axWindowsMediaPlayer1.Ctlcontrols.currentPosition -= videoSkipSeconds;
                    e.Handled = true;
                    return;
                case Keys.Right:
                    axWindowsMediaPlayer1.Ctlcontrols.currentPosition += videoSkipSeconds;
                    e.Handled = true;
                    return;

                case Keys.Up:
                case Keys.Down:
                case Keys.Enter:
                    if (!allowUPDOWNToRenameToolStripMenuItem.Checked)
                    {
                        ToolStrip.Text = $"Name reset.";
                        return;
                    }

                    var selectedIndex = listBox_files.SelectedIndex; // assuming we don't remove entries, it will always work

                    if (listBox_files.Items.Count != items.Count)
                        throw new Exception("badev");

                    if (items[selectedIndex].newFilenameTemp != "")
                        break;

                    items[selectedIndex].newFilenameTemp = newFilenameTemp;
                    items[selectedIndex].toRename = true;

                    previousNewFilenameTemp = newFilenameTemp;
                    newFilenameTemp = "";

                    break;

                case Keys.Escape:
                    newFilenameTemp = "";
                    ToolStrip.Text = $"Name reset."; // maybe use to undo
                    return;

                #region numbers and signs
                case Keys.D0: newFilenameTemp = $"{newFilenameTemp}0"; break;
                case Keys.D1: newFilenameTemp = $"{newFilenameTemp}1"; break;
                case Keys.D2: newFilenameTemp = $"{newFilenameTemp}2"; break;
                case Keys.D3: newFilenameTemp = $"{newFilenameTemp}3"; break;
                case Keys.D4: newFilenameTemp = $"{newFilenameTemp}4"; break;
                case Keys.D5: newFilenameTemp = $"{newFilenameTemp}5"; break;
                case Keys.D6: newFilenameTemp = $"{newFilenameTemp}6"; break;
                case Keys.D7: newFilenameTemp = $"{newFilenameTemp}7"; break;
                case Keys.D8: newFilenameTemp = $"{newFilenameTemp}8"; break;
                case Keys.D9: newFilenameTemp = $"{newFilenameTemp}9"; break;
                case Keys.NumPad0: newFilenameTemp = $"{newFilenameTemp}0"; break;
                case Keys.NumPad1: newFilenameTemp = $"{newFilenameTemp}1"; break;
                case Keys.NumPad2: newFilenameTemp = $"{newFilenameTemp}2"; break;
                case Keys.NumPad3: newFilenameTemp = $"{newFilenameTemp}3"; break;
                case Keys.NumPad4: newFilenameTemp = $"{newFilenameTemp}4"; break;
                case Keys.NumPad5: newFilenameTemp = $"{newFilenameTemp}5"; break;
                case Keys.NumPad6: newFilenameTemp = $"{newFilenameTemp}6"; break;
                case Keys.NumPad7: newFilenameTemp = $"{newFilenameTemp}7"; break;
                case Keys.NumPad8: newFilenameTemp = $"{newFilenameTemp}8"; break;
                case Keys.NumPad9: newFilenameTemp = $"{newFilenameTemp}9"; break;
                case Keys.Add: newFilenameTemp = $"{newFilenameTemp}+"; break;
                case Keys.Space: newFilenameTemp = $"{newFilenameTemp} "; break;
                case Keys.OemMinus: newFilenameTemp = $"{newFilenameTemp}_"; break;
                case Keys.Subtract: newFilenameTemp = $"{newFilenameTemp}-"; break;
                #endregion

                #region letters
                case Keys.A:
                case Keys.B:
                case Keys.C:
                case Keys.D:
                case Keys.E:
                case Keys.F:
                case Keys.G:
                case Keys.H:
                case Keys.I:
                case Keys.J:
                case Keys.K:
                case Keys.L:
                case Keys.M:
                case Keys.N:
                case Keys.O:
                case Keys.P:
                case Keys.Q:
                case Keys.R:
                case Keys.S:
                case Keys.T:
                case Keys.U:
                case Keys.V:
                case Keys.W:
                case Keys.X:
                case Keys.Y:
                case Keys.Z:
                    if (e.Shift)
                        newFilenameTemp = $"{newFilenameTemp}{e.KeyCode}";
                    else
                        newFilenameTemp = $"{newFilenameTemp}{e.KeyCode.ToString().ToLower()}";
                    break;
                #endregion

                case Keys.Back:
                    if (newFilenameTemp != "")
                        newFilenameTemp = newFilenameTemp.Remove(newFilenameTemp.Length - 1, 1);
                    break;

                // press this key to use the last used filename
                case Keys.F1:
                    // use the last renamed file as template
                    // maybe change key or let the user customize it
                    newFilenameTemp = previousNewFilenameTemp;
                    ToolStrip.Text = $"Reusing: {previousNewFilenameTemp}"; // maybe use to undo
                    return;

                case Keys.F11: // resize video
                    resizeVideo();
                    return;

                case Keys.F12: // resize image
                    var a = (int)pictureBox1.SizeMode;
                    if (a + 1 == availablePictureModes.Count)
                        a = -1;

                    pictureBox1.SizeMode = availablePictureModes[a + 1];

                    pictureBox1.ClientSize = new Size(
                        richTextBox1.Size.Width,
                        richTextBox1.Size.Height);

                    ToolStrip.Text = $"Picture scaling: {pictureBox1.SizeMode}";
                    return;

                default:
                    break;
            }

            ToolStrip.Text = $"New name: {newFilenameTemp}";

        }
        private void ListBox_files_KeyPress(object sender, KeyPressEventArgs e)
        {
            // prevent name change keys to seek filename in the list
            e.Handled = true; 

        }
        private void RGBTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            // prevent text color from being the same as background color
            if (colorDialog1.Color == backgroundColor)
                return;
            textColor = colorDialog1.Color;

            SetAppColors();

        }
        private void RGBBackgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            backgroundColor = colorDialog1.Color;

            SetAppColors();

        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            if(!isDebug)
                RenameFile();
        }
        private bool RenameFile()
        {
            // wait what about moving directories
            for (int i = 0; i < items.Count; i++)
            { 
                var item = items[i];

                // skip files that don't need to be renamed
                if (item.toRename == false)
                    continue;

                // skip files if new name was failed to be set
                if (item.newFilenameTemp == "")
                    continue;

                // // ignore the currently playing video for now as it causes a temporary freezing
                if (!canRenameVideo(item.fullpath))
                    continue;

                if (isDebug)
                {
                    Console.WriteLine($"");
                    Console.WriteLine($"Processing:" +
                        $"\nitem        {i}" +
                        $"\ntoRename    {item.toRename}" +
                        $"\noldFullpath {item.fullpath}" +
                        $"\noldFilename {item.filename}" +
                        $"\nnewNameTemp {item.newFilenameTemp}" +
                        $"\n");
                }

                var oldFullpath = item.fullpath;
                var newFullpath = "";
                var newTempFilename = item.newFilenameTemp;

                if (!new FileInfo(oldFullpath).Exists)
                {
                    log($"RenameOrMoveItems(): error: file doesn't exists." +
                        $"prevFileName = {oldFullpath};");
                    return false;
                }

                var ogFileInfo = new FileInfo(oldFullpath);
                newFullpath = $"{ogFileInfo.Directory}\\{item.newFilenameTemp}{ogFileInfo.Extension}";

                if (newNameMovesToFolderToolStripMenuItem.Checked)
                {
                    newTempFilename = $"\\{item.newFilenameTemp}\\{item.filename}";
                    newFullpath = $"{ogFileInfo.Directory}\\{item.newFilenameTemp}\\{item.filename}";

                    if (!Directory.Exists($"{ogFileInfo.Directory}\\{item.newFilenameTemp}"))
                        Directory.CreateDirectory($"{ogFileInfo.Directory}\\{item.newFilenameTemp}");

                }

                // rename file if a file already exists with the same name. a fast enough computer might fail on miliseconds aswel (fff)
                // with every rename, add 2 more characters for the date formatting
                // considering the user wouldn't rename a lot of files before the rename timer ticks, it shouldn't even get to milisecond renaming
                var format = "";
                var format2 = "yyyyMMddhhmmssffff"; // year month day hour minute second milisecond
                var k = -1;
                while (File.Exists(newFullpath))
                {
                    k++;
                    format = format2.Substring(0, 4 + k * 2);
                    newFullpath = $"" +
                        $"{ogFileInfo.Directory}\\" +
                        $"{newTempFilename}_" +
                        $"{DateTime.Now.ToString(format)}{ogFileInfo.Extension}";

                    if (newNameMovesToFolderToolStripMenuItem.Checked)
                    {
                        newFullpath = $"{ogFileInfo.Directory}" +
                            $"\\{item.newFilenameTemp}" +
                            $"\\{item.filename.Substring(0, item.filename.Length - ogFileInfo.Extension.Length)}" +
                            $"_{DateTime.Now.ToString(format)}" +
                            $"{ogFileInfo.Extension}";
                    }

                    // absolute worst case scenario, if for some reason all the files already exist
                    if (k > 10000)
                        continue;
                }

                if (!isDebugDontMove)
                {
                    try
                    {
                        File.Move(oldFullpath, newFullpath); // TODO move filename error handling here }
                    }
                    catch
                    {
                        ToolStrip.Text = $"ERROR: failed to rename {oldFullpath} to {newFullpath}";
                        continue;
                    }
                }

                log($"Renamed {oldFullpath} to {newFullpath}");
                ToolStrip.Text = $"Renamed {oldFullpath} to {newFullpath}";

                item.fullpath = newFullpath;
                item.filename = newFullpath.Split("\\".ToCharArray()).Last();
                item.newFilenameTemp = "";

                if (item.toRename == true)
                    listBox_files.Items[i] = item.filename;

                item.toRename = false;

                if (isDebug)
                {
                    Console.WriteLine($"");
                    Console.WriteLine($"Processed :" +
                        $"\nitem        {i}" +
                        $"\ntoRename    {item.toRename}" +
                        $"\noldFullpath {item.fullpath}" +
                        $"\noldFilename {item.filename}" +
                        $"\nnewNameTemp {item.newFilenameTemp}" +
                        $"\n");
                }

            }

            return true;

        } 
        private void Button1_Click(object sender, EventArgs e)
        {
            RenameFile();
        }
        private void ToolStrip_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Visible)
                richTextBox1.Hide();
            else
                richTextBox1.Show();
        }
        private bool showDefaultImage(string oldFilename, string newFilename) // keep old code
        {
            // need to show a different image since the currently viewed item is being read
            Assembly myAssembly = Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("ImOrg.Bitmap1.bmp");
            Bitmap bmp = new Bitmap(myStream);

            pictureBox1.Image = bmp;

            return true;
        }
        private itemType getFileType(string extension)
        {
            switch (extension)
            {
                case "":
                    return itemType.noExtension;

                case ".jpg":
                case ".jpeg":
                case ".png":
                case ".gif":
                case ".tif":
                case ".tiff":
                case ".bmp":
                case ".ico":
                    // ".webp", // not supported
                    // ".dds", // not supported
                    // ".tga", // not supported
                    return itemType.image;

                case ".webm":
                case ".mp4":
                case ".mkv":
                    return itemType.video;

                case ".txt":
                case ".csv":
                case ".log":
                case ".xml":
                    // ".flv", // definitely not supported
                    return itemType.text;

                default:
                    return itemType.unsupported;
            }
        }
        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var dialogBox = new Form();
            dialogBox.Text = "Info";
            dialogBox.BackColor = backgroundColor;
            dialogBox.ForeColor = textColor;
            var label = new Label();
            label.AutoSize = true;
            label.Font = new Font("Consolas", 10.25F, FontStyle.Regular, GraphicsUnit.Point);
            label.Text =
                "Shortcuts list:" +
                "\nESC : cancel last new name." +
                "\nF1  : use the last typed name." +
                "\nF11 : change video view mode" +
                "\nF12 : change image view mode" +
                "\n" +
                "";

            label.ForeColor = textColor;
            label.Location = new Point { X = 10, Y = 10 };
            dialogBox.Controls.Add(label);

            dialogBox.ShowDialog();

        }
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (isDebug)
                Console.WriteLine($"Size changed: {this.Size.Width}x{this.Size.Height}");
        }
        private List<PictureBoxSizeMode> availablePictureModes = new List<PictureBoxSizeMode> {
            PictureBoxSizeMode.AutoSize,
            PictureBoxSizeMode.CenterImage,
            PictureBoxSizeMode.Normal,
            PictureBoxSizeMode.StretchImage,
            PictureBoxSizeMode.Zoom
        };
        #region AxWMPLib video player controls
        private void resizeVideo()
        {
            if (axWindowsMediaPlayer1.stretchToFit)
                axWindowsMediaPlayer1.stretchToFit = false;
            else
                axWindowsMediaPlayer1.stretchToFit = true;
            ToolStrip.Text = $"Video stretch to fit: {axWindowsMediaPlayer1.stretchToFit}";
        }
        private void AxWindowsMediaPlayer1_StatusChange(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsReady)
            {
                try
                {
                    axWindowsMediaPlayer1.Ctlcontrols.play();
                }
                catch { }
            }

        }
        private void loadVideo(string fullPath)
        {
            axWindowsMediaPlayer1.URL = fullPath;
            axWindowsMediaPlayer1.Show();
        }
        private void unloadVideo()
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            axWindowsMediaPlayer1.Hide();
        }
        private bool isVideoPlayerUnavailable()
        {
            return axWindowsMediaPlayer1.Ctlcontrols == null;
        }
        private bool canRenameVideo(string path)
        {
            if (axWindowsMediaPlayer1.currentMedia != null)
                if (axWindowsMediaPlayer1.currentMedia.sourceURL == path && axWindowsMediaPlayer1.playState != WMPLib.WMPPlayState.wmppsStopped)
                    return false;

            return true;
        }
        #endregion
        #region testing FFMPEG
        public Process ffplay = new Process();

        [DllImport("user32.dll")]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        private void TestFfmpegToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();

            ffplay.StartInfo.FileName = "ffplay.exe";
            ffplay.StartInfo.Arguments = $"-left 0 -top 0 -noborder -fs {listBox_files.SelectedItem.ToString()}";
            ffplay.StartInfo.CreateNoWindow = true;
            ffplay.StartInfo.RedirectStandardOutput = true;
            ffplay.StartInfo.UseShellExecute = false;
            ffplay.Start();
            Thread.Sleep(500);

            SetParent(ffplay.MainWindowHandle, pictureBox1.Handle); // attempt failed to stick it to the program main window

            axWindowsMediaPlayer1.Ctlcontrols.stop();
            axWindowsMediaPlayer1.Hide();

            log($"TestFfmpegToolStripMenuItem_Click(): args: {sender.ToString()}, {e.ToString()}; playing a video using ffmpeg.");
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ffplay.SynchronizingObject == null)
                return;

            if (!ffplay.HasExited)
                ffplay.Kill();

            log($"Form1_FormClosing(): args: {sender.ToString()}, {e.ToString()}; kill ffmpeg first before closing.");
        }
        #endregion

        private void ToolStripTextBox1_textChanged(object sender, EventArgs e)
        {
            int.TryParse(toolStripTextBox1.Text, System.Globalization.NumberStyles.Integer, null, out videoSkipSeconds);
        }
    }

}
