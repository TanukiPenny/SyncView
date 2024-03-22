using HtmlAgilityPack;
using LibVLCSharp.Shared;
using SVCommon;
using SVCommon.Packet;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace SyncView;

public class MediaManager
{
    public MediaPlayer Player { get; }
    private readonly LibVLC _libVlc = new();
    private List<Uri> MediaLinks;
    private Thread? _syncLoopThread;
    private bool _stopSync = false;
    private bool _paused = false;

    public MediaManager()
    {
        Player = new(_libVlc);
        MediaLinks = RequestAvailableMedia();

        Player.Playing += OnPlaying;
        Player.Stopped += OnStopped;

        Play(MediaLinks.First());
    }
    
    private void OnStopped(object? sender, EventArgs e)
    {
        _stopSync = true;
    }
    
    private void OnPlaying(object? sender, EventArgs e)
    {
        if (!Program.MainForm.SvClient.IsHost) return;
        _syncLoopThread = new Thread(SyncLoop);
        _syncLoopThread.Start();
    }
    
    public void HandleTimeSync(TimeSync timeSync)
    {
        long dif = Math.Abs(Player.Time - timeSync.Time);
        if (dif > 500)
        {
            SeekTo(timeSync.Time);
        }
    }
    
    private void SyncLoop()
    {
        while (!_paused || !_stopSync)
        {
            var timeSync = new TimeSync
            {
                Time = Player.Time
            };
            Program.MainForm.SvClient?.Send(timeSync, MessageType.TimeSync);
            Thread.Sleep(500);
        }
    
        _stopSync = false;
    }
    
    public List<Uri> RequestAvailableMedia()
    {
        string html = @"http://15.204.205.117/";
        HtmlWeb web = new HtmlWeb();
        HtmlDocument? htmlDoc = web.Load(html);
        HtmlNodeCollection? nodes = htmlDoc.DocumentNode.SelectNodes("//a");
        nodes.RemoveAt(0);
        List<Uri> uris = new();
        foreach (HtmlNode htmlNode in nodes)
        {
            uris.Add(new Uri($"http://15.204.205.117/{htmlNode.Attributes.First().Value}"));
        }
    
        return uris;
    }
    
    public void Play(Uri? uri = null)
    {
        _paused = false;
        _stopSync = false;
        if (uri == null)
        {
            Player.Play();
            return;
        }
    
        Player.Play(new Media(_libVlc, uri));
    }
    
    public void Pause()
    {
        _paused = true;
        Player.Pause();
    }
    
    public void Stop()
    {
        Player.Stop();
    }
    
    public void SeekTo(long time)
    {
        Player.Time = time;
    }
    
    public void SetVolume(int volume)
    {
        Player.Volume = volume;
    }
    
    public void ToggleFullscreen()
    {
        Player.ToggleFullscreen();
    }
    
    public void ToggleMute()
    {
        Player.ToggleMute();
    }
}