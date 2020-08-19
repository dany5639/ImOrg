using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImOrg
{
    public partial class Main : Form
    {
        #region DLL
        [DllImport("user32.dll")]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
        #endregion
        #region constants and variables
        public string fullpath = "";
        public List<string> fullpaths = new List<string>();
        public Process ffplay = new Process();
        #endregion
        public void log(string in_)
        {
            Console.WriteLine($"[{DateTime.Now.ToString("hh:mm:ss:ffff")}] {in_}");
        }
        private void ffmpeg_setInfo()
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
                $"\"{fullpath}\"" +
                $""; 

            ffplay.StartInfo.CreateNoWindow = true;
            ffplay.StartInfo.RedirectStandardInput = false;
            ffplay.StartInfo.RedirectStandardOutput = false;
            ffplay.StartInfo.UseShellExecute = false;

        }
        public void ffplay_startThread()
        {
            ffplay.Start();
        }
        private void ffplay_Thread()
        {
            var threadStart = new ThreadStart(ffplay_startThread);
            var thread = new Thread(threadStart);
            thread.Start();
        }
        public Main()
        {
            InitializeComponent();

            initializeTimers();
        }
        private void initializeTimers()
        {
            timer_startSetParent.Interval = 100; // ms time between opening ffplay and attempting to attach it to the main window. range: 400-700
            timer_spamParent.Interval = 8; // ms time between each attempt to attach it to the main window; 16 is every frame

            timer_startSetParent.Stop();
            timer_spamParent.Stop();
        }
        private void Timer_startSetParent_Tick(object sender, EventArgs e)
        {
            ffplay_attachVideo();
        }
        private void Timer_spamParent_Tick(object sender, EventArgs e)
        {
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

        }
        private void moveVideoWindow()
        {
            MoveWindow(ffplay.MainWindowHandle,0,0,pictureBox1.Width,pictureBox1.Height,true);
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
            log("ffplay_loadVideo(): ffplay_kill()");
            ffplay_kill(); // don't allow other instances for now, as i can't kill the already existing instance

            log("ffplay_loadVideo(): ffmpeg_setInfo()");
            ffmpeg_setInfo();

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
        private void button_loadVideo_click(object sender, EventArgs e)
        {
            ffplay_loadVideo();
        }
        #region exclussive to this project
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            fullpath = comboBox1.SelectedItem.ToString();
        }
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            var tt = textBox1.Text;
            if (!Directory.Exists(tt))
                return;

            fullpaths = Directory.EnumerateFiles(tt).ToList();

            foreach (var a in fullpaths)
                comboBox1.Items.Add(a);

            if (comboBox1.Items.Count == 0)
                return;

            comboBox1.SelectedIndex = 0;
        }
        #endregion

    }

}
