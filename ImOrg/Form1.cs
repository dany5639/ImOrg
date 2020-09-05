﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
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
        /// <summary>
        /// A list of all viewable files in the selected directory. Key is full path, value is item class with originalFilename, newFilename etc. 
        /// </summary>
        private Dictionary<int, itemInfo> items = new Dictionary<int, itemInfo>();

        private bool isDebug = false;
        private string nf = "";
        private string previousNewFilenameTemp = "";
        private Color textColor = Color.White;
        private Color backgroundColor = Color.Black;
        private int previouslySelectedItem = -1;
        private int videoSkipSeconds = 5;
        private string fullPath = "";
        private string oldFullpath = "";
        private string newFullpath = "";
        private List<int> indexesToName = new List<int>();

        private class itemInfo
        {
            public string filename;
            public string fullpath;
            public string originalFullpath;
            public string newFilenameTemp;
            public string extension;
            public string filenameWithoutExtension;
            public bool toRename;
            public bool relativePath;
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
        private enum renamingMode
        {
            move,
            replace,
            start,
            end,
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
        private List<PictureBoxSizeMode> availablePictureModes = new List<PictureBoxSizeMode> {
            PictureBoxSizeMode.AutoSize,
            PictureBoxSizeMode.CenterImage,
            PictureBoxSizeMode.Normal,
            PictureBoxSizeMode.StretchImage,
            PictureBoxSizeMode.Zoom
        };
        #endregion

        #region utilities
        public void log(string in_)
        {
            if (!isDebug)
                return;

            var date = DateTime.Now.ToString("hhmmss:fff");

            Console.WriteLine($"[{date}] {in_}");

        }
        public void log_ts(string in_)
        {
            var date = DateTime.Now.ToString("hhmmss:fff");

            ToolStrip.Text = $"Renamed {oldFullpath} to {newFullpath}";

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

        #region Theme related
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

        }
        #endregion

        #region Main and main window
        public Form1()
        {
            InitializeComponent();

            // using this to allow the user to scroll trough the file list containing videos without loading every video causing severe stuttering and a massive memory leak
            // WMP library has a massive memory leak when opening videos successively rapidely, is significantly reduced when letting a video play for 5-10 seconds before opening a new one
            // unable to create a thread specifically for WMP to destroy to avoid this memory leak


            Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            DateTime buildDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddSeconds(version.Revision * 2);
            string displayableVersion = $"{version} ({buildDate})";

            ToolStrip.Text = $"Version: {displayableVersion}";

            GetDrivesList(); // check all available drives and display them

            SetAppColors();

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom; // best view mode

            // set default video jump seconds length
            // change videoSkipSeconds for the default value
            toolStripTextBox_videoSkipLength.Text = "5";

            toolStripComboBox_renamingMode.SelectedIndex = 1;

            initializeTimers();

#if DEBUG
            isDebug = true;

            log($"DEBUG: isDebug {isDebug}");

            for (int i = 0; i < treeView_folders.Nodes.Count; i++)
            {
                log($"Found Disk: {treeView_folders.Nodes[i].Text.ToString()}");
                if (treeView_folders.Nodes[i].Text.ToString() != "R:")
                    continue;

                treeView_folders.SelectedNode = treeView_folders.Nodes[i];
                treeView_folders.SelectedNode.Expand();

                // ok well this suddenly doesn't work anymore, great
                for (int j = 0; j < treeView_folders.Nodes.Count; j++)
                {
                    log($"Found directory: {treeView_folders.Nodes[i].Nodes[j].Text.ToString()}");
                    if (treeView_folders.Nodes[i].Nodes[j].Text.ToString() != "UNSORTED_SFW")
                        continue;

                    // treeView_folders.SelectedNode = treeView_folders.Nodes[i].Nodes[j];
                    var a = treeView_folders.SelectedNode.Nodes[j].Nodes[0];
                    return;
                }

                return;
            }

#endif

        }
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            log($"Size changed: {this.Size.Width}x{this.Size.Height}");
        }
        #endregion

        #region unused
        private bool showDefaultImage(string oldFilename, string newFilename) // keep old code
        {
            // need to show a different image since the currently viewed item is being read
            Assembly myAssembly = Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("ImOrg.Bitmap1.bmp");
            Bitmap bmp = new Bitmap(myStream);

            pictureBox1.Image = bmp;

            return true;
        }
        #endregion

        #region Disks and directories related
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

        }
        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e) // a folder has been selected, scan for all supported files
        {
            indexesToName.Clear();
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
                var filenameWithoutExtension = $"{fileInfo.Name.Substring(0, fileInfo.Name.Length - fileInfo.Extension.Length)}";
                items2.Add(new itemInfo
                {
                    filename = fileInfo.Name,
                    fullpath = fileInfo.FullName,
                    originalFullpath = fileInfo.FullName,
                    newFilenameTemp = "",
                    toRename = false,
                    extension = ext,
                    filenameWithoutExtension = filenameWithoutExtension,
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

        }
        #endregion
       
        #region keys related
        private void ListBox_files_KeyDown(object sender, KeyEventArgs e) // press a key
        {
            if (listBox_files.SelectedItem == null)
                return;

            var oldFileName = listBox_files.SelectedItem.ToString();

            // if (false) // debug
            //     if (e.KeyCode != Keys.ShiftKey)
            //         ToolStrip.Text = $"{e.KeyCode},{e.KeyData},{e.KeyValue}";

            switch (e.KeyCode)
            {
                case Keys.Left:
                    SetForegroundWindow((int)ffplay.MainWindowHandle);
                    e.Handled = true;
                    timer_refocusMain.Start();
                    return;
                case Keys.Right:
                    SetForegroundWindow((int)ffplay.MainWindowHandle);
                    e.Handled = true;
                    timer_refocusMain.Start();
                    return;
                default:
                    break;
            }

            switch (e.KeyCode)
            {
                case Keys.Alt:
                case Keys.ShiftKey:
                case Keys.ControlKey:
                    break;

                case Keys.Up:
                case Keys.Down:
                    if (!allowUPDOWNToRenameToolStripMenuItem.Checked)
                    {
                        ToolStrip.Text = $"Name reset.";
                        return;
                    }
                    goto keysEnter;
                case Keys.Enter:
                    keysEnter:
                    var selectedIndex = listBox_files.SelectedIndex; // assuming we don't remove entries, it will always work

                    if (listBox_files.Items.Count != items.Count)
                        throw new Exception("badev");

                    if (items[selectedIndex].newFilenameTemp != "")
                        break;

                    items[selectedIndex].newFilenameTemp = nf;
                    items[selectedIndex].toRename = true;

                    if (nf != "")
                        previousNewFilenameTemp = nf;

                    if (nf == "")
                        break;

                    ToolStrip.Text = $"Renaming queued: {oldFileName} to {nf}";

                    nf = "";

                    if (indexesToName.Contains(selectedIndex))
                        return;

                    indexesToName.Add(selectedIndex);

                    return;

                case Keys.Escape:
                    nf = "";
                    ToolStrip.Text = $"Name reset."; // maybe use to undo
                    return;

                #region numbers and signs
                case Keys.OemMinus: nf = $"{nf}_"; break;
                case Keys.Subtract: nf = $"{nf}-"; break;
                case Keys.NumPad0: nf = $"{nf}0"; break;
                case Keys.NumPad1: nf = $"{nf}1"; break;
                case Keys.NumPad2: nf = $"{nf}2"; break;
                case Keys.NumPad3: nf = $"{nf}3"; break;
                case Keys.NumPad4: nf = $"{nf}4"; break;
                case Keys.NumPad5: nf = $"{nf}5"; break;
                case Keys.NumPad6: nf = $"{nf}6"; break;
                case Keys.NumPad7: nf = $"{nf}7"; break;
                case Keys.NumPad8: nf = $"{nf}8"; break;
                case Keys.NumPad9: nf = $"{nf}9"; break;
                case Keys.Space: nf = $"{nf} "; break;
                case Keys.Add: nf = $"{nf}+"; break;
                case Keys.D0: nf = $"{nf}0"; break;
                case Keys.D1: nf = $"{nf}1"; break;
                case Keys.D2: nf = $"{nf}2"; break;
                case Keys.D3: nf = $"{nf}3"; break;
                case Keys.D4: nf = $"{nf}4"; break;
                case Keys.D5: nf = $"{nf}5"; break;
                case Keys.D6: nf = $"{nf}6"; break;
                case Keys.D7: nf = $"{nf}7"; break;
                case Keys.D8: nf = $"{nf}8"; break;
                case Keys.D9: nf = $"{nf}9"; break;
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
                        nf = $"{nf}{e.KeyCode}";
                    else
                        nf = $"{nf}{e.KeyCode.ToString().ToLower()}";
                    break;
                #endregion

                case Keys.Back:
                    if (nf != "")
                        nf = nf.Remove(nf.Length - 1, 1);
                    break;

                // press this key to use the last used filename
                case Keys.F1:
                    // use the last renamed file as template
                    // maybe change key or let the user customize it
                    nf = previousNewFilenameTemp;
                    if (nf != "")
                        ToolStrip.Text = $"Reusing: {nf}"; // maybe use to undo
                    return;

                case Keys.F2: // change renaming mode
                    var np = toolStripComboBox_renamingMode.SelectedIndex;
                    if (np == toolStripComboBox_renamingMode.Items.Count - 1)
                        np = -1;

                    np = np + 1;
                    toolStripComboBox_renamingMode.SelectedIndex = np;
                    ToolStrip.Text = $"Renaming mode: {(renamingMode)toolStripComboBox_renamingMode.SelectedIndex}";
                    return;

                case Keys.F11:
                    return;

                case Keys.F12: // resize image
                    // well this completely broke out of nowhere
                    var a = (int)pictureBox1.SizeMode;
                    if (a + 1 == availablePictureModes.Count)
                        a = -1;

                    pictureBox1.SizeMode = availablePictureModes[a + 1];

                    ToolStrip.Text = $"Picture scaling: {pictureBox1.SizeMode}";
                    return;

                default:
                    break;
            }

            if (nf != "")
                ToolStrip.Text = $"New name: {nf}";

        }
        private void ListBox_files_KeyPress(object sender, KeyPressEventArgs e)
        {
            // prevent name change keys to seek filename in the list
            e.Handled = true;

        }
        #endregion

        #region Toolstrip
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
                "\nF2  : change renaming mode." +
                "\nF12 : change image view mode" +
                "\n" +
                "";

            label.ForeColor = textColor;
            label.Location = new Point { X = 10, Y = 10 };
            dialogBox.Controls.Add(label);

            dialogBox.ShowDialog();

        }
        private void ToolStripTextBox1_textChanged(object sender, EventArgs e)
        {
            int.TryParse(toolStripTextBox_videoSkipLength.Text, System.Globalization.NumberStyles.Integer, null, out videoSkipSeconds);
        }
        #endregion

        #region Move File
        private void managePreviousItems()
        {
            var processedIndexes = new List<int>();
            log($"managePreviousItems(): indexesToName {indexesToName.Count}");

            foreach (var i in indexesToName)
            {
                // wait what about moving directories
                var item = items[i];

                // skip files that don't need to be renamed
                if (item.toRename == false)
                    return; // shouldn't happen

                // skip files if new name was failed to be set
                if (item.newFilenameTemp == "")
                    return;

                oldFullpath = item.fullpath;

                if (!new FileInfo(oldFullpath).Exists)
                {
                    log($"RenameOrMoveItems(): error: file doesn't exists. prevFileName = {oldFullpath};");
                    return;
                }

                var ogFileInfo = new FileInfo(oldFullpath);
                var ogFileInfoDirectory = ogFileInfo.Directory.ToString();
                var filenameWithoutExtension = item.filenameWithoutExtension;

                log($"newFullpath before {oldFullpath}");

                switch ((renamingMode)toolStripComboBox_renamingMode.SelectedIndex)
                {
                    case renamingMode.move:
                        ogFileInfoDirectory = $"{ogFileInfoDirectory}\\{item.newFilenameTemp}";

                        if (!Directory.Exists($"{ogFileInfoDirectory}\\{item.newFilenameTemp}"))
                            Directory.CreateDirectory($"{ogFileInfoDirectory}\\{item.newFilenameTemp}");

                        item.newFilenameTemp = ogFileInfo.Name.Substring(0, ogFileInfo.Name.Length - ogFileInfo.Extension.Length);
                        newFullpath = $"{ogFileInfoDirectory}\\{item.newFilenameTemp}";
                        item.relativePath = true;
                        break;

                    case renamingMode.replace:
                        newFullpath = $"{ogFileInfoDirectory}\\{item.newFilenameTemp}";
                        break;

                    case renamingMode.start:
                        newFullpath = $"{ogFileInfoDirectory}\\{item.newFilenameTemp} {filenameWithoutExtension}";
                        break;

                    case renamingMode.end:
                        newFullpath = $"{ogFileInfoDirectory}\\{filenameWithoutExtension} {item.newFilenameTemp}";
                        break;

                    default:
                        throw new Exception("New name position: Index out of bounds");

                }

                log($"newFullpath after  {newFullpath}");

                // rename by adding the standard windows method: (?)
                if (File.Exists($"{newFullpath}{ogFileInfo.Extension}"))
                {
                    var k = -1;
                    var newFullpath2 = newFullpath;
                    if (newFullpath.Last() != ")".ToCharArray()[0])
                    {
                        while (File.Exists($"{newFullpath}{ogFileInfo.Extension}"))
                        {
                            k++;
                            newFullpath = $"{newFullpath2} ({k})";
                        }
                        goto done1;
                    }

                    var a = newFullpath.LastIndexOf("(".ToCharArray()[0]);
                    var value = newFullpath.Substring(a + 1, newFullpath.Length - a - 2);
                    int.TryParse(value, NumberStyles.Integer, null, out int lastInt);
                    while (File.Exists($"{newFullpath}{ogFileInfo.Extension}"))
                    {
                        k++;
                        newFullpath = $"{newFullpath2} ({k})";
                    }
                }

                done1:

                newFullpath = $"{newFullpath}{ogFileInfo.Extension}";

                log($"newFullpath after2 {newFullpath}");

                if (item.relativePath)
                {
                    log($"File.Move start");
                    File.Move(oldFullpath, newFullpath);
                    log($"File.Move start");
                }
                else
                {
                    // MoveItemAbsolute();
                    var filename = new FileInfo(newFullpath).Name;
                    if (!File.Exists(filename))
                    {
                        try
                        {
                            Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(oldFullpath, filename);
                        }
                        catch
                        {
                            log_ts($"Failed: RenameFile(): {oldFullpath} to {newFullpath}");
                        }
                    }
                }

                // a last check
                if (!File.Exists(newFullpath))
                {
                    log_ts($"Failed to rename {oldFullpath} to {newFullpath}: new file doesn't exist.");
                    continue;
                }

                item.fullpath = newFullpath;
                item.filename = newFullpath.Split("\\".ToCharArray()).Last();
                item.newFilenameTemp = "";
                item.toRename = false;
                item.relativePath = false;

                listBox_files.Items[i] = item.filename;

                log_ts($"Renamed {oldFullpath} to {newFullpath}");

                processedIndexes.Add(i);

            }

            // remove all indexes that were processed
            var indexesToNameTemp = new List<int>();
            foreach (var i in indexesToName)
                if (!processedIndexes.Contains(i))
                    indexesToNameTemp.Add(i);

            indexesToName.Clear();
            foreach (var i in indexesToNameTemp)
                indexesToName.Add(i);

        }
        private void FileMove()
        { 
        }
        private void MoveItemAbsolute()
        {
            var threadStart = new ThreadStart(FileMove);
            var thread = new Thread(threadStart);
            thread.Start();
        }
        #endregion

        #region Timers
        #endregion

        private void ListBox_files_SelectedIndexChanged(object sender, EventArgs e) // click an image in the list
        {
            var currentFile = (ListBox)sender;
            if (currentFile.SelectedItem == null)
                return;

            // don't do anything if the selected file didn't change incase the user clicked outside and needs to click back to rename it
            if (currentFile.SelectedIndex == previouslySelectedItem)
                return;

            fullPath = items[currentFile.SelectedIndex].fullpath;

            if (!File.Exists(fullPath))
            {
                ToolStrip.Text = $"ERROR: cannot find {fullPath}";
                return;
            }

            if (getFileType(new FileInfo(fullPath).Extension) == itemType.video)
            {
                ffplay_loadVideo();
            }
            else
            {
                // if (previouslySelectedItem != -1)
                //     if (items[previouslySelectedItem].type == itemType.video)
                        ffplay_kill(); // kill only if the player is up

                pictureBox1.LoadAsync(fullPath);

            }

            // check if this should be placed after RenameFile(); or not
            previouslySelectedItem = currentFile.SelectedIndex;

            // try to scroll the files list further to see the next files
            // ...
            // can't find any method to increment scroll by one

            // might require multithread or timers
            managePreviousItems();

        }

        #region FFPLAY DLL
        [DllImport("user32.dll")]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
        [DllImport("user32.dll")]
        public static extern int SetForegroundWindow(int hwnd);
        #endregion

        #region FFPLAY
        public Process ffplay = new Process();
        private void ffplay_setInfo()
        {
            ffplay.StartInfo.FileName = "ffplay.exe";

            // no idea why 8 and 30, maybe title bar + borders

            ffplay.StartInfo.Arguments = $"" +
                $"-left {pictureBox1.Location.X + this.Location.X + 8} " +
                $"-top {pictureBox1.Location.Y + this.Location.Y + 30} " +
                $"-x {pictureBox1.Width} " +
                $"-y {pictureBox1.Height} " +
                $"-noborder " +
                $"-volume 0 " +
                $"\"{fullPath}\"" +
                $"";

            ffplay.StartInfo.CreateNoWindow = true;
            ffplay.StartInfo.RedirectStandardInput = false;
            ffplay.StartInfo.RedirectStandardOutput = false;
            ffplay.StartInfo.UseShellExecute = false;

        }
        private void ffplay_startThread()
        {
            ffplay.Start();
        }
        private void ffplay_Thread()
        {
            var threadStart = new ThreadStart(ffplay_startThread);
            var thread = new Thread(threadStart);
            thread.Start();
        }
        private void initializeTimers()
        {
            timer_startSetParent.Interval = 100; // ms time between opening ffplay and attempting to attach it to the main window. range: 400-700
            timer_spamParent.Interval = 8; // ms time between each attempt to attach it to the main window; 16 is every frame

            timer_startSetParent.Stop();
            timer_spamParent.Stop();

            timer_refocusMain.Stop();
            timer_refocusMain.Interval = 800;
        }
        private void Timer_startSetParent_Tick(object sender, EventArgs e)
        {
            log($"Timer_startSetParent_Tick");
            ffplay_attachVideo();
        }
        private void Timer_spamParent_Tick(object sender, EventArgs e)
        {
            // log($"Timer_spamParent_Tick");

            // this is quite ugly, i need a way to find out that the ffplay window has spawned, and not spam a function to attach it every specified tick
            // ffplay.WaitForInputIdle(500); // try this

            try { var a = ffplay.MainModule; }
            catch
            {
                log($"ffplay_attachVideo(): ffplay is invalid.");
                timer_startSetParent.Stop();
                timer_spamParent.Stop();
                return;
            }

            if ((int)ffplay.MainWindowHandle != 0) // window handle will change once the video starts, somehow
            {
                log($"ffplay_attachVideo(): SetParent");
                SetParent(ffplay.MainWindowHandle, pictureBox1.Handle);
                timer_startSetParent.Stop();
                timer_spamParent.Stop();
                moveVideoWindow();
            }

            SetForegroundWindow((int)this.Handle);

        }
        private void moveVideoWindow()
        {
            MoveWindow(ffplay.MainWindowHandle, 0, 0, pictureBox1.Width, pictureBox1.Height, true);
        }
        private void ffplay_attachVideo()
        {
            timer_spamParent.Start();
            log("ffplay_attachVideo(): timer_spamParent.Start()");

            timer_startSetParent.Stop();
            log("ffplay_attachVideo(): timer_startSetParent.Stop()");
        }
        private void ffplay_kill()
        {
            // needs a different way as it would kill any ffplay instances or fail to kill the one created by this program
            log("ffplay_kill");
            try { ffplay.Kill(); }
            catch { }

            log("timer_startSetParent");
            timer_startSetParent.Stop();
        }
        private void ffplay_loadVideo()
        {
            timer_refocusMain.Stop();
            timer_spamParent.Stop();
            timer_startSetParent.Stop();
            

            log("ffplay_loadVideo(): ffplay_kill()");
            ffplay_kill(); // don't allow other instances for now, as i can't kill the already existing instance

            log("ffplay_loadVideo(): ffmpeg_setInfo()");
            ffplay_setInfo();

            log("ffplay_loadVideo(): ffmpeg_startThread()");
            ffplay_Thread();

            timer_startSetParent.Start();
            log("ffplay_loadVideo(): timer_startSetParent.Start()");
        }
        private void PictureBox1_Resize(object sender, EventArgs e)
        {
            log($"PictureBox1_Resize {pictureBox1.Width}x{pictureBox1.Height}");
            ffplay_loadVideo();
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            log("ffplay_kill");
            ffplay_kill();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            log("ffplay_kill");
            ffplay_kill();
        }
        private void Timer_refocusMain_Tick(object sender, EventArgs e)
        {
            // this is so janky i hate it
            // need a way to control ffplay without focusing its window, like a process.sendCommand()
            SetForegroundWindow((int)this.Handle);
            timer_refocusMain.Stop();
        }
        private void PictureBox1_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {

        }
        private void PictureBox1_ParentChanged(object sender, EventArgs e)
        {

        }
        #endregion

        // current major problems:
        // when moving to a folder, 2 folders are made instead of just one
        // when scrolling immediately after a video starts playing, the video window can fail to attach

    }

}