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
            this.allowUPDOWNToRenameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortFilesByTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renamingTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox_renamingMode = new System.Windows.Forms.ToolStripComboBox();
            this.videoScrollingSpeedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox_videoSkipLength = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStrip = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerVideo = new System.Windows.Forms.Timer(this.components);
            this.button_debug_rename = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.timerRename = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
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
            this.toolStripSeparator1,
            this.allowAnyFiletypeToolStripMenuItem,
            this.allowUPDOWNToRenameToolStripMenuItem,
            this.sortFilesByTypeToolStripMenuItem,
            this.renamingTypeToolStripMenuItem,
            this.videoScrollingSpeedToolStripMenuItem,
            this.toolStripMenuItem1});
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
            this.allowAnyFiletypeToolStripMenuItem.CheckOnClick = true;
            this.allowAnyFiletypeToolStripMenuItem.Name = "allowAnyFiletypeToolStripMenuItem";
            this.allowAnyFiletypeToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.allowAnyFiletypeToolStripMenuItem.Text = "Allow any filetype";
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
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(215, 22);
            this.toolStripMenuItem1.Text = "Info";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.ToolStripMenuItem1_Click);
            // 
            // ToolStrip
            // 
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Size = new System.Drawing.Size(26, 17);
            this.ToolStrip.Text = "Idle";
            this.ToolStrip.Click += new System.EventHandler(this.ToolStrip_Click);
            // 
            // timer1
            // 
            this.timerVideo.Enabled = true;
            this.timerVideo.Interval = 1000;
            this.timerVideo.Tick += new System.EventHandler(this.TimerVideo_Tick);
            // 
            // button_debug_rename
            // 
            this.button_debug_rename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_debug_rename.BackColor = System.Drawing.Color.Black;
            this.button_debug_rename.Location = new System.Drawing.Point(1050, 713);
            this.button_debug_rename.Name = "button_debug_rename";
            this.button_debug_rename.Size = new System.Drawing.Size(201, 27);
            this.button_debug_rename.TabIndex = 12;
            this.button_debug_rename.Text = "Akward debug button to manually move";
            this.button_debug_rename.UseVisualStyleBackColor = false;
            this.button_debug_rename.Visible = false;
            this.button_debug_rename.Click += new System.EventHandler(this.Button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(207, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1044, 614);
            this.richTextBox1.TabIndex = 13;
            this.richTextBox1.Text = "";
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(207, 0);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(1044, 614);
            this.axWindowsMediaPlayer1.TabIndex = 10;
            this.axWindowsMediaPlayer1.StatusChange += new System.EventHandler(this.AxWindowsMediaPlayer1_StatusChange);
            // 
            // timer2
            // 
            this.timerRename.Enabled = true;
            this.timerRename.Interval = 1000;
            this.timerRename.Tick += new System.EventHandler(this.TimerRename_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1251, 740);
            this.Controls.Add(this.treeView_folders);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button_debug_rename);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.listBox_files);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "ImOrg";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
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
        private System.Windows.Forms.Timer timerVideo;
        private System.Windows.Forms.Button button_debug_rename;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.ToolStripMenuItem sortFilesByTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem videoScrollingSpeedToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_videoSkipLength;
        private System.Windows.Forms.ToolStripMenuItem renamingTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox_renamingMode;
        private System.Windows.Forms.Timer timerRename;
    }
}

