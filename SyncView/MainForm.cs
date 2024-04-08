using System.ComponentModel;
using LibVLCSharp.Shared;
using SVCommon;
using SVCommon.Packet;

namespace SyncView;

public partial class MainForm : Form
{
    public Label CurrentHostLabel => currentHostLabel;
    public Label CurrentMediaLabel => currentMediaLabel;
    
    public MainForm()
    {
        InitializeComponent();

        connectedUsersList.DataSource = Program.ConnectedUsers;
        Program.ConnectedUsers.Add(Program.SvClient.Nick);

        VideoView_Loaded();
    }
    
    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        base.OnFormClosing(e);

        if (e.CloseReason == CloseReason.WindowsShutDown) return;
        
        // Gotta really make sure its dead
        Application.Exit();    
    }


    private void VideoView_Loaded()
    {
        Core.Initialize();

        videoView.MediaPlayer = Program.MediaManager.Player;
    }

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
        if (!Program.SvClient.IsHost) return;
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
        if (!Program.SvClient.IsHost) return;
        Program.MediaManager.SeekTo(Program.MediaManager.Player.Time - 10000);
    }

    private void playButton_Click(object sender, EventArgs e)
    {
        if (!Program.SvClient.IsHost) return;
        if (Program.MediaManager.Player.IsPlaying) return;
        if (Program.MediaManager.Player.Time > 0)
        {
            Program.MediaManager.Pause();
            return;
        }
        Program.MediaManager.Play();
    }

    private void pauseButton_Click(object sender, EventArgs e)
    {
        if (!Program.MediaManager.Player.IsPlaying) return;
        if (!Program.SvClient.IsHost) return;
        Program.MediaManager.Pause();
        Program.SvClient.Send(new Pause(), MessageType.Pause);
    }

    private void skipForward30Button_Click(object sender, EventArgs e)
    {
        if (!Program.SvClient.IsHost) return;
        Program.MediaManager.SeekTo(Program.MediaManager.Player.Time + 30000);
    }

    private void stopButton_Click(object sender, EventArgs e)
    {
        if (!Program.SvClient.IsHost) return;
        Program.MediaManager.Stop();
        Program.SvClient.Send(new Stop(), MessageType.Stop);
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