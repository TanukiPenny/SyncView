using LibVLCSharp.Shared;
using SVCommon.Packet;

namespace SyncView;

public partial class MainForm : Form
{
    public readonly SvClient SvClient = new();
    public readonly MediaManager MediaManager = new();

    public MainForm()
    {
        InitializeComponent();

        VideoView_Loaded();
    }

    private void VideoView_Loaded()
    {
        Core.Initialize();

        videoView.MediaPlayer = MediaManager?.Player;
    }

    private void testPlay_Click(object sender, EventArgs e)
    {
        MediaManager.Play();
    }

    private void testLogin_Click(object sender, EventArgs e)
    {
        SvClient.Connect();
        SvClient.Login(testNickBox.Text);
    }

    private void testOpenMediaSelector_Click(object sender, EventArgs e)
    {
        MediaSelector mediaSelector = new MediaSelector();
        mediaSelector.ShowDialog();
    }

    private int _tempTime;

    public void VideoLengthUpdate(int length)
    {
        ProgressBar.Maximum = length;
    }
    
    public void VideoDataUpdate(long time, long length)
    {
        ProgressBar.Maximum = (int)length;
        
        TimeSpan timePassedSpan = TimeSpan.FromMilliseconds(time);
        string timePassedText = timePassedSpan.ToString(@"hh\:mm\:ss");
        timePassed.Text = timePassedText;
        
        TimeSpan timeLeftSpan = TimeSpan.FromMilliseconds(length - time);
        string timeLeftText = timeLeftSpan.ToString(@"hh\:mm\:ss");
        timeLeft.Text = timeLeftText;
        
        if (MouseDown) return;
        
        ProgressBar.Value = (int)time;
    }

    private void progressBar_ValueChanged(object sender, EventArgs e)
    {
        _tempTime = ProgressBar.Value;
    }

    private void progressBar_MouseCaptureChanged(object sender, EventArgs e)
    {
        MediaManager.SeekTo(_tempTime);
    }

    public new bool MouseDown = false;
    
    private void progressBar_MouseDown(object sender, EventArgs e)
    {
        MouseDown = true;
    }
    
    private void progressBar_MouseUp(object sender, EventArgs e)
    {
        MouseDown = false;
    }
}