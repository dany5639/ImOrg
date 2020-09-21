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
            this.TextToolStripMenuItem_foreColor = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_backColor = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_changeFont = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItem_allowAnyFiletype = new System.Windows.Forms.ToolStripMenuItem();
            this.imagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.directoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unsupportedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_itemSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_settings_text = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox_textLength = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripMenuItem_settings_video = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox_videoFastForwardSeconds = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripMenuItem_startVideoMuted = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_allowUPDOWNToRename = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_sortFilesByType = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox_sortType = new System.Windows.Forms.ToolStripComboBox();
            this.ToolStripMenuItem_renamingType = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox_renamingMode = new System.Windows.Forms.ToolStripComboBox();
            this.ToolStripMenuItem_info = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStrip = new System.Windows.Forms.ToolStripStatusLabel();
            this.howManyLinesToReadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer_startSetParent = new System.Windows.Forms.Timer(this.components);
            this.timer_spamParent = new System.Windows.Forms.Timer(this.components);
            this.timer_refocusMain = new System.Windows.Forms.Timer(this.components);
            this.timer_renameItems = new System.Windows.Forms.Timer(this.components);
            this.timer_killRogueFFPLAY = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDown_key = new System.Windows.Forms.NumericUpDown();
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
            this.timer_checkForeground = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_key)).BeginInit();
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
            this.TextToolStripMenuItem_foreColor,
            this.ToolStripMenuItem_backColor,
            this.ToolStripMenuItem_changeFont,
            this.toolStripSeparator1,
            this.ToolStripMenuItem_allowAnyFiletype,
            this.toolStripMenuItem_itemSettings,
            this.ToolStripMenuItem_allowUPDOWNToRename,
            this.ToolStripMenuItem_sortFilesByType,
            this.ToolStripMenuItem_renamingType,
            this.ToolStripMenuItem_info});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 20);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // TextToolStripMenuItem_foreColor
            // 
            this.TextToolStripMenuItem_foreColor.Name = "TextToolStripMenuItem_foreColor";
            this.TextToolStripMenuItem_foreColor.Size = new System.Drawing.Size(215, 22);
            this.TextToolStripMenuItem_foreColor.Text = "RGB Text";
            this.TextToolStripMenuItem_foreColor.Click += new System.EventHandler(this.RGBTextToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem_backColor
            // 
            this.ToolStripMenuItem_backColor.Name = "ToolStripMenuItem_backColor";
            this.ToolStripMenuItem_backColor.Size = new System.Drawing.Size(215, 22);
            this.ToolStripMenuItem_backColor.Text = "RGB Background";
            this.ToolStripMenuItem_backColor.Click += new System.EventHandler(this.RGBBackgroundToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem_changeFont
            // 
            this.ToolStripMenuItem_changeFont.Name = "ToolStripMenuItem_changeFont";
            this.ToolStripMenuItem_changeFont.Size = new System.Drawing.Size(215, 22);
            this.ToolStripMenuItem_changeFont.Text = "Select Font";
            this.ToolStripMenuItem_changeFont.Click += new System.EventHandler(this.FontToolStripMenuItem2_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(212, 6);
            // 
            // ToolStripMenuItem_allowAnyFiletype
            // 
            this.ToolStripMenuItem_allowAnyFiletype.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imagesToolStripMenuItem,
            this.videosToolStripMenuItem,
            this.textToolStripMenuItem,
            this.directoriesToolStripMenuItem,
            this.unsupportedToolStripMenuItem});
            this.ToolStripMenuItem_allowAnyFiletype.Name = "ToolStripMenuItem_allowAnyFiletype";
            this.ToolStripMenuItem_allowAnyFiletype.Size = new System.Drawing.Size(215, 22);
            this.ToolStripMenuItem_allowAnyFiletype.Text = "View item types";
            // 
            // imagesToolStripMenuItem
            // 
            this.imagesToolStripMenuItem.Checked = true;
            this.imagesToolStripMenuItem.CheckOnClick = true;
            this.imagesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.imagesToolStripMenuItem.Name = "imagesToolStripMenuItem";
            this.imagesToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.imagesToolStripMenuItem.Text = "Show images";
            // 
            // videosToolStripMenuItem
            // 
            this.videosToolStripMenuItem.Checked = true;
            this.videosToolStripMenuItem.CheckOnClick = true;
            this.videosToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.videosToolStripMenuItem.Name = "videosToolStripMenuItem";
            this.videosToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.videosToolStripMenuItem.Text = "Show videos";
            // 
            // textToolStripMenuItem
            // 
            this.textToolStripMenuItem.Checked = true;
            this.textToolStripMenuItem.CheckOnClick = true;
            this.textToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.textToolStripMenuItem.Name = "textToolStripMenuItem";
            this.textToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.textToolStripMenuItem.Text = "Show text files";
            // 
            // directoriesToolStripMenuItem
            // 
            this.directoriesToolStripMenuItem.CheckOnClick = true;
            this.directoriesToolStripMenuItem.Name = "directoriesToolStripMenuItem";
            this.directoriesToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.directoriesToolStripMenuItem.Text = "Show directories/folders";
            // 
            // unsupportedToolStripMenuItem
            // 
            this.unsupportedToolStripMenuItem.CheckOnClick = true;
            this.unsupportedToolStripMenuItem.Name = "unsupportedToolStripMenuItem";
            this.unsupportedToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.unsupportedToolStripMenuItem.Text = "Show unsupported formats";
            // 
            // toolStripMenuItem_itemSettings
            // 
            this.toolStripMenuItem_itemSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_settings_text,
            this.toolStripMenuItem_settings_video,
            this.toolStripMenuItem_startVideoMuted});
            this.toolStripMenuItem_itemSettings.Name = "toolStripMenuItem_itemSettings";
            this.toolStripMenuItem_itemSettings.Size = new System.Drawing.Size(215, 22);
            this.toolStripMenuItem_itemSettings.Text = "Item types settings";
            // 
            // toolStripMenuItem_settings_text
            // 
            this.toolStripMenuItem_settings_text.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox_textLength});
            this.toolStripMenuItem_settings_text.Name = "toolStripMenuItem_settings_text";
            this.toolStripMenuItem_settings_text.Size = new System.Drawing.Size(219, 22);
            this.toolStripMenuItem_settings_text.Text = "Text lines count";
            // 
            // toolStripTextBox_textLength
            // 
            this.toolStripTextBox_textLength.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox_textLength.Name = "toolStripTextBox_textLength";
            this.toolStripTextBox_textLength.Size = new System.Drawing.Size(100, 23);
            // 
            // toolStripMenuItem_settings_video
            // 
            this.toolStripMenuItem_settings_video.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox_videoFastForwardSeconds});
            this.toolStripMenuItem_settings_video.Name = "toolStripMenuItem_settings_video";
            this.toolStripMenuItem_settings_video.Size = new System.Drawing.Size(219, 22);
            this.toolStripMenuItem_settings_video.Text = "Fast forward seconds count";
            // 
            // toolStripTextBox_videoFastForwardSeconds
            // 
            this.toolStripTextBox_videoFastForwardSeconds.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox_videoFastForwardSeconds.Name = "toolStripTextBox_videoFastForwardSeconds";
            this.toolStripTextBox_videoFastForwardSeconds.Size = new System.Drawing.Size(100, 23);
            // 
            // toolStripMenuItem_startVideoMuted
            // 
            this.toolStripMenuItem_startVideoMuted.CheckOnClick = true;
            this.toolStripMenuItem_startVideoMuted.Name = "toolStripMenuItem_startVideoMuted";
            this.toolStripMenuItem_startVideoMuted.Size = new System.Drawing.Size(219, 22);
            this.toolStripMenuItem_startVideoMuted.Text = "Start video muted";
            // 
            // ToolStripMenuItem_allowUPDOWNToRename
            // 
            this.ToolStripMenuItem_allowUPDOWNToRename.Checked = true;
            this.ToolStripMenuItem_allowUPDOWNToRename.CheckOnClick = true;
            this.ToolStripMenuItem_allowUPDOWNToRename.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ToolStripMenuItem_allowUPDOWNToRename.Name = "ToolStripMenuItem_allowUPDOWNToRename";
            this.ToolStripMenuItem_allowUPDOWNToRename.Size = new System.Drawing.Size(215, 22);
            this.ToolStripMenuItem_allowUPDOWNToRename.Text = "Allow Up/Down to rename";
            // 
            // ToolStripMenuItem_sortFilesByType
            // 
            this.ToolStripMenuItem_sortFilesByType.CheckOnClick = true;
            this.ToolStripMenuItem_sortFilesByType.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox_sortType});
            this.ToolStripMenuItem_sortFilesByType.Name = "ToolStripMenuItem_sortFilesByType";
            this.ToolStripMenuItem_sortFilesByType.Size = new System.Drawing.Size(215, 22);
            this.ToolStripMenuItem_sortFilesByType.Text = "Sort files by type";
            // 
            // toolStripComboBox_sortType
            // 
            this.toolStripComboBox_sortType.Items.AddRange(new object[] {
            "A-Z Ascending",
            "A-Z Descending",
            "Type/Extension Ascending",
            "Type/Extension Descending",
            "Size Ascending",
            "Size Descending"});
            this.toolStripComboBox_sortType.Name = "toolStripComboBox_sortType";
            this.toolStripComboBox_sortType.Size = new System.Drawing.Size(121, 23);
            // 
            // ToolStripMenuItem_renamingType
            // 
            this.ToolStripMenuItem_renamingType.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox_renamingMode});
            this.ToolStripMenuItem_renamingType.Name = "ToolStripMenuItem_renamingType";
            this.ToolStripMenuItem_renamingType.Size = new System.Drawing.Size(215, 22);
            this.ToolStripMenuItem_renamingType.Text = "Renaming type";
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
            // ToolStripMenuItem_info
            // 
            this.ToolStripMenuItem_info.Name = "ToolStripMenuItem_info";
            this.ToolStripMenuItem_info.Size = new System.Drawing.Size(215, 22);
            this.ToolStripMenuItem_info.Text = "Info";
            this.ToolStripMenuItem_info.Click += new System.EventHandler(this.ToolStripMenuItem1_Click);
            // 
            // ToolStrip
            // 
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Size = new System.Drawing.Size(26, 17);
            this.ToolStrip.Text = "Idle";
            this.ToolStrip.Click += new System.EventHandler(this.ToolStrip_Click);
            // 
            // howManyLinesToReadToolStripMenuItem
            // 
            this.howManyLinesToReadToolStripMenuItem.Name = "howManyLinesToReadToolStripMenuItem";
            this.howManyLinesToReadToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.howManyLinesToReadToolStripMenuItem.Text = "How many lines to read:";
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
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.numericUpDown_key);
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
            this.panel1.Size = new System.Drawing.Size(208, 269);
            this.panel1.TabIndex = 12;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(0, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(84, 212);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "key_index";
            // 
            // numericUpDown_key
            // 
            this.numericUpDown_key.Location = new System.Drawing.Point(0, 0);
            this.numericUpDown_key.Name = "numericUpDown_key";
            this.numericUpDown_key.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_key.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "text_linesCount";
            // 
            // numericUpDown6
            // 
            this.numericUpDown6.Location = new System.Drawing.Point(3, 184);
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
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "DEBUG ONLY. Click bottom text to yeet it";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(84, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "timer_killRogueFFPLAY";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(84, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "timer_renameItems";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(84, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "timer_refocusMain";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(84, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "timer_spamParent";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 56);
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
            this.numericUpDown5.Location = new System.Drawing.Point(3, 158);
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
            this.numericUpDown4.Location = new System.Drawing.Point(3, 132);
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
            this.numericUpDown3.Location = new System.Drawing.Point(3, 106);
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
            this.numericUpDown2.Location = new System.Drawing.Point(3, 80);
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
            this.numericUpDown1.Location = new System.Drawing.Point(3, 54);
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
            this.button2.Location = new System.Drawing.Point(87, 25);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Kill FFPLAY";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 25);
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
            // timer_checkForeground
            // 
            this.timer_checkForeground.Tick += new System.EventHandler(this.timer_checkForeground_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1251, 740);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.treeView_folders);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.listBox_files);
            this.Controls.Add(this.pictureBox1);
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
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_key)).EndInit();
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
        private System.Windows.Forms.ToolStripMenuItem TextToolStripMenuItem_foreColor;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_backColor;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_allowUPDOWNToRename;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_allowAnyFiletype;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_sortFilesByType;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_info;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_renamingType;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox_renamingMode;
        private System.Windows.Forms.Timer timer_startSetParent;
        private System.Windows.Forms.Timer timer_spamParent;
        private System.Windows.Forms.Timer timer_refocusMain;
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
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_changeFont;
        private System.Windows.Forms.ToolStripMenuItem howManyLinesToReadToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_textLength;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_itemSettings;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_settings_text;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_settings_video;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_videoFastForwardSeconds;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox_sortType;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_startVideoMuted;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDown_key;
        private System.Windows.Forms.Timer timer_checkForeground;
    }
}

