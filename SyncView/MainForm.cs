using LibVLCSharp.Shared;

namespace SyncView;

public partial class MainForm : Form
{
    public SvClient? SvClient;
    public MediaManager? MediaManager;
    
    public MainForm()
    {
        MediaManager = new MediaManager();
        
        SvClient = new SvClient("testing 1");
        SvClient.Connect();
        
        InitializeComponent();
        
        VideoView_Loaded();
    }
    
    private void VideoView_Loaded()
    {
        Core.Initialize();

        videoView.MediaPlayer = MediaManager?.Player;
    }
}