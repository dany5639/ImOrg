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
        #region Constants, globals
        private string newFilenameTemp = "";
        private static List<string> logq = new List<string>();
        private bool isVideo = false;
        private Color textColor = Color.White;
        private Color backgroundColor = Color.Black;
        private Dictionary<string, string> renameHistory = new Dictionary<string, string>();
        private static bool isDebug = false;
        private List<string> supportedImageExtensions = new List<string>
        {
            ".jpg",
            ".jpeg",
            ".png",
            ".gif",
            ".tif",
            ".tiff",
            ".bmp",
            ".ico",
            // ".webp", // not supported
            // ".dds", // not supported
            // ".tga", // not supported
        };
        private List<string> supportedVideoExtensions = new List<string>
        {
            ".webm",
            ".mp4",
            ".mkv", 
            // ".flv", // definitely not supported
        };
        #endregion

        #region utilities
        public static void log(string in_)
        {
            if (isDebug)
            {
                logq.Add(in_);
                WriteCsv(logq, "debug.log");
            }
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
            // when attempting to rename an image, the image loader still has it locked and can't seem to unlock it until opening another image
            // can't select next image in the filelist either as it tries to edit the images list while it's being edited

#if debug
            isDebug  = true;
#endif

            InitializeComponent();
            log("Form1:InitializeComponent() executed.");

            GetDrivesList(); // check all available drives and display them
            log("Form1:GetDrivesList() executed.");

            SetAppColors();
            log("Form1:SetAppColors() executed.");

            axWindowsMediaPlayer1.Hide(); // image viewer prioritizes
            log("Form1:axWindowsMediaPlayer1.Hide() executed.");

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom; // best view mode

            allowUPDOWNToRenameToolStripMenuItem.Checked = true;

            log($"DEBUG: isDebug {isDebug}");

            if (isDebug)
            {
                allowAnyFiletypeToolStripMenuItem.Checked = true;
                newNameMovesToFolderToolStripMenuItem.Checked = false;
                autorenameDuplicatesToolStripMenuItem.CheckState = CheckState.Checked;
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

            log("SetAppColors() executed.");
        }
        private bool RenameFile(string oldFileName, string newFileName)
        {
            if (!File.Exists(oldFileName))
                throw new Exception($"ERROR: file does not exist: {oldFileName}");

            var a = listBox_files.SelectedItem;
            var b = listBox_files.SelectedIndex;

            newFileName = updateFilepath(oldFileName, newFileName);// some issue with backslash

            if (oldFileName == newFileName)
                return true;

            if (File.Exists(newFileName))
            {
                if (autorenameDuplicatesToolStripMenuItem.Checked)
                {
                    while (true)
                    {
                        if (File.Exists(newFileName))
                        {
                            var a1 = new FileInfo(newFileName);
                            var a2 = $"{a1.Directory}\\{a1.Name.Substring(0, a1.Name.Length - a1.Extension.Length)}_{DateTime.Now.ToString("hhmmss")}{a1.Extension}";
                            newFileName = a2;
                        }
                        else goto rename;
                    }
                }
                ToolStrip.Text = $"File already exists: {new FileInfo(newFilenameTemp).Name}";
                return false;
            }

            rename:

            // need to show a different image since the currently viewed item is being read
            Assembly myAssembly = Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("ImOrg.Bitmap1.bmp");
            Bitmap bmp = new Bitmap(myStream);

            pictureBox1.Image = bmp;

            if (oldFileName.Length > 248)
            {
                ToolStrip.Text = $"ERROR: filename too long: {oldFileName}";
                return false;
            }
            if (newFileName.Length > 248) // this is just wrong; needs to check filename length separately from directory length
            {
                ToolStrip.Text = $"ERROR: filename too long: {newFileName}";
                return false;
            }

            axWindowsMediaPlayer1.Ctlcontrols.stop();
            axWindowsMediaPlayer1.Hide();
            // axWindowsMediaPlayer1.URL = listBox_files.Items[0].ToString();

            Thread.Sleep(100); // something is wrong here. no line, fails to move because file is in use. add sleep 1000, moves fine. set sleep 0, still moves fine

            File.Move(oldFileName, newFileName); // fails to move if the image was opened earlier

            if (renameHistory.ContainsKey(oldFileName))
                renameHistory[oldFileName] = newFileName;
            else
                renameHistory.Add(oldFileName, newFileName);

            listBox_files.SelectedIndex = b;
            listBox_files.SelectedItem = listBox_files.Items[b];
            listBox_files.Items[b] = newFileName; // System.Windows.Forms.ListBox.SelectedItem.get returned null.

            if (!File.Exists(newFileName))
            {
                ToolStrip.Text = $"Failed to rename {new FileInfo(oldFileName).Name}. IsReadOnly: {new FileInfo(newFileName).IsReadOnly}";
                return false;
            }

            ToolStrip.Text = $"Renamed {new FileInfo(oldFileName).Name} to {new FileInfo(newFileName).Name}";

            log($"RenameFile(): Renamed {new FileInfo(oldFileName).Name} to {new FileInfo(newFileName).Name}");
            return true;
        }
        private bool MoveItem(string oldFileName, string newFileName)
        {
            // todo: add folder handling

            if (!File.Exists(oldFileName))
                throw new Exception($"ERROR: file does not exist: {oldFileName}");

            if (File.Exists(newFileName))
            {
                ToolStrip.Text = $"File already exists: {new FileInfo(newFilenameTemp).Name}";
                return false;
            }

            newFileName = MoveItemToFolder(oldFileName, newFileName);
            if (newFileName == null)
            {
                ToolStrip.Text = $"Failed to rename {new FileInfo(oldFileName).Name}. IsReadOnly: {new FileInfo(newFileName).IsReadOnly}";
                return false;
            }

            if (oldFileName.Length > 248)
            {
                ToolStrip.Text = $"ERROR: filename too long: {oldFileName}";
                return false;
            }
            if (newFileName.Length > 248) // this is just wrong; needs to check filename length separately from directory length
            {
                ToolStrip.Text = $"ERROR: filename too long: {newFileName}";
                return false;
            }

            var a = listBox_files.SelectedItem;
            var b = listBox_files.SelectedIndex;

            if (File.Exists(newFileName))
            {
                ToolStrip.Text = $"ERROR: File already exists: {newFileName}";
                return false;
            }

            File.Move(oldFileName, newFileName); // fails to move if the image was opened earlier

            if (!File.Exists(newFileName))
            {
                ToolStrip.Text = $"Failed to rename {new FileInfo(oldFileName).Name}. IsReadOnly: {new FileInfo(newFileName).IsReadOnly}";
                return false;
            }

            if (renameHistory.ContainsKey(oldFileName))
                renameHistory[oldFileName] = newFileName;
            else
                renameHistory.Add(oldFileName, newFileName);

            listBox_files.SelectedIndex = b;
            listBox_files.SelectedItem = listBox_files.Items[b];
            listBox_files.Items[b] = newFileName; // System.Windows.Forms.ListBox.SelectedItem.get returned null.

            ToolStrip.Text = $"Moved {new FileInfo(oldFileName).Name} to {new FileInfo(newFileName).Name}";

            log($"MoveItem(): Moved {new FileInfo(oldFileName).Name} to {new FileInfo(newFileName).Name}");

            return true;
        }
        private string MoveItemToFolder(string oldFileName, string newFileName)
        {
            var a = new FileInfo(oldFileName);
            var b = $"{a.Directory}\\{newFileName}";

            if (!Directory.Exists(b))
                if (!Directory.CreateDirectory(b).Exists)
                    return null;

            var c = $"{b}\\{a.Name}";

            log($"MoveItemToFolder(): returns {c}");

            return c;
        }
        private bool RevertRenameFile(string oldFileName, string newFileName) // to implement
        {
            if (!File.Exists(oldFileName))
                throw new Exception($"ERROR: file does not exist: {oldFileName}");

            if (File.Exists(newFileName))
            {
                ToolStrip.Text = $"File already exists: {new FileInfo(newFilenameTemp).Name}";
                return false;
            }

            var a = listBox_files.SelectedItem;
            var b = listBox_files.SelectedIndex;

            newFileName = updateFilepath(oldFileName, newFileName);// some issue with backslash

            // need to show a different image since the currently viewed image is locked
            // useless?
            if (!isVideo)
            {
                Assembly myAssembly = Assembly.GetExecutingAssembly();
                Stream myStream = myAssembly.GetManifestResourceStream("ImOrg.Bitmap1.bmp");
                Bitmap bmp = new Bitmap(myStream);

                pictureBox1.Image = bmp;
            }

            if (oldFileName.Length > 248)
            {
                ToolStrip.Text = $"ERROR: filename too long: {oldFileName}";
                return false;
            }
            if (newFileName.Length > 248) // this is just wrong; needs to check filename length separately from directory length
            {
                ToolStrip.Text = $"ERROR: filename too long: {newFileName}";
                return false;
            }

            File.Move(oldFileName, newFileName); // fails to move if the image was opened earlier
            renameHistory.Add(oldFileName, newFileName);

            listBox_files.SelectedIndex = b;
            listBox_files.SelectedItem = listBox_files.Items[b];
            listBox_files.Items[b] = newFileName; // System.Windows.Forms.ListBox.SelectedItem.get returned null.

            if (!File.Exists(newFileName))
            {
                ToolStrip.Text = $"Failed to rename {new FileInfo(oldFileName).Name}. IsReadOnly: {new FileInfo(newFileName).IsReadOnly}";
                return false;
            }

            ToolStrip.Text = $"RevertRenameFile {new FileInfo(oldFileName).Name} to {new FileInfo(newFileName).Name}";
            log($"RevertRenameFile {new FileInfo(oldFileName).Name} to {new FileInfo(newFileName).Name}");
            return true;
        }
        private string updateFilepath(string _old, string newFilename)
        {
            // modifiy original filename based on user input
            var file = new FileInfo(_old);
            var ext = file.Extension;
            var dir = file.Directory;
            var out_ = "";
            if (dir.Name.Contains("\\"))
                out_ = $"{dir}{newFilename}{ext}";
            else
                out_ = $"{dir}\\{newFilename}{ext}";

            log($"updateFilepath(): args: {_old}, {newFilename}; return: {out_}");
            return out_;
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

            log($"TreeView1_BeforeExpand(): args: {sender.ToString()}, {e.Node.Name}");
        }
        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // a folder has been selected, scan for all supported files
            listBox_files.Items.Clear();

            var files = Directory.EnumerateFiles($"{e.Node.FullPath}\\");

            // add all files with supported extensions
            var supportedFiles = new List<string>();
            foreach (var file in files)
            {
                var ext = new FileInfo(file).Extension;

                if (allowAnyFiletypeToolStripMenuItem.Checked)
                    supportedFiles.Add(file);
                else
                    if (supportedVideoExtensions.Contains(ext) || supportedImageExtensions.Contains(ext))
                        supportedFiles.Add(file);
            }

            foreach (var file in supportedFiles)
                listBox_files.Items.Add(file);

            log($"TreeView1_AfterSelect(): args: {sender.ToString()}, {e.Node.Name}");

        }
        private void ListBox_files_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if user clicks another file, clear the previous file's temp name
            newFilenameTemp = "";
            ToolStrip.Text = $"Name reset.";

            // a different filename was selected, read it and display
            var currentFile = (ListBox)sender;
            if (currentFile.SelectedItem == null)
                return;

            var currentFilePath = currentFile.SelectedItem.ToString();
            if (!File.Exists(currentFilePath))
            {
                ToolStrip.Text = $"ERROR: cannot find {currentFilePath}";
                return;
            }

            // verify if it's a video
            if (supportedVideoExtensions.Contains(new FileInfo(currentFilePath).Extension))
            {
                axWindowsMediaPlayer1.Show();
                axWindowsMediaPlayer1.URL = currentFilePath;
                axWindowsMediaPlayer1.Ctlcontrols.play();
                isVideo = true;
            }
            else
            {
                // stop an already playing video
                axWindowsMediaPlayer1.Ctlcontrols.stop();
                axWindowsMediaPlayer1.Hide();
                pictureBox1.LoadAsync(currentFilePath);
                isVideo = false;
            }

            log($"ListBox_files_SelectedIndexChanged(): args: {sender.ToString()}, {e.ToString()}");
        }
        private void ListBox_files_KeyDown(object sender, KeyEventArgs e)
        {
            // TODO: add support for more keys

            if (listBox_files.SelectedItem == null)
                return;

            var oldFileName = listBox_files.SelectedItem.ToString();
            var add = "";

            if (false) // debug
                if (e.KeyCode != Keys.ShiftKey)
                    ToolStrip.Text = $"{e.KeyCode},{e.KeyData},{e.KeyValue}";

            switch (e.KeyCode)
            {
                case Keys.Back:
                    if (newFilenameTemp != "")
                        newFilenameTemp = newFilenameTemp.Substring(0, newFilenameTemp.Length - 1);
                    break;

                case Keys.Up:
                case Keys.Down:
                    if (!allowUPDOWNToRenameToolStripMenuItem.Checked)
                    {
                        ToolStrip.Text = $"Name reset.";
                        return;
                    }
                    if (newFilenameTemp == "")
                        return;
                    if (newNameMovesToFolderToolStripMenuItem.Checked)
                    {
                        if (MoveItem(oldFileName, newFilenameTemp))
                            newFilenameTemp = "";
                        return;
                    }
                    if (RenameFile(oldFileName, newFilenameTemp))
                        newFilenameTemp = "";
                    return;

                case Keys.Enter:
                    if (newFilenameTemp == "")
                        return;
                    if (newNameMovesToFolderToolStripMenuItem.Checked)
                    {
                        if (MoveItem(oldFileName, newFilenameTemp))
                            newFilenameTemp = "";
                        return;
                    }
                    if (RenameFile(oldFileName, newFilenameTemp))
                        newFilenameTemp = "";
                    return;

                case Keys.Escape:
                    newFilenameTemp = "";
                    ToolStrip.Text = $"Name reset.";
                    return;

#region numbers and signs
                case Keys.D0: add = "0"; break;
                case Keys.D1: add = "1"; break;
                case Keys.D2: add = "2"; break;
                case Keys.D3: add = "3"; break;
                case Keys.D4: add = "4"; break;
                case Keys.D5: add = "5"; break;
                case Keys.D6: add = "6"; break;
                case Keys.D7: add = "7"; break;
                case Keys.D8: add = "8"; break;
                case Keys.D9: add = "9"; break;
                case Keys.Add: add = "+"; break;
                case Keys.Space: add = " "; break;
                case Keys.OemMinus: add = "_"; break;
                case Keys.Subtract: add = "-"; break;
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
                        add = $"{e.KeyCode}";
                    else
                        add = $"{e.KeyCode.ToString().ToLower()}";
                    break;
#endregion
                
                //case Keys.F12:
                //    var resolution = Screen.PrimaryScreen.Bounds;
                //    if (isFullscreen)
                //    {
                //        isFullscreen = false;
                //        pictureBox1.Width = resolution.Width;
                //        pictureBox1.Height = resolution.Height;
                //    }
                //    else
                //    {
                //        isFullscreen = true;
                //        pictureBox1.Width = resolution.Width;
                //        pictureBox1.Height = resolution.Height;
                //    }
                //    break;

                default:
                    break;
            }

            newFilenameTemp = $"{newFilenameTemp}{add}";

            ToolStrip.Text = $"New name: {newFilenameTemp}";

            log($"ListBox_files_SelectedIndexChanged(): args: {sender.ToString()}, {e.ToString()}; {newFilenameTemp}");

        }
        private void ListBox_files_KeyPress(object sender, KeyPressEventArgs e)
        {
            // prevent name change keys to seek filename in the list
            e.Handled = true; 
        }
        private void AxWindowsMediaPlayer1_StatusChange(object sender, EventArgs e)
        {
            // auto play for webm's. would crash as it's async
            // also this function runs excessively often
            try
            {
                if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsStopped)
                {
                    axWindowsMediaPlayer1.Ctlcontrols.stop();
                    axWindowsMediaPlayer1.Hide();
                    axWindowsMediaPlayer1.URL = "";

                }

                if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsTransitioning)
                {
                    axWindowsMediaPlayer1.Ctlcontrols.play();
                    return;
                }

                if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
                    return;

                if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsReady)
                {
                    axWindowsMediaPlayer1.Ctlcontrols.play();
                    return;
                }


            }
            catch
            {

            }

            log($"AxWindowsMediaPlayer1_StatusChange(): args: {sender.ToString()}, {e.ToString()}");

        }
        private void RGBTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            // prevent text color from being the same as background color
            if (colorDialog1.Color == backgroundColor)
                return;
            textColor = colorDialog1.Color;

            SetAppColors();

            log($"RGBTextToolStripMenuItem_Click(): args: {sender.ToString()}, {e.ToString()}; {textColor:X8}");

        }
        private void RGBBackgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            backgroundColor = colorDialog1.Color;

            SetAppColors();

            log($"RGBTextToolStripMenuItem_Click(): args: {sender.ToString()}, {e.ToString()}; {backgroundColor:X8}");
        }
        private void ZoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Refresh();

            log($"ZoomToolStripMenuItem_Click(): args: {sender.ToString()}, {e.ToString()}");
        }
        private void NormalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
            pictureBox1.Refresh();

            log($"NormalToolStripMenuItem_Click(): args: {sender.ToString()}, {e.ToString()}");
        }
        private void AutoSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.Refresh();

            log($"AutoSizeToolStripMenuItem_Click(): args: {sender.ToString()}, {e.ToString()}");
        }
        private void CenterImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.Refresh();

            log($"CenterImageToolStripMenuItem_Click(): args: {sender.ToString()}, {e.ToString()}");
        }
        private void StretchImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Refresh();

            log($"StretchImageToolStripMenuItem_Click(): args: {sender.ToString()}, {e.ToString()}");
        }
        private void AxWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {
            listBox_files.Focus();

            log($"AxWindowsMediaPlayer1_Enter(): args: {sender.ToString()}, {e.ToString()}; attempt to focus ffmpeg window.");
        }
        private void PictureBox1_Click(object sender, EventArgs e)
        {
            // listBox_files.Focus();
            // if (listBox_files.Items.Count > 0)
            //     listBox_files.SelectedIndex = 0;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ffplay.SynchronizingObject == null)
                return;

            if (!ffplay.HasExited)
                ffplay.Kill();

            log($"Form1_FormClosing(): args: {sender.ToString()}, {e.ToString()}; kill ffmpeg first before closing.");
        }

#region testing FFMPEG
        public Process ffplay = new Process();

        [DllImport("user32.dll")]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        private void TestFfmpegToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
#endregion

    }

}
