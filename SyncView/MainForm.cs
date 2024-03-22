using LibVLCSharp.Shared;
using SVCommon.Packet;

namespace SyncView;

public partial class MainForm : Form
{
    public SvClient SvClient;
    public MediaManager? MediaManager;
    
    public MainForm()
    {
        MediaManager = new MediaManager();
        
        SvClient = new SvClient("testing");
        SvClient.Connect();
        
        InitializeComponent();
        
        VideoView_Loaded();
    }
    
    private void VideoView_Loaded()
    {
        Core.Initialize();

        videoView.MediaPlayer = MediaManager?.Player;
        Thread.Sleep(1000);
        MediaManager.Play(MediaManager.MediaLinks.First());
        /*Console.ReadKey();
        var newMedia = new NewMedia();
        newMedia.Uri = MediaManager.MediaLinks[1];*/
    }
}