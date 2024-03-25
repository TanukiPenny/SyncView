using LibVLCSharp.Shared;
using SVCommon.Packet;

namespace SyncView;

public partial class MainForm : Form
{
    public readonly SvClient SvClient = new();
    public readonly MediaManager MediaManager = new();

    public MainForm()
    {
        SvClient.Connect();
        SvClient.Login("testimggggg");

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
        MediaManager?.Play(MediaManager.MediaLinks.First());
    }
}