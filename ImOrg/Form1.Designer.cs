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
                components.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.treeView_folders = new System.Windows.Forms.TreeView();
            this.listBox_files = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.pictureSizeModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.centerImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stretchImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keySettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allowUPDOWNToRenameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allowAnyFiletypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rGBTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rGBBackgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView_folders
            // 
            this.treeView_folders.AllowDrop = true;
            this.treeView_folders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView_folders.Location = new System.Drawing.Point(0, 0);
            this.treeView_folders.Name = "treeView_folders";
            this.treeView_folders.Size = new System.Drawing.Size(201, 516);
            this.treeView_folders.TabIndex = 1;
            this.treeView_folders.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.TreeView1_BeforeExpand);
            this.treeView_folders.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView1_AfterSelect);
            // 
            // listBox_files
            // 
            this.listBox_files.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_files.FormattingEnabled = true;
            this.listBox_files.Location = new System.Drawing.Point(0, 514);
            this.listBox_files.Name = "listBox_files";
            this.listBox_files.Size = new System.Drawing.Size(1242, 56);
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
            this.pictureBox1.Size = new System.Drawing.Size(1035, 516);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
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
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(1035, 516);
            this.axWindowsMediaPlayer1.TabIndex = 10;
            this.axWindowsMediaPlayer1.StatusChange += new System.EventHandler(this.AxWindowsMediaPlayer1_StatusChange);
            this.axWindowsMediaPlayer1.Enter += new System.EventHandler(this.AxWindowsMediaPlayer1_Enter);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 573);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1242, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pictureSizeModeToolStripMenuItem,
            this.keySettingsToolStripMenuItem,
            this.fileSettingsToolStripMenuItem,
            this.rGBTextToolStripMenuItem,
            this.rGBBackgroundToolStripMenuItem,
            this.testToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 20);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // pictureSizeModeToolStripMenuItem
            // 
            this.pictureSizeModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomToolStripMenuItem,
            this.normalToolStripMenuItem,
            this.autoSizeToolStripMenuItem,
            this.centerImageToolStripMenuItem,
            this.stretchImageToolStripMenuItem});
            this.pictureSizeModeToolStripMenuItem.Name = "pictureSizeModeToolStripMenuItem";
            this.pictureSizeModeToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.pictureSizeModeToolStripMenuItem.Text = "Picture Size Mode";
            // 
            // zoomToolStripMenuItem
            // 
            this.zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
            this.zoomToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.zoomToolStripMenuItem.Text = "Zoom";
            this.zoomToolStripMenuItem.Click += new System.EventHandler(this.ZoomToolStripMenuItem_Click);
            // 
            // normalToolStripMenuItem
            // 
            this.normalToolStripMenuItem.Name = "normalToolStripMenuItem";
            this.normalToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.normalToolStripMenuItem.Text = "Normal";
            this.normalToolStripMenuItem.Click += new System.EventHandler(this.NormalToolStripMenuItem_Click);
            // 
            // autoSizeToolStripMenuItem
            // 
            this.autoSizeToolStripMenuItem.Name = "autoSizeToolStripMenuItem";
            this.autoSizeToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.autoSizeToolStripMenuItem.Text = "Auto Size";
            this.autoSizeToolStripMenuItem.Click += new System.EventHandler(this.AutoSizeToolStripMenuItem_Click);
            // 
            // centerImageToolStripMenuItem
            // 
            this.centerImageToolStripMenuItem.Name = "centerImageToolStripMenuItem";
            this.centerImageToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.centerImageToolStripMenuItem.Text = "Center Image";
            this.centerImageToolStripMenuItem.Click += new System.EventHandler(this.CenterImageToolStripMenuItem_Click);
            // 
            // stretchImageToolStripMenuItem
            // 
            this.stretchImageToolStripMenuItem.Name = "stretchImageToolStripMenuItem";
            this.stretchImageToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.stretchImageToolStripMenuItem.Text = "Stretch Image";
            this.stretchImageToolStripMenuItem.Click += new System.EventHandler(this.StretchImageToolStripMenuItem_Click);
            // 
            // keySettingsToolStripMenuItem
            // 
            this.keySettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allowUPDOWNToRenameToolStripMenuItem});
            this.keySettingsToolStripMenuItem.Name = "keySettingsToolStripMenuItem";
            this.keySettingsToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.keySettingsToolStripMenuItem.Text = "Key settings";
            // 
            // allowUPDOWNToRenameToolStripMenuItem
            // 
            this.allowUPDOWNToRenameToolStripMenuItem.Checked = true;
            this.allowUPDOWNToRenameToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.allowUPDOWNToRenameToolStripMenuItem.Name = "allowUPDOWNToRenameToolStripMenuItem";
            this.allowUPDOWNToRenameToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.allowUPDOWNToRenameToolStripMenuItem.Text = "Allow Up/Down to rename";
            // 
            // fileSettingsToolStripMenuItem
            // 
            this.fileSettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allowAnyFiletypeToolStripMenuItem});
            this.fileSettingsToolStripMenuItem.Name = "fileSettingsToolStripMenuItem";
            this.fileSettingsToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.fileSettingsToolStripMenuItem.Text = "File settings";
            // 
            // allowAnyFiletypeToolStripMenuItem
            // 
            this.allowAnyFiletypeToolStripMenuItem.Name = "allowAnyFiletypeToolStripMenuItem";
            this.allowAnyFiletypeToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.allowAnyFiletypeToolStripMenuItem.Text = "Allow any filetype";
            // 
            // rGBTextToolStripMenuItem
            // 
            this.rGBTextToolStripMenuItem.Name = "rGBTextToolStripMenuItem";
            this.rGBTextToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.rGBTextToolStripMenuItem.Text = "RGB Text";
            this.rGBTextToolStripMenuItem.Click += new System.EventHandler(this.RGBTextToolStripMenuItem_Click);
            // 
            // rGBBackgroundToolStripMenuItem
            // 
            this.rGBBackgroundToolStripMenuItem.Name = "rGBBackgroundToolStripMenuItem";
            this.rGBBackgroundToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.rGBBackgroundToolStripMenuItem.Text = "RGB Background";
            this.rGBBackgroundToolStripMenuItem.Click += new System.EventHandler(this.RGBBackgroundToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.testToolStripMenuItem.Text = "Test";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.TestToolStripMenuItem_Click);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(26, 17);
            this.toolStripStatusLabel1.Text = "Idle";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 595);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.listBox_files);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.treeView_folders);
            this.Name = "Form1";
            this.Text = "ImOrg";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TreeView treeView_folders;
        private System.Windows.Forms.ListBox listBox_files;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ColorDialog colorDialog1; 
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem pictureSizeModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rGBTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rGBBackgroundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem centerImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stretchImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keySettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allowUPDOWNToRenameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allowAnyFiletypeToolStripMenuItem;
    }
}

