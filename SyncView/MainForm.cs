using LibVLCSharp.Shared;

namespace SyncView;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
        
        VideoView_Loaded();
    }
    
    private void VideoView_Loaded()
    {
        Core.Initialize();

        videoView.MediaPlayer = Program.MediaManager?.Player;
    }
}