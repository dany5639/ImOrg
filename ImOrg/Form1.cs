using System;
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
        private List<itemInfo> items = new List<itemInfo>();

        private bool isDebug = false;
        private bool ffplay_isRunning = false;
        private string currNewName = "";
        private string prevNewName = "";
        private Color ForeColor_ = Color.White;
        private Color BackColor_ = Color.Black;
        private int previouslySelectedItem = -1;
        private int videoSkipSeconds = 5;
        private string fullPath = "";
        private string oldFullpath = "";
        private string newFullpath = "";

        private class itemInfo
        {
            public int Index;
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
                // case ".gif":
                case ".tif":
                case ".tiff":
                case ".bmp":
                // case ".ico":
                    // ".webp", // not supported
                    // ".dds", // not supported
                    // ".tga", // not supported
                    return itemType.image;

                // case ".webm":
                // case ".mp4":
                case ".mkv":

                // UNTESTED but in the list of supported formats:
                #region FFPLAY
                case ".3dostr":
                case ".3g2":
                case ".3gp":
                case ".4xm":
                case ".a64":
                case ".aa":
                case ".aac":
                case ".ac3":
                case ".acm":
                case ".act":
                case ".adf":
                case ".adp":
                case ".ads":
                case ".adts":
                case ".adx":
                case ".aea":
                case ".afc":
                case ".aiff":
                case ".aix":
                case ".alaw":
                case ".alias_pix":
                case ".amr":
                case ".amrnb":
                case ".amrwb":
                case ".anm":
                case ".apc":
                case ".ape":
                case ".apng":
                case ".aptx":
                case ".aptx_hd":
                case ".aqtitle":
                case ".asf":
                case ".asf_o":
                case ".asf_stream":
                case ".ass":
                case ".ast":
                case ".au":
                case ".avi":
                case ".avisynth":
                case ".avm2":
                case ".avr":
                case ".avs":
                case ".avs2":
                case ".bethsoftvid":
                case ".bfi":
                case ".bfstm":
                case ".bin":
                case ".bink":
                case ".bit":
                case ".bmp_pipe":
                case ".bmv":
                case ".boa":
                case ".brender_pix":
                case ".brstm":
                case ".c93":
                case ".caf":
                case ".cavsvideo":
                case ".cdg":
                case ".cdxl":
                case ".cine":
                case ".codec2":
                case ".codec2raw":
                case ".concat":
                case ".crc":
                case ".dash":
                case ".data":
                case ".daud":
                case ".dcstr":
                case ".dds_pipe":
                case ".dfa":
                case ".dhav":
                case ".dirac":
                case ".dnxhd":
                case ".dpx_pipe":
                case ".dsf":
                case ".dshow":
                case ".dsicin":
                case ".dss":
                case ".dts":
                case ".dtshd":
                case ".dv":
                case ".dvbsub":
                case ".dvbtxt":
                case ".dvd":
                case ".dxa":
                case ".ea":
                case ".ea_cdata":
                case ".eac3":
                case ".epaf":
                case ".exr_pipe":
                case ".f32be":
                case ".f32le":
                case ".f4v":
                case ".f64be":
                case ".f64le":
                case ".ffmetadata":
                case ".fifo":
                case ".fifo_test":
                case ".film_cpk":
                case ".filmstrip":
                case ".fits":
                case ".flac":
                case ".flic":
                case ".flv":
                case ".framecrc":
                case ".framehash":
                case ".framemd5":
                case ".frm":
                case ".fsb":
                case ".g722":
                case ".g723_1":
                case ".g726":
                case ".g726le":
                case ".g729":
                case ".gdigrab":
                case ".gdv":
                case ".genh":
                case ".gif":
                case ".gif_pipe":
                case ".gsm":
                case ".gxf":
                case ".h261":
                case ".h263":
                case ".h264":
                case ".hash":
                case ".hcom":
                case ".hds":
                case ".hevc":
                case ".hls":
                case ".hnm":
                case ".ico":
                case ".idcin":
                case ".idf":
                case ".iff":
                case ".ifv":
                case ".ilbc":
                case ".image2":
                case ".image2pipe":
                case ".ingenient":
                case ".ipmovie":
                case ".ipod":
                case ".ircam":
                case ".ismv":
                case ".iss":
                case ".iv8":
                case ".ivf":
                case ".ivr":
                case ".j2k_pipe":
                case ".jacosub":
                case ".jpeg_pipe":
                case ".jpegls_pipe":
                case ".jv":
                case ".kux":
                case ".latm":
                case ".lavfi":
                case ".libopenmpt":
                case ".live_flv":
                case ".lmlm4":
                case ".loas":
                case ".lrc":
                case ".lvf":
                case ".lxf":
                case ".m4v":
                case ".matroska":
                case ".md5":
                case ".mgsts":
                case ".microdvd":
                case ".mjpeg":
                case ".mjpeg_2000":
                case ".mkvtimestamp_v2":
                case ".mlp":
                case ".mlv":
                case ".mm":
                case ".mmf":
                case ".mov":
                case ".m4a":
                case ".mj2":
                case ".mp2":
                case ".mp3":
                case ".mp4":
                case ".mpc":
                case ".mpc8":
                case ".mpeg":
                case ".mpeg1video":
                case ".mpeg2video":
                case ".mpegts":
                case ".mpegtsraw":
                case ".mpegvideo":
                case ".mpjpeg":
                case ".mpl2":
                case ".mpsub":
                case ".msf":
                case ".msnwctcp":
                case ".mtaf":
                case ".mtv":
                case ".mulaw":
                case ".musx":
                case ".mv":
                case ".mvi":
                case ".mxf":
                case ".mxf_d10":
                case ".mxf_opatom":
                case ".mxg":
                case ".nc":
                case ".nistsphere":
                case ".nsp":
                case ".nsv":
                case ".null":
                case ".nut":
                case ".nuv":
                case ".oga":
                case ".ogg":
                case ".ogv":
                case ".oma":
                case ".opus":
                case ".paf":
                case ".pam_pipe":
                case ".pbm_pipe":
                case ".pcx_pipe":
                case ".pgm_pipe":
                case ".pgmyuv_pipe":
                case ".pictor_pipe":
                case ".pjs":
                case ".pmp":
                case ".png_pipe":
                case ".ppm_pipe":
                case ".psd_pipe":
                case ".psp":
                case ".psxstr":
                case ".pva":
                case ".pvf":
                case ".qcp":
                case ".qdraw_pipe":
                case ".r3d":
                case ".rawvideo":
                case ".realtext":
                case ".redspark":
                case ".rl2":
                case ".rm":
                case ".roq":
                case ".rpl":
                case ".rsd":
                case ".rso":
                case ".rtp":
                case ".rtp_mpegts":
                case ".rtsp":
                case ".s16be":
                case ".s16le":
                case ".s24be":
                case ".s24le":
                case ".s32be":
                case ".s32le":
                case ".s337m":
                case ".s8":
                case ".sami":
                case ".sap":
                case ".sbc":
                case ".sbg":
                case ".scc":
                case ".sdl":
                case ".sdl2":
                case ".sdp":
                case ".sdr2":
                case ".sds":
                case ".sdx":
                case ".segment":
                case ".ser":
                case ".sgi_pipe":
                case ".shn":
                case ".siff":
                case ".singlejpeg":
                case ".sln":
                case ".smjpeg":
                case ".smk":
                case ".smoothstreaming":
                case ".smush":
                case ".sol":
                case ".sox":
                case ".spdif":
                case ".spx":
                case ".srt":
                case ".stl":
                case ".stream_segment":
                case ".ssegment":
                case ".subviewer":
                case ".subviewer1":
                case ".sunrast_pipe":
                case ".sup":
                case ".svag":
                case ".svcd":
                case ".svg_pipe":
                case ".swf":
                case ".tak":
                case ".tedcaptions":
                case ".tee":
                case ".thp":
                case ".tiertexseq":
                case ".tiff_pipe":
                case ".tmv":
                case ".truehd":
                case ".tta":
                case ".tty":
                case ".txd":
                case ".ty":
                case ".u16be":
                case ".u16le":
                case ".u24be":
                case ".u24le":
                case ".u32be":
                case ".u32le":
                case ".u8":
                case ".uncodedframecrc":
                case ".v210":
                case ".v210x":
                case ".vag":
                case ".vc1":
                case ".vc1test":
                case ".vcd":
                case ".vfwcap":
                case ".vidc":
                case ".vividas":
                case ".vivo":
                case ".vmd":
                case ".vob":
                case ".vobsub":
                case ".voc":
                case ".vpk":
                case ".vplayer":
                case ".vqf":
                case ".w64":
                case ".wav":
                case ".wc3movie":
                case ".webm":
                case ".webm_chunk":
                case ".webm_dash_manifest":
                case ".webp":
                case ".webp_pipe":
                case ".webvtt":
                case ".wsaud":
                case ".wsd":
                case ".wsvqa":
                case ".wtv":
                case ".wv":
                case ".wve":
                case ".xa":
                case ".xbin":
                case ".xmv":
                case ".xpm_pipe":
                case ".xvag":
                case ".xwd_pipe":
                case ".xwma":
                case ".yop":
                case ".yuv4mpegpipe":
                    return itemType.video;
                #endregion

                #region TXT
                case ".txt":
                case ".csv":
                case ".log":
                case ".xml":
                case ".json":
                case ".xaml":
                    return itemType.text;
                #endregion

                case "Directory":
                    return itemType.directory;

                default:
                    log($"File format not currently supported: {extension}");
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
        private void log(string in_)
        {
            Console.WriteLine($"[{DateTime.Now.ToString("hhmmss:fff")}] {in_}");

        }
        private void log_ts(string in_)
        {
            ToolStrip.Text = $"Renamed {oldFullpath} to {newFullpath}";

        }
        private static bool WriteCsv(List<string> in_, string file)
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
            catch (Exception err)
            {
                return false;
            }

            return true;

        }
        private static List<string> ReadCsv(string filename, int lineCount = 1)
        {
            var output = new List<string>();

            using (var reader = new StreamReader(filename))
            {
                var line = "";
                int j = -1;
                while (line != null)
                {
                    j++;
                    if (j == lineCount)
                        break;

                    line = reader.ReadLine();
                    output.Add(line);
                }

                if (output.Last() == null)
                    output.RemoveAt(output.Count - 1);
            }

            return output;
        }
        #endregion

        #region Theme related
        private void RGBTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();

            // prevent text color from being the same as background color
            if (colorDialog1.Color == BackColor_)
                return;
            ForeColor_ = colorDialog1.Color;

            SetAppColors();

        }
        private void RGBBackgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            BackColor_ = colorDialog1.Color;

            SetAppColors();

        }
        private void SetAppColors()
        {
            listBox_files.ForeColor = ForeColor_;
            listBox_files.BackColor = BackColor_;

            treeView_folders.BackColor = BackColor_;
            treeView_folders.ForeColor = ForeColor_;

            this.BackColor = BackColor_;
            this.ForeColor = ForeColor_;

            ToolStrip.ForeColor = ForeColor_;
            ToolStrip.BackColor = BackColor_;

            statusStrip1.ForeColor = ForeColor_;
            statusStrip1.BackColor = BackColor_;

            richTextBox1.ForeColor = ForeColor_;
            richTextBox1.BackColor = BackColor_;

            pictureBox1.ForeColor = ForeColor_;
            pictureBox1.BackColor = BackColor_;

            toolStripDropDownButton1.ForeColor = ForeColor_;
            toolStripDropDownButton1.BackColor = BackColor_;

            // this did not go as planned
            // rGBTextToolStripMenuItem.BackColor = BackColor_;
            // rGBBackgroundToolStripMenuItem.BackColor = BackColor_;
            // allowUPDOWNToRenameToolStripMenuItem.BackColor = BackColor_;
            // allowAnyFiletypeToolStripMenuItem.BackColor = BackColor_;
            // sortFilesByTypeToolStripMenuItem.BackColor = BackColor_;
            // toolStripMenuItem1.BackColor = BackColor_;
            // videoScrollingSpeedToolStripMenuItem.BackColor = BackColor_;
            // renamingTypeToolStripMenuItem.BackColor = BackColor_;
            // startVideoMutedToolStripMenuItem.BackColor = BackColor_;
            // allowFolderHandlingToolStripMenuItem.BackColor = BackColor_;
            // 
            // rGBTextToolStripMenuItem.ForeColor = ForeColor_;
            // rGBBackgroundToolStripMenuItem.ForeColor = ForeColor_;
            // allowUPDOWNToRenameToolStripMenuItem.ForeColor = ForeColor_;
            // allowAnyFiletypeToolStripMenuItem.ForeColor = ForeColor_;
            // sortFilesByTypeToolStripMenuItem.ForeColor = ForeColor_;
            // toolStripMenuItem1.ForeColor = ForeColor_;
            // videoScrollingSpeedToolStripMenuItem.ForeColor = ForeColor_;
            // renamingTypeToolStripMenuItem.ForeColor = ForeColor_;
            // startVideoMutedToolStripMenuItem.ForeColor = ForeColor_;
            // allowFolderHandlingToolStripMenuItem.ForeColor = ForeColor_;
        }
        private void FontToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            this.Font = fontDialog1.Font;
            label1.Font = fontDialog1.Font;
            label2.Font = fontDialog1.Font;
            label3.Font = fontDialog1.Font;
            label4.Font = fontDialog1.Font;
            label5.Font = fontDialog1.Font;
            label6.Font = fontDialog1.Font;
            label7.Font = fontDialog1.Font;
            ToolStrip.Font = fontDialog1.Font;
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

            panel1.Hide();

            richTextBox1.Hide();

            imagesToolStripMenuItem.Checked = true;
            videosToolStripMenuItem.Checked = true;
            textToolStripMenuItem.Checked = true;
            directoriesToolStripMenuItem.Checked = true;
            unsupportedToolStripMenuItem.Checked = false;

