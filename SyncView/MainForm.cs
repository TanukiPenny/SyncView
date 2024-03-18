using LibVLCSharp.Shared;

namespace SyncView;

public partial class MainForm : Form
{
    LibVLC _libVLC;
    MediaPlayer _mediaPlayer;
    
    public MainForm()
    {
        InitializeComponent();
        
        VideoView_Loaded();
    }
    
    private void VideoView_Loaded()
    {
        Core.Initialize();
        Console.WriteLine("Core Init");
        
        _libVLC = new LibVLC();
        _mediaPlayer = new MediaPlayer(_libVLC);

        videoView.MediaPlayer = _mediaPlayer;

        _mediaPlayer.Play(new Media(_libVLC, new Uri("http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4")));
        Console.WriteLine("Test Play");
    }
}