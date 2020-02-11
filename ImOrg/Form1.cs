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
        private string newFilenameTemp = "";
        private static List<string> logq = new List<string>();
        private bool isVideo = false;
        private Color textColor = Color.White;
        private Color backgroundColor = Color.Black;
        private Dictionary<string, string> renameHistory = new Dictionary<string, string>();

        public static void log(string in_)
        {
            logq.Add(in_);
        }
        private static List<string> ReadCsv(string filename)
        {
            var output = new List<string>();

            using (var reader = new StreamReader(filename))
            {
                var line = "";
                while (line != null)
                {
                    line = reader.ReadLine();
                    output.Add(line);
                }

                if (output.Last() == null)
                    output.RemoveAt(output.Count - 1);
            }

            return output;
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

        public Form1()
        {
            // when attempting to rename an image, the image loader still has it locked and can't seem to unlock it until opening another image
            // can't select next image in the filelist either as it tries to edit the images list while it's being edited

            InitializeComponent();

            GetDrivesList(); // check all available drives and display them

            SetAppColors();

            axWindowsMediaPlayer1.Hide(); // image viewer prioritizes

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom; // best view mode

            allowUPDOWNToRenameToolStripMenuItem.Checked = true;

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
        private void Button_RGBappBackground_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            backgroundColor = colorDialog1.Color;

            SetAppColors();

        }
        private void Button_RGBtext_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            textColor = colorDialog1.Color;

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
            allowAnyFiletypeToolStripMenuItem2.BackColor = Color.White;
            allowAnyFiletypeToolStripMenuItem2.ForeColor = Color.Black;

        }
        private bool RenameFile(string oldFileName, string newFileName)
        {
            if (!File.Exists(oldFileName))
                throw new Exception($"ERROR: file does not exist: {oldFileName}");

            if (File.Exists(newFileName))
            {
                allowAnyFiletypeToolStripMenuItem2.Text = $"File already exists: {new FileInfo(newFilenameTemp).Name}";
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
                allowAnyFiletypeToolStripMenuItem2.Text = $"ERROR: filename too long: {oldFileName}";
                return false;
            }
            if (newFileName.Length > 248) // this is just wrong; needs to check filename length separately from directory length
            {
                allowAnyFiletypeToolStripMenuItem2.Text = $"ERROR: filename too long: {newFileName}";
                return false;
            }

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
                allowAnyFiletypeToolStripMenuItem2.Text = $"Failed to rename {new FileInfo(oldFileName).Name}. IsReadOnly: {new FileInfo(newFileName).IsReadOnly}";
                return false;
            }

            allowAnyFiletypeToolStripMenuItem2.Text = $"Renamed {new FileInfo(oldFileName).Name} to {new FileInfo(newFileName).Name}";
            return true;
        }
        private bool RevertRenameFile(string oldFileName, string newFileName)
        {
            if (!File.Exists(oldFileName))
                throw new Exception($"ERROR: file does not exist: {oldFileName}");

            if (File.Exists(newFileName))
            {
                allowAnyFiletypeToolStripMenuItem2.Text = $"File already exists: {new FileInfo(newFilenameTemp).Name}";
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
                allowAnyFiletypeToolStripMenuItem2.Text = $"ERROR: filename too long: {oldFileName}";
                return false;
            }
            if (newFileName.Length > 248) // this is just wrong; needs to check filename length separately from directory length
            {
                allowAnyFiletypeToolStripMenuItem2.Text = $"ERROR: filename too long: {newFileName}";
                return false;
            }

            File.Move(oldFileName, newFileName); // fails to move if the image was opened earlier
            renameHistory.Add(oldFileName, newFileName);

            listBox_files.SelectedIndex = b;
            listBox_files.SelectedItem = listBox_files.Items[b];
            listBox_files.Items[b] = newFileName; // System.Windows.Forms.ListBox.SelectedItem.get returned null.

            if (!File.Exists(newFileName))
            {
                allowAnyFiletypeToolStripMenuItem2.Text = $"Failed to rename {new FileInfo(oldFileName).Name}. IsReadOnly: {new FileInfo(newFileName).IsReadOnly}";
                return false;
            }

            allowAnyFiletypeToolStripMenuItem2.Text = $"Renamed {new FileInfo(oldFileName).Name} to {new FileInfo(newFileName).Name}";
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

        }
        private void ListBox_files_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if user clicks another file, clear the previous file's temp name
            newFilenameTemp = "";
            allowAnyFiletypeToolStripMenuItem2.Text = $"Name reset.";

            // a different filename was selected, read it and display
            var currentFile = (ListBox)sender;
            if (currentFile.SelectedItem == null)
                return;

            var currentFilePath = currentFile.SelectedItem.ToString();
            if (!File.Exists(currentFilePath))
            {
                allowAnyFiletypeToolStripMenuItem2.Text = $"ERROR: cannot find {currentFilePath}";
                return;
            }

            // verify if it's a video
            if (supportedVideoExtensions.Contains(new FileInfo(currentFilePath).Extension))
            {
                axWindowsMediaPlayer1.Show();
                axWindowsMediaPlayer1.URL = currentFilePath;
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
                    allowAnyFiletypeToolStripMenuItem2.Text = $"{e.KeyCode},{e.KeyData},{e.KeyValue}";

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
                        allowAnyFiletypeToolStripMenuItem2.Text = $"Name reset.";
                        return;
                    }
                    if (newFilenameTemp == "")
                        return;
                    if (RenameFile(oldFileName, newFilenameTemp))
                        newFilenameTemp = "";
                    return;

                case Keys.Enter:
                    if (newFilenameTemp == "")
                        return;
                    if (RenameFile(oldFileName, newFilenameTemp))
                        newFilenameTemp = "";
                    return;

                case Keys.Escape:
                    newFilenameTemp = "";
                    allowAnyFiletypeToolStripMenuItem2.Text = $"Name reset.";
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

            allowAnyFiletypeToolStripMenuItem2.Text = $"New name: {newFilenameTemp}";

        }
        private void ListBox_files_KeyPress(object sender, KeyPressEventArgs e)
        {
            // prevent name change keys to seek filename in the list
            e.Handled = true; 
        }
        private void AxWindowsMediaPlayer1_StatusChange(object sender, EventArgs e)
        {
            // auto play for webm's. would crash as it's async
            // also this function might run excessively
            try
            {
                if (axWindowsMediaPlayer1.playState != WMPLib.WMPPlayState.wmppsPaused)
                    axWindowsMediaPlayer1.Ctlcontrols.play();
            }
            catch
            {

            }
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
        private void ZoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Refresh();
        }
        private void NormalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
            pictureBox1.Refresh();
        }
        private void AutoSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.Refresh();
        }
        private void CenterImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.Refresh();
        }
        private void StretchImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Refresh();
        }
        private void test()
        {
            ffplay.StartInfo.FileName = "ffplay.exe";
            ffplay.StartInfo.Arguments = @"F:\\a.webm";
            ffplay.StartInfo.CreateNoWindow = true;
            ffplay.StartInfo.RedirectStandardOutput = true;
            ffplay.StartInfo.UseShellExecute = false;
            ffplay.Start();
            Thread.Sleep(500);
            SetParent(ffplay.MainWindowHandle, axWindowsMediaPlayer1.Handle);
        }
        public Process ffplay = new Process();

        [DllImport("user32.dll")]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        private void AxWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {
            listBox_files.Focus();
            if (listBox_files.Items.Count > 0)
                listBox_files.SelectedIndex = 0;
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            listBox_files.Focus();
            if (listBox_files.Items.Count > 0)
                listBox_files.SelectedIndex = 0;
        }

        private void TestToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
