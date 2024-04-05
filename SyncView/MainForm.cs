using System.ComponentModel;
using LibVLCSharp.Shared;
using SVCommon.Packet;

namespace SyncView;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();

        connectedUsersList.DataSource = ConnectedUsers;
        ConnectedUsers.Add(Program.SvClient.Nick);

        VideoView_Loaded();
    }


    private void VideoView_Loaded()
    {
        Core.Initialize();

        videoView.MediaPlayer = Program.MediaManager.Player;
    }

    public readonly BindingList<string> ConnectedUsers = new();

    private int _tempTime;

    public void VideoDataUpdate(long time, long length)
    {
        progressBar.Maximum = (int)length;

        TimeSpan timeLeftSpan = TimeSpan.FromMilliseconds(length - time);
        string timeLeftText = timeLeftSpan.ToString(@"hh\:mm\:ss");
        timeLeft.Text = timeLeftText;

        if (_mouseDown) return;
        
        TimeSpan timePassedSpan = TimeSpan.FromMilliseconds(time);
        string timePassedText = timePassedSpan.ToString(@"hh\:mm\:ss");
        timePassed.Text = timePassedText;

        progressBar.Value = (int)time;
    }

    private void progressBar_ValueChanged(object sender, EventArgs e)
    {
        _tempTime = progressBar.Value;
        if (!_mouseDown) return;
        TimeSpan timePassedSpan = TimeSpan.FromMilliseconds(progressBar.Value);
        string timePassedText = timePassedSpan.ToString(@"hh\:mm\:ss");
        timePassed.Text = timePassedText;
    }
    
    private void progressBar_MouseCaptureChanged(object sender, EventArgs e)
    {
        Program.MediaManager.SeekTo(_tempTime);
    }

    private bool _mouseDown;

    private void progressBar_MouseDown(object sender, EventArgs e)
    {
        _mouseDown = true;
    }

    private void progressBar_MouseUp(object sender, EventArgs e)
    {
        _mouseDown = false;
    }

    private void SkipBack10ButtonClick(object sender, EventArgs e)
    {

    }

    private void playButton_Click(object sender, EventArgs e)
    {
        Program.MediaManager.Play();
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
        MediaSelector mediaSelector = new MediaSelector();
        mediaSelector.ShowDialog();
    }

    private void volumeBar_ValueChanged(object sender, EventArgs e)
    {
        Program.MediaManager.SetVolume(volumeBar.Value);
        volMaxLabel.Text = $"{volumeBar.Value}%";
    }
}