#if DEBUG
            DoDebugStuf();
#endif

        }
        private void ListBox_files_SelectedIndexChanged(object sender, EventArgs e) // click an image in the list
        {
            timer_renameItems.Start(); // if a video failed to get renamed previously, attempt now

            var currentFile = (ListBox)sender;
            if (currentFile.SelectedItem == null)
                return;

            // don't do anything if the selected file didn't change incase the user clicked outside and needs to click back to rename it
            if (currentFile.SelectedIndex == previouslySelectedItem)
                return;

            fullPath = items[currentFile.SelectedIndex].fullpath;

            if (items[currentFile.SelectedIndex].type == itemType.directory)
            {
                if (!Directory.Exists(fullPath))
                {
                    ToolStrip.Text = $"ERROR: cannot find {fullPath}";
                    return;
                }

                goto skipForDirectory;
            }
            else if (!File.Exists(fullPath))
            {
                ToolStrip.Text = $"ERROR: cannot find {fullPath}";
                return;
            }

            richTextBox1.Hide();
            pictureBox1.Hide();
            if (ffplay_isRunning)
                ffplay_kill();

            switch (items[currentFile.SelectedIndex].type)
            {
                case itemType.video:
                    pictureBox1.Show();
                    ffplay_loadVideo();
                    break;

                case itemType.image:
                    pictureBox1.Show();
                    pictureBox1.LoadAsync(fullPath);
                    break;

                case itemType.text:
                    richTextBox1.Show();
                    LoadText(fullPath);
                    break;

                default:
                    break;
            }

            skipForDirectory:

            // check if this should be placed after RenameFile(); or not
            previouslySelectedItem = currentFile.SelectedIndex;

            // try to scroll the files list further to see the next files
            // ...
            // can't find any method to increment scroll by one

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
                log($"ERROR: {e_cannotReadFolder.Message}");
                return;
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
            listBox_files.Items.Clear();
            items.Clear();

            if (!Directory.Exists(e.Node.FullPath))
                return;

            IEnumerable<string> files = null;

            try
            {
                files = Directory.EnumerateFileSystemEntries($"{e.Node.FullPath}\\");
            }
            catch (UnauthorizedAccessException err)
            {
                ToolStrip.Text = $"ERROR on selecting file: {err.Message}";
            }

            // add all files with supported extensions

            // add dropdown menu toggle to add files in order or by type
            // bad design, ended up with forcing the type order

            var items2 = new List<itemInfo>();

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                var ext = fileInfo.Extension;
                var filenameWithoutExtension = $"{fileInfo.Name.Substring(0, fileInfo.Name.Length - fileInfo.Extension.Length)}";

                var filename = fileInfo.Name;

                if (!allowAnyFiletypeToolStripMenuItem.Checked)
                    filename = file.Split("\\".ToCharArray()).Last(); // use this for folder name

                if (fileInfo.Attributes.ToString().Contains("Directory"))
                    ext = "Directory";

                items2.Add(new itemInfo
                {
                    filename = filename,
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
                items2 = items2.OrderBy(x => x.filename).ToList(); // could order by different methods here

            if (sortFilesByTypeToolStripMenuItem.Checked)
                items2 = items2.OrderBy(x => x.type).ToList(); // could order by different methods here

            int i = -1;
            foreach (var a in items2)
            {
                switch(a.type)
                {
                    case itemType.image:
                        if (!imagesToolStripMenuItem.Checked)
                            continue;
                        break;

                    case itemType.video:
                        if (!videosToolStripMenuItem.Checked)
                            continue;
                        break;

                    case itemType.text:
                        if (!textToolStripMenuItem.Checked)
                            continue;
                        break;

                    case itemType.directory:
                        if (!directoriesToolStripMenuItem.Checked)
                            continue;
                        break;

                    case itemType.noExtension:
                    case itemType.unsupported:
                        if (!unsupportedToolStripMenuItem.Checked)
                            continue;
                        break;

                    default:
                        throw new Exception($"ERROR: That shouldn't have happened: TreeView1_AfterSelect(): {a.extension}");
                }

                i++;
                a.Index = i;
                items.Add(a);
                listBox_files.Items.Add(a.filename);
            }

            // add folders
            if (!allowFolderHandlingToolStripMenuItem.Checked)
                return;

            // add folders
            foreach (var a in items2)
            {
                if (a.type != itemType.directory)
                    continue;

                i++;
                a.Index = i;
                items.Add(a);
                listBox_files.Items.Add(a.filename);
            }

        }
        #endregion
       
        #region keys related
        private void ListBox_files_KeyDown(object sender, KeyEventArgs e) // press a key
        {
            if (listBox_files.SelectedItem == null)
                return;

            // need to fix symbols not working, numbers on azerty keyboard being wrong, other special keys
            // if (false) // debug
            //     if (e.KeyCode != Keys.ShiftKey)
            //         ToolStrip.Text = $"{e.KeyCode},{e.KeyData},{e.KeyValue}";

            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (!ffplay_isRunning)
                        break;
                    SetForegroundWindow((int)ffplay.MainWindowHandle);
                    e.Handled = true;
                    timer_refocusMain.Start();
                    return;
                case Keys.Right:
                    if (!ffplay_isRunning)
                        break;
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
                case Keys.Enter: // really need to replace with a textbox for more editing control
                    keysEnter:
                    var selectedIndex = listBox_files.SelectedIndex; // rename the currently selected item

                    if (currNewName == "") // new name has been assigned
                        return;

                    log($"ListBox_files_KeyDown: {items[selectedIndex].filename}; {items[selectedIndex].newFilenameTemp}");
                    items[selectedIndex].newFilenameTemp = currNewName;
                    items[selectedIndex].toRename = true;
                    ToolStrip.Text = $"Renaming queued: {items[selectedIndex].filename} to {currNewName}";
                    log($"Renaming queued: {items[selectedIndex].filename} to {currNewName}");
                    prevNewName = currNewName; // this is the new name used previously for the last renamed item
                    currNewName = ""; // this is the new name, currently modified with letters or F1 or F3

                    if (ffplay_isRunning)
                        ffplay_kill();

                    timer_renameItems.Start(); // start renaming if: new video is selected and previous video is released;

                    return;

                case Keys.Escape:
                    currNewName = "";
                    ToolStrip.Text = $"Name reset."; // maybe use to undo
                    return;

                #region numbers and signs
                case Keys.OemMinus: currNewName = $"{currNewName}_"; break;
                case Keys.Subtract: currNewName = $"{currNewName}-"; break;
                case Keys.NumPad0: currNewName = $"{currNewName}0"; break;
                case Keys.NumPad1: currNewName = $"{currNewName}1"; break;
                case Keys.NumPad2: currNewName = $"{currNewName}2"; break;
                case Keys.NumPad3: currNewName = $"{currNewName}3"; break;
                case Keys.NumPad4: currNewName = $"{currNewName}4"; break;
                case Keys.NumPad5: currNewName = $"{currNewName}5"; break;
                case Keys.NumPad6: currNewName = $"{currNewName}6"; break;
                case Keys.NumPad7: currNewName = $"{currNewName}7"; break;
                case Keys.NumPad8: currNewName = $"{currNewName}8"; break;
                case Keys.NumPad9: currNewName = $"{currNewName}9"; break;
                case Keys.Space: currNewName = $"{currNewName} "; break;
                case Keys.Add: currNewName = $"{currNewName}+"; break;
                case Keys.D0: currNewName = $"{currNewName}0"; break;
                case Keys.D1: currNewName = $"{currNewName}1"; break;
                case Keys.D2: currNewName = $"{currNewName}2"; break;
                case Keys.D3: currNewName = $"{currNewName}3"; break;
                case Keys.D4: currNewName = $"{currNewName}4"; break;
                case Keys.D5: currNewName = $"{currNewName}5"; break;
                case Keys.D6: currNewName = $"{currNewName}6"; break;
                case Keys.D7: currNewName = $"{currNewName}7"; break;
                case Keys.D8: currNewName = $"{currNewName}8"; break;
                case Keys.D9: currNewName = $"{currNewName}9"; break;
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
                        currNewName = $"{currNewName}{e.KeyCode}";
                    else
                        currNewName = $"{currNewName}{e.KeyCode.ToString().ToLower()}";
                    break;
                #endregion

                case Keys.Back:
                    if (currNewName != "")
                        currNewName = currNewName.Remove(currNewName.Length - 1, 1);
                    break;

                // press this key to use the last used filename
                case Keys.F1:
                    // use the last renamed file as template
                    // maybe change key or let the user customize it
                    currNewName = prevNewName;
                    if (currNewName != "")
                        ToolStrip.Text = $"Reusing: {currNewName}"; // maybe use to undo
                    return;

                case Keys.F2: // change renaming mode
                    var np = toolStripComboBox_renamingMode.SelectedIndex;
                    if (np == toolStripComboBox_renamingMode.Items.Count - 1)
                        np = -1;

                    np = np + 1;
                    toolStripComboBox_renamingMode.SelectedIndex = np;
                    ToolStrip.Text = $"Renaming mode: {(renamingMode)toolStripComboBox_renamingMode.SelectedIndex}";
                    return;

                case Keys.F3: // get original filename and use as new name
                    selectedIndex = listBox_files.SelectedIndex;
                    
                    var it = items[selectedIndex];
                    var og = it.originalFullpath;
                    
                    if (it.type == itemType.directory)
                        items[selectedIndex].newFilenameTemp = og.Substring(og.LastIndexOf("\\") + 1, og.Length - og.LastIndexOf("\\") - 1);
                    else
                        items[selectedIndex].newFilenameTemp = og.Substring(og.LastIndexOf("\\") + 1, og.Length - it.extension.Length - og.LastIndexOf("\\") - 1);
                    
                    items[selectedIndex].toRename = true;
                    
                    ToolStrip.Text = $"Renaming queued: {it.filename} to {items[selectedIndex].newFilenameTemp}";

                    if (ffplay_isRunning)
                        ffplay_kill();

                    timer_renameItems.Start();
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

            if (currNewName != "")
                ToolStrip.Text = $"New name: {currNewName}";

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
            dialogBox.BackColor = BackColor_;
            dialogBox.ForeColor = ForeColor_;
            var label = new Label();
            label.AutoSize = true;
            label.Font = new Font("Consolas", 10.25F, FontStyle.Regular, GraphicsUnit.Point);
            label.Text =
                "Shortcuts list:" +
                "\nESC : cancel last new name." +
                "\nF1  : use the last typed name." +
                "\nF2  : change renaming mode." +
                "\nF3  : restore the original filename from before renaming it in this session." +
                "\nF12 : change image view mode" +
                "\n" +
                "";

            label.ForeColor = ForeColor_;
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
        private void renameAndMoveItems()
        {
            var processedIndexes = new List<int>();

            // don't loop trough the list of all items as the list can be long, instead check the list of items to name
            foreach (var item in items)
            {
                if (item.type == itemType.directory)
                    continue;

                if (item.toRename == false)
                    continue;

                // skip files if new name was failed to be set
                if (item.newFilenameTemp == "")
                    continue;

                oldFullpath = item.fullpath;

                log($"To rename: {oldFullpath}; {item.newFilenameTemp}; {(renamingMode)toolStripComboBox_renamingMode.SelectedIndex}");

                if (!new FileInfo(oldFullpath).Exists)
                {
                    log($"managePreviousItems(): error: file doesn't exists. prevFileName = {oldFullpath};");
                    return;
                }

                var ogFileInfo = new FileInfo(oldFullpath);
                var ogFileInfoDirectory = ogFileInfo.Directory.ToString();
                var filenameWithoutExtension = item.filenameWithoutExtension;
                var newName = item.newFilenameTemp;

                switch ((renamingMode)toolStripComboBox_renamingMode.SelectedIndex)
                {
                    case renamingMode.move:
                        ogFileInfoDirectory = $"{ogFileInfoDirectory}\\{newName}";

                        if (!Directory.Exists($"{ogFileInfoDirectory}"))
                            Directory.CreateDirectory($"{ogFileInfoDirectory}");

                        newName = ogFileInfo.Name.Substring(0, ogFileInfo.Name.Length - ogFileInfo.Extension.Length);
                        newFullpath = $"{ogFileInfoDirectory}\\{newName}";
                        item.relativePath = true;
                        break;

                    case renamingMode.replace:
                        newFullpath = $"{ogFileInfoDirectory}\\{newName}";
                        break;

                    case renamingMode.start:
                        newFullpath = $"{ogFileInfoDirectory}\\{newName}{filenameWithoutExtension}";
                        break;

                    case renamingMode.end:
                        newFullpath = $"{ogFileInfoDirectory}\\{filenameWithoutExtension}{newName}";
                        break;

                    default:
                        throw new Exception("New name position: Index out of bounds");

                }

                // rename by adding the standard windows method: (?)
                if (File.Exists($"{newFullpath}{ogFileInfo.Extension}"))
                {
                    var k = -1;
                    var newFullpath2 = newFullpath;
                    if (newFullpath.Last() != ")".ToCharArray()[0])
                    {
                        // this shouldn't be required
                        while (File.Exists($"{newFullpath}{ogFileInfo.Extension}"))
                        {
                            k++;
                            newFullpath = $"{newFullpath2} ({k})";
                        }
                        // this shouldn't be required

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

                if (item.relativePath)
                {
                    try
                    {
                        File.Move(oldFullpath, newFullpath);
                        log($"Moved {oldFullpath} to {newFullpath}");
                    }
                    catch (IOException err)
                    {
                        log_ts($"Failed on managePreviousItems() on files: {oldFullpath} to {newFullpath}: {err}");
                        continue;
                    }
                }
                else
                {
                    var filename = new FileInfo(newFullpath).Name;
                    if (!File.Exists(filename))
                    {
                        try
                        {
                            Microsoft.VisualBasic.FileIO.FileSystem.RenameFile(oldFullpath, filename);
                            log_ts($"Renamed {oldFullpath} to {newFullpath}");
                        }
                        catch (IOException err)
                        {
                            log($"ERROR: failed to rename or move {oldFullpath} to {newFullpath}: {err}");
                            continue;
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
                item.toRename = false;
                item.relativePath = false;
                item.filenameWithoutExtension = filenameWithoutExtension;
                var di = item.filename.LastIndexOf(".".ToCharArray()[0]);
                var el = item.filename.Length - di;

                item.filenameWithoutExtension = $"{item.filename.Substring(0, item.filename.Length - el)}";

                listBox_files.Items[item.Index] = item.filename;

            }

            // rename folders
            foreach (var item in items)
            {
                if (item.type != itemType.directory)
                    continue;

                if (item.toRename == false)
                    continue;

                // skip files if new name was failed to be set
                var newName = item.newFilenameTemp;

                if (newName == "")
                    continue;

                oldFullpath = item.fullpath;

                log($"To rename: {oldFullpath}; {newName}; {(renamingMode)toolStripComboBox_renamingMode.SelectedIndex}");

                if (!Directory.Exists(oldFullpath))
                {
                    log($"RenameOrMoveItems(): error: directory doesn't exists. oldFullpath = {oldFullpath};");
                    return;
                }

                var parentDir = Directory.GetParent(oldFullpath);

                switch ((renamingMode)toolStripComboBox_renamingMode.SelectedIndex)
                {
                    case renamingMode.move:
                        if (!Directory.Exists($"{parentDir}\\{newName}"))
                            Directory.CreateDirectory($"{parentDir}\\{newName}");

                        newFullpath = $"{parentDir}\\{newName}\\{item.filename}";
                        item.relativePath = true;
                        break;

                    case renamingMode.replace:
                        newFullpath = $"{parentDir}\\{newName}";
                        break;

                    case renamingMode.start:
                        newFullpath = $"{parentDir}\\{newName}{item.filename}";
                        break;

                    case renamingMode.end:
                        newFullpath = $"{parentDir}\\{item.filename}{newName}";
                        break;

                    default:
                        throw new Exception("New name position: Index out of bounds");

                }

                // rename by adding the standard windows method: (?)
                if (Directory.Exists($"{newFullpath}"))
                {
                    // rename folder using windows standard method if it already exists
                    var k = -1;
                    var newFullpath2 = newFullpath;
                    if (newFullpath.Last() != ")".ToCharArray()[0])
                    {
                        // this shouldn't be required
                        while (Directory.Exists($"{newFullpath}"))
                        {
                            k++;
                            newFullpath = $"{newFullpath2} ({k})";
                        }
                        // this shouldn't be required
                        newFullpath = $"{newFullpath2} ({k})";
                        goto done1;
                    }

                    // don't verify each time if the item exists, it's very costly performance wise, simply parse the already existing number
                    var a = newFullpath.LastIndexOf("(".ToCharArray()[0]);
                    var value = newFullpath.Substring(a + 1, newFullpath.Length - a - 2);
                    int.TryParse(value, NumberStyles.Integer, null, out int lastInt);
                    while (Directory.Exists($"{newFullpath}"))
                    {
                        k++;
                        newFullpath = $"{newFullpath2} ({k})";
                    }
                }

                done1:

                log($"newFullpath after2 {newFullpath}");

                if (item.relativePath)
                {
                    try
                    {
                        Directory.Move(oldFullpath, newFullpath);
                        log_ts($"Renamed {oldFullpath} to {newFullpath}");
                    }
                    catch (IOException err)
                    {
                        log($"Failed: Directory.Move(): {err}");
                    }
                }
                else
                {
                    // shouldn't happen as the old was renamed if new existed
                    if (Directory.Exists(newFullpath) && !Directory.Exists(oldFullpath))
                    {
                        log_ts($"Failed: MoveDirectory(): {oldFullpath} to {newFullpath}.");
                        continue;
                    }

                    try
                    {
                        Microsoft.VisualBasic.FileIO.FileSystem.MoveDirectory(oldFullpath, newFullpath);
                        log_ts($"Renamed {oldFullpath} to {newFullpath}");
                    }
                    catch (Exception err)
                    {
                        log($"ERROR: failed to rename or move {oldFullpath} to {newFullpath}: {err}");
                        item.newFilenameTemp = "";
                        item.toRename = false;
                        item.relativePath = false;
                        continue;
                    }
                }

                // a last check
                if (!Directory.Exists(newFullpath))
                {
                    log_ts($"Failed to rename {oldFullpath} to {newFullpath}: new directory doesn't exist.");
                    continue;
                }

                item.fullpath = newFullpath;
                item.filename = newFullpath.Split("\\".ToCharArray()).Last();
                item.newFilenameTemp = "";
                item.toRename = false;
                item.relativePath = false;

                listBox_files.Items[item.Index] = item.filename;

            }

            timer_renameItems.Stop();

        }
        #endregion

        #region Timers
        private void Timer_refocusMain_Tick(object sender, EventArgs e)
        {
            // this is so janky i hate it
            // need a way to control ffplay without focusing its window, like a process.sendCommand()
            SetForegroundWindow((int)this.Handle);
            timer_refocusMain.Stop();
        }
        private void Timer_renameItems_Tick(object sender, EventArgs e)
        {
            renameAndMoveItems();
        }
        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            timer_startSetParent.Interval = (int)numericUpDown1.Value;
        }
        private void NumericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            timer_spamParent.Interval = (int)numericUpDown1.Value;
        }
        private void NumericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            timer_refocusMain.Interval = (int)numericUpDown1.Value;
        }
        private void NumericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            timer_renameItems.Interval = (int)numericUpDown1.Value;
        }
        private void NumericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            timer_killRogueFFPLAY.Interval = (int)numericUpDown1.Value;
        }
        #endregion

        #region FFPLAY DLL
        [DllImport("user32.dll")]
        private static extern int GetParent(IntPtr hWndChild);
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

            var volume = startVideoMutedToolStripMenuItem.Checked == true ? "0" : "100";

            ffplay.StartInfo.Arguments = $"" +
                $"-left {pictureBox1.Location.X + this.Location.X + 8} " +
                $"-top {pictureBox1.Location.Y + this.Location.Y + 30} " +
                $"-x {pictureBox1.Width} " +
                $"-y {pictureBox1.Height} " +
                $"-noborder " +
                // $"-autoexit " + // not good, it kills the video when i want to rewind at the end of a video
                $"-volume {volume} " +
                $"\"{fullPath}\"" +
                $"";

            ffplay.StartInfo.CreateNoWindow = true;
            ffplay.StartInfo.RedirectStandardInput = false;
            ffplay.StartInfo.RedirectStandardOutput = false;
            ffplay.StartInfo.UseShellExecute = false;

        }
        private void ffplay_startThread()
        {
            timer_killRogueFFPLAY.Start();
            ffplay.Start();
        }
        private void ffplay_Thread()
        {
            ffplay_isRunning = true;

            var threadStart = new ThreadStart(ffplay_startThread);
            var thread = new Thread(threadStart);
            thread.Start();
        }
        private void initializeTimers()
        {
            timer_startSetParent.Stop(); // ms time between opening ffplay and attempting to attach it to the main window. range: 400-700
            timer_spamParent.Stop(); // ms time between each attempt to attach it to the main window; 16 is every frame
            timer_refocusMain.Stop();

        }
        private void Timer_startSetParent_Tick(object sender, EventArgs e)
        {
            ffplay_attachVideo();
        }
        private void Timer_spamParent_Tick(object sender, EventArgs e)
        {
            // this is quite ugly, i need a way to find out that the ffplay window has spawned, and not spam a function to attach it every specified tick

            try
            {
                var a = ffplay.MainModule;
            }
            catch (Exception err)
            {
                timer_startSetParent.Stop();
                timer_spamParent.Stop();
                log($"ERROR on Timer_spamParent_Tick(): {err}");
                return;
            }

            if ((int)ffplay.MainWindowHandle != 0) // window handle will change once the video starts, somehow
            {
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

            timer_startSetParent.Stop();
        }
        private void ffplay_kill()
        {
            // needs a different way as it would kill any ffplay instances or fail to kill the one created by this program
            if (!ffplay_isRunning)
                return;

            try
            {
                ffplay.Kill();
                ffplay_isRunning = false;
            }
            catch (Exception err)
            {
                log($"ERROR on ffplay.Kill(): {err}");
            }

            timer_killRogueFFPLAY.Stop();
            timer_startSetParent.Stop();
        }
        private void ffplay_loadVideo()
        {
            timer_refocusMain.Stop();
            timer_spamParent.Stop();
            timer_startSetParent.Stop();

            ffplay_kill(); // don't allow other instances for now, as i can't kill the already existing instance

            ffplay_setInfo();

            ffplay_Thread();

            timer_startSetParent.Start();
        }
        private void PictureBox1_Resize(object sender, EventArgs e)
        {
            if (ffplay_isRunning)
                ffplay_loadVideo();
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            ffplay_kill();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ffplay_kill();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            ffplay_loadVideo();
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            ffplay_kill();
        }

        #endregion

        #region DEBUG
        private void DoDebugStuf()
        {
            isDebug = true;
            log($"DEBUG mode");

            try // ...
            {
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
            }
            catch (Exception err)
            {
                log($"ERROR on #if DEBUG: {err}");
            }

        }
        private void ToolStrip_Click(object sender, EventArgs e)
        {
            if (panel1.Visible)
                panel1.Hide();
            else
                panel1.Show();
        }
        #endregion

        #region LoadText
        private void LoadText(string filename)
        {
            var lines =  ReadCsv(filename, (int)numericUpDown6.Value);
            var text = "";

            foreach (var a in lines)
                text = $"{text}{a}\n";

            richTextBox1.Text = text;
        }
        #endregion

        // current major problems:
        // something keeps failing and leaves a rogue ffplay process running in the background and locking the video file

    }

}