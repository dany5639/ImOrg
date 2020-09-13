namespace ImOrg
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.treeView_folders = new System.Windows.Forms.TreeView();
            this.listBox_files = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.rGBTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rGBBackgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.allowAnyFiletypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.directoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unsupportedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allowFolderHandlingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allowUPDOWNToRenameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortFilesByTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renamingTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox_renamingMode = new System.Windows.Forms.ToolStripComboBox();
            this.videoScrollingSpeedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox_videoSkipLength = new System.Windows.Forms.ToolStripTextBox();
            this.startVideoMutedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStrip = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer_startSetParent = new System.Windows.Forms.Timer(this.components);
            this.timer_spamParent = new System.Windows.Forms.Timer(this.components);
            this.timer_refocusMain = new System.Windows.Forms.Timer(this.components);
            this.timer_renameItems = new System.Windows.Forms.Timer(this.components);
            this.timer_killRogueFFPLAY = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown6 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown5 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.fontToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView_folders
            // 
            this.treeView_folders.AllowDrop = true;
            this.treeView_folders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView_folders.Location = new System.Drawing.Point(0, 0);
            this.treeView_folders.Name = "treeView_folders";
            this.treeView_folders.Size = new System.Drawing.Size(201, 614);
            this.treeView_folders.TabIndex = 1;
            this.treeView_folders.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.TreeView1_BeforeExpand);
            this.treeView_folders.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView1_AfterSelect);
            // 
            // listBox_files
            // 
            this.listBox_files.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_files.FormattingEnabled = true;
            this.listBox_files.Location = new System.Drawing.Point(0, 620);
            this.listBox_files.Name = "listBox_files";
            this.listBox_files.Size = new System.Drawing.Size(1251, 95);
            this.listBox_files.TabIndex = 2;
            this.listBox_files.SelectedIndexChanged += new System.EventHandler(this.ListBox_files_SelectedIndexChanged);
            this.listBox_files.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListBox_files_KeyDown);
            this.listBox_files.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ListBox_files_KeyPress);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(207, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1044, 614);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Resize += new System.EventHandler(this.PictureBox1_Resize);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.ToolStrip});
            this.statusStrip1.Location = new System.Drawing.Point(0, 718);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1251, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rGBTextToolStripMenuItem,
            this.rGBBackgroundToolStripMenuItem,
            this.fontToolStripMenuItem2,
            this.toolStripSeparator1,
            this.allowAnyFiletypeToolStripMenuItem,
            this.allowFolderHandlingToolStripMenuItem,
            this.allowUPDOWNToRenameToolStripMenuItem,
            this.sortFilesByTypeToolStripMenuItem,
            this.renamingTypeToolStripMenuItem,
            this.videoScrollingSpeedToolStripMenuItem,
            this.startVideoMutedToolStripMenuItem,
            this.infoToolStripMenuItem1});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 20);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // rGBTextToolStripMenuItem
            // 
            this.rGBTextToolStripMenuItem.Name = "rGBTextToolStripMenuItem";
            this.rGBTextToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.rGBTextToolStripMenuItem.Text = "RGB Text";
            this.rGBTextToolStripMenuItem.Click += new System.EventHandler(this.RGBTextToolStripMenuItem_Click);
            // 
            // rGBBackgroundToolStripMenuItem
            // 
            this.rGBBackgroundToolStripMenuItem.Name = "rGBBackgroundToolStripMenuItem";
            this.rGBBackgroundToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.rGBBackgroundToolStripMenuItem.Text = "RGB Background";
            this.rGBBackgroundToolStripMenuItem.Click += new System.EventHandler(this.RGBBackgroundToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(212, 6);
            // 
            // allowAnyFiletypeToolStripMenuItem
            // 
            this.allowAnyFiletypeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imagesToolStripMenuItem,
            this.videosToolStripMenuItem,
            this.textToolStripMenuItem,
            this.directoriesToolStripMenuItem,
            this.unsupportedToolStripMenuItem});
            this.allowAnyFiletypeToolStripMenuItem.Name = "allowAnyFiletypeToolStripMenuItem";
            this.allowAnyFiletypeToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.allowAnyFiletypeToolStripMenuItem.Text = "Allow the following items:";
            // 
            // imagesToolStripMenuItem
            // 
            this.imagesToolStripMenuItem.CheckOnClick = true;
            this.imagesToolStripMenuItem.Name = "imagesToolStripMenuItem";
            this.imagesToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.imagesToolStripMenuItem.Text = "Images";
            // 
            // videosToolStripMenuItem
            // 
            this.videosToolStripMenuItem.CheckOnClick = true;
            this.videosToolStripMenuItem.Name = "videosToolStripMenuItem";
            this.videosToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.videosToolStripMenuItem.Text = "Videos";
            // 
            // textToolStripMenuItem
            // 
            this.textToolStripMenuItem.CheckOnClick = true;
            this.textToolStripMenuItem.Name = "textToolStripMenuItem";
            this.textToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.textToolStripMenuItem.Text = "Text";
            // 
            // directoriesToolStripMenuItem
            // 
            this.directoriesToolStripMenuItem.CheckOnClick = true;
            this.directoriesToolStripMenuItem.Name = "directoriesToolStripMenuItem";
            this.directoriesToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.directoriesToolStripMenuItem.Text = "Directories";
            // 
            // unsupportedToolStripMenuItem
            // 
            this.unsupportedToolStripMenuItem.Name = "unsupportedToolStripMenuItem";
            this.unsupportedToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.unsupportedToolStripMenuItem.Text = "Unsupported";
            // 
            // allowFolderHandlingToolStripMenuItem
            // 
            this.allowFolderHandlingToolStripMenuItem.CheckOnClick = true;
            this.allowFolderHandlingToolStripMenuItem.Name = "allowFolderHandlingToolStripMenuItem";
            this.allowFolderHandlingToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.allowFolderHandlingToolStripMenuItem.Text = "Allow folder handling";
            // 
            // allowUPDOWNToRenameToolStripMenuItem
            // 
            this.allowUPDOWNToRenameToolStripMenuItem.Checked = true;
            this.allowUPDOWNToRenameToolStripMenuItem.CheckOnClick = true;
            this.allowUPDOWNToRenameToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.allowUPDOWNToRenameToolStripMenuItem.Name = "allowUPDOWNToRenameToolStripMenuItem";
            this.allowUPDOWNToRenameToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.allowUPDOWNToRenameToolStripMenuItem.Text = "Allow Up/Down to rename";
            // 
            // sortFilesByTypeToolStripMenuItem
            // 
            this.sortFilesByTypeToolStripMenuItem.Checked = true;
            this.sortFilesByTypeToolStripMenuItem.CheckOnClick = true;
            this.sortFilesByTypeToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sortFilesByTypeToolStripMenuItem.Name = "sortFilesByTypeToolStripMenuItem";
            this.sortFilesByTypeToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.sortFilesByTypeToolStripMenuItem.Text = "Sort files by type";
            // 
            // renamingTypeToolStripMenuItem
            // 
            this.renamingTypeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox_renamingMode});
            this.renamingTypeToolStripMenuItem.Name = "renamingTypeToolStripMenuItem";
            this.renamingTypeToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.renamingTypeToolStripMenuItem.Text = "Renaming type";
            // 
            // toolStripComboBox_renamingMode
            // 
            this.toolStripComboBox_renamingMode.Items.AddRange(new object[] {
            "Move to folder",
            "Replace",
            "Add at start",
            "Add at the end"});
            this.toolStripComboBox_renamingMode.Name = "toolStripComboBox_renamingMode";
            this.toolStripComboBox_renamingMode.Size = new System.Drawing.Size(121, 23);
            // 
            // videoScrollingSpeedToolStripMenuItem
            // 
            this.videoScrollingSpeedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox_videoSkipLength});
            this.videoScrollingSpeedToolStripMenuItem.Name = "videoScrollingSpeedToolStripMenuItem";
            this.videoScrollingSpeedToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.videoScrollingSpeedToolStripMenuItem.Text = "Video jump amount";
            // 
            // toolStripTextBox_videoSkipLength
            // 
            this.toolStripTextBox_videoSkipLength.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox_videoSkipLength.Name = "toolStripTextBox_videoSkipLength";
            this.toolStripTextBox_videoSkipLength.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox_videoSkipLength.TextChanged += new System.EventHandler(this.ToolStripTextBox1_textChanged);
            // 
            // startVideoMutedToolStripMenuItem
            // 
            this.startVideoMutedToolStripMenuItem.Checked = true;
            this.startVideoMutedToolStripMenuItem.CheckOnClick = true;
            this.startVideoMutedToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.startVideoMutedToolStripMenuItem.Name = "startVideoMutedToolStripMenuItem";
            this.startVideoMutedToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.startVideoMutedToolStripMenuItem.Text = "Start video muted";
            // 
            // infoToolStripMenuItem1
            // 
            this.infoToolStripMenuItem1.Name = "infoToolStripMenuItem1";
            this.infoToolStripMenuItem1.Size = new System.Drawing.Size(215, 22);
            this.infoToolStripMenuItem1.Text = "Info";
            this.infoToolStripMenuItem1.Click += new System.EventHandler(this.ToolStripMenuItem1_Click);
            // 
            // ToolStrip
            // 
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Size = new System.Drawing.Size(26, 17);
            this.ToolStrip.Text = "Idle";
            this.ToolStrip.Click += new System.EventHandler(this.ToolStrip_Click);
            // 
            // timer_startSetParent
            // 
            this.timer_startSetParent.Interval = 200;
            this.timer_startSetParent.Tick += new System.EventHandler(this.Timer_startSetParent_Tick);
            // 
            // timer_spamParent
            // 
            this.timer_spamParent.Interval = 8;
            this.timer_spamParent.Tick += new System.EventHandler(this.Timer_spamParent_Tick);
            // 
            // timer_refocusMain
            // 
            this.timer_refocusMain.Interval = 800;
            this.timer_refocusMain.Tick += new System.EventHandler(this.Timer_refocusMain_Tick);
            // 
            // timer_renameItems
            // 
            this.timer_renameItems.Interval = 500;
            this.timer_renameItems.Tick += new System.EventHandler(this.Timer_renameItems_Tick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.numericUpDown6);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.numericUpDown5);
            this.panel1.Controls.Add(this.numericUpDown4);
            this.panel1.Controls.Add(this.numericUpDown3);
            this.panel1.Controls.Add(this.numericUpDown2);
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(1043, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(208, 222);
            this.panel1.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "text_linesCount";
            // 
            // numericUpDown6
            // 
            this.numericUpDown6.Location = new System.Drawing.Point(3, 162);
            this.numericUpDown6.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown6.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown6.Name = "numericUpDown6";
            this.numericUpDown6.Size = new System.Drawing.Size(75, 20);
            this.numericUpDown6.TabIndex = 15;
            this.numericUpDown6.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "DEBUG ONLY";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(84, 138);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "timer_killRogueFFPLAY";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(84, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "timer_renameItems";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(84, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "timer_refocusMain";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(84, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "timer_spamParent";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "timer_startSetParent";
            // 
            // numericUpDown5
            // 
            this.numericUpDown5.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown5.Location = new System.Drawing.Point(3, 136);
            this.numericUpDown5.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown5.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown5.Name = "numericUpDown5";
            this.numericUpDown5.Size = new System.Drawing.Size(75, 20);
            this.numericUpDown5.TabIndex = 6;
            this.numericUpDown5.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown5.ValueChanged += new System.EventHandler(this.NumericUpDown5_ValueChanged);
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown4.Location = new System.Drawing.Point(3, 110);
            this.numericUpDown4.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown4.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(75, 20);
            this.numericUpDown4.TabIndex = 5;
            this.numericUpDown4.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDown4.ValueChanged += new System.EventHandler(this.NumericUpDown4_ValueChanged);
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown3.Location = new System.Drawing.Point(3, 84);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(75, 20);
            this.numericUpDown3.TabIndex = 4;
            this.numericUpDown3.Value = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.numericUpDown3.ValueChanged += new System.EventHandler(this.NumericUpDown3_ValueChanged);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown2.Location = new System.Drawing.Point(3, 58);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(75, 20);
            this.numericUpDown2.TabIndex = 3;
            this.numericUpDown2.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.NumericUpDown2_ValueChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(3, 32);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(75, 20);
            this.numericUpDown1.TabIndex = 2;
            this.numericUpDown1.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.NumericUpDown1_ValueChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(87, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Kill FFPLAY";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Load Video";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(207, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(1038, 614);
            this.richTextBox1.TabIndex = 13;
            this.richTextBox1.Text = "";
            // 
            // fontToolStripMenuItem2
            // 
            this.fontToolStripMenuItem2.Name = "fontToolStripMenuItem2";
            this.fontToolStripMenuItem2.Size = new System.Drawing.Size(215, 22);
            this.fontToolStripMenuItem2.Text = "Select Font";
            this.fontToolStripMenuItem2.Click += new System.EventHandler(this.FontToolStripMenuItem2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1251, 740);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.treeView_folders);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.listBox_files);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1";
            this.Text = "ImOrg";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TreeView treeView_folders;
        private System.Windows.Forms.ListBox listBox_files;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel ToolStrip;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem rGBTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rGBBackgroundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allowUPDOWNToRenameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allowAnyFiletypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortFilesByTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem videoScrollingSpeedToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_videoSkipLength;
        private System.Windows.Forms.ToolStripMenuItem renamingTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox_renamingMode;
        private System.Windows.Forms.Timer timer_startSetParent;
        private System.Windows.Forms.Timer timer_spamParent;
        private System.Windows.Forms.Timer timer_refocusMain;
        private System.Windows.Forms.ToolStripMenuItem startVideoMutedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allowFolderHandlingToolStripMenuItem;
        private System.Windows.Forms.Timer timer_renameItems;
        private System.Windows.Forms.Timer timer_killRogueFFPLAY;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numericUpDown5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown6;
        private System.Windows.Forms.ToolStripMenuItem imagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem videosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem directoriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unsupportedToolStripMenuItem;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ToolStripMenuItem fontToolStripMenuItem2;
    }
}

