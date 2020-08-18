namespace ImOrg
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer_startSetParent = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown_startSetParent = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_spamParent = new System.Windows.Forms.NumericUpDown();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button_loadVideo = new System.Windows.Forms.Button();
            this.timer_spamParent = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_startSetParent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_spamParent)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(768, 480);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Resize += new System.EventHandler(this.PictureBox1_Resize);
            // 
            // timer_startSetParent
            // 
            this.timer_startSetParent.Tick += new System.EventHandler(this.Timer_startSetParent_Tick);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 556);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Delay before first attach";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 530);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Delay between attaches";
            // 
            // numericUpDown_startSetParent
            // 
            this.numericUpDown_startSetParent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDown_startSetParent.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown_startSetParent.Location = new System.Drawing.Point(12, 554);
            this.numericUpDown_startSetParent.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_startSetParent.Name = "numericUpDown_startSetParent";
            this.numericUpDown_startSetParent.Size = new System.Drawing.Size(75, 20);
            this.numericUpDown_startSetParent.TabIndex = 10;
            this.numericUpDown_startSetParent.ValueChanged += new System.EventHandler(this.NumericUpDown3_ValueChanged);
            // 
            // numericUpDown_spamParent
            // 
            this.numericUpDown_spamParent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDown_spamParent.Location = new System.Drawing.Point(12, 528);
            this.numericUpDown_spamParent.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.numericUpDown_spamParent.Name = "numericUpDown_spamParent";
            this.numericUpDown_spamParent.Size = new System.Drawing.Size(75, 20);
            this.numericUpDown_spamParent.TabIndex = 9;
            this.numericUpDown_spamParent.ValueChanged += new System.EventHandler(this.NumericUpDown2_ValueChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 580);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(769, 21);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // button_loadVideo
            // 
            this.button_loadVideo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_loadVideo.Location = new System.Drawing.Point(12, 499);
            this.button_loadVideo.Name = "button_loadVideo";
            this.button_loadVideo.Size = new System.Drawing.Size(75, 23);
            this.button_loadVideo.TabIndex = 5;
            this.button_loadVideo.Text = "loadVideo";
            this.button_loadVideo.UseVisualStyleBackColor = true;
            this.button_loadVideo.Click += new System.EventHandler(this.button_loadVideo_click);
            // 
            // timer_spamParent
            // 
            this.timer_spamParent.Tick += new System.EventHandler(this.Timer_spamParent_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 613);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown_startSetParent);
            this.Controls.Add(this.numericUpDown_spamParent);
            this.Controls.Add(this.button_loadVideo);
            this.Name = "Main";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_startSetParent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_spamParent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer_startSetParent;
        private System.Windows.Forms.Timer timer_spamParent;
        private System.Windows.Forms.Button button_loadVideo;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown_spamParent;
        private System.Windows.Forms.NumericUpDown numericUpDown_startSetParent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}

