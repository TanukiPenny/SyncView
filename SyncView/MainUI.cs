using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// using LibVLCSharp.Shared;

namespace SyncView
{
    public partial class MainUI : UserControl
    {

        public MainUI()
        {
            InitializeComponent();

            VideoView_Loaded();
        }

        private void VideoView_Loaded()
        {
            // Core.Initialize();
        }

        public void FinishSetup()
        {
            // videoView.MediaPlayer = Program.SyncViewForm.MediaManager.Player;
        }

        private void testOpenMediaSelector_Click(object sender, EventArgs e)
        {
            MediaSelector mediaSelector = new MediaSelector();
            mediaSelector.ShowDialog();
        }

        private int _tempTime;

        public void VideoLengthUpdate(int length)
        {
            progressBar.Maximum = length;
        }

        public void VideoDataUpdate(long time, long length)
        {
            progressBar.Maximum = (int)length;

            TimeSpan timePassedSpan = TimeSpan.FromMilliseconds(time);
            string timePassedText = timePassedSpan.ToString(@"hh\:mm\:ss");
            timePassed.Text = timePassedText;

            TimeSpan timeLeftSpan = TimeSpan.FromMilliseconds(length - time);
            string timeLeftText = timeLeftSpan.ToString(@"hh\:mm\:ss");
            timeLeft.Text = timeLeftText;

            if (_mouseDown) return;

            progressBar.Value = (int)time;
        }

        private void progressBar_ValueChanged(object sender, EventArgs e)
        {
            _tempTime = progressBar.Value;
        }

        private void progressBar_MouseCaptureChanged(object sender, EventArgs e)
        {
            Program.SyncViewForm.MediaManager.SeekTo(_tempTime);
        }

        private new bool _mouseDown = false;

        private void progressBar_MouseDown(object sender, EventArgs e)
        {
            _mouseDown = true;
        }

        private void progressBar_MouseUp(object sender, EventArgs e)
        {
            _mouseDown = false;
        }

        private void skipBackButton_Click(object sender, EventArgs e)
        {

        }

        private void playButton_Click(object sender, EventArgs e)
        {
            Program.SyncViewForm.MediaManager.Play();
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {

        }

        private void skipForward30Button_Click(object sender, EventArgs e)
        {

        }

        private void stopButton_Click(object sender, EventArgs e)
        {

        }

        private void mediaSelectorButton_Click(object sender, EventArgs e)
        {

        }
    }
}