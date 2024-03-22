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
    private bool _stopSync;

    public MediaManager()
    {
        Player = new(_libVlc);
        MediaLinks = RequestAvailableMedia();

        Play(MediaLinks.First());
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
        while (!_stopSync)
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
        HtmlWeb web = new HtmlWeb();
        HtmlDocument? htmlDoc = web.Load("http://15.204.205.117/");
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
        if (uri == null)
        {
            Player.Play();
            return;
        }
    
        Player.Play(new Media(_libVlc, uri));
        
        if (!Program.MainForm.SvClient.IsHost) return;
        _syncLoopThread = new Thread(SyncLoop);
        _syncLoopThread.Start();
    }
    
    public void Pause()
    {
        _stopSync = true;
        Player.Pause();
    }
    
    public void Stop()
    {
        _stopSync = true;
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