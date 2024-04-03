using HtmlAgilityPack;
using LibVLCSharp.Shared;
using Serilog;
using SVCommon;
using SVCommon.Packet;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace SyncView;

public class MediaManager
{
    public MediaPlayer Player { get; }
    private readonly LibVLC _libVlc = new();
    public Uri? CurrentMedia;
    private Thread? _syncLoopThread;
    private Thread? _timeUpdateThread;
    private bool _stopSync;

    public MediaManager()
    {
        Player = new(_libVlc);
        Player.Playing += OnPlaying;
    }
    
    private void OnPlaying(object? sender, EventArgs e)
    {
        _timeUpdateThread = new Thread(TimeUpdateLoop);
        _timeUpdateThread.Start();
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
    
    private void TimeUpdateLoop()
    {
        Log.Information("Time Update started");
        while (!_stopSync)
        {
            Program.MainForm.VideoDataUpdate(Player.Time ,Player.Length);
        }
        _stopSync = false;
    }
    
    private void SyncLoop()
    {
        Log.Information("Media time sync started");
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

    public void HandleNewMedia(Uri uri)
    {
        CurrentMedia = uri;
    }
    
    public void Play()
    {
        if (CurrentMedia == null) return;

        Media media = new Media(_libVlc, CurrentMedia);
        
        Player.Play(media);

        if (!Program.MainForm.SvClient.IsHost) return;
        
        var newMedia = new NewMedia
        {
            Uri = CurrentMedia
        };
        Log.Information("Sending new media");
        Program.MainForm.SvClient.Send(newMedia, MessageType.NewMedia);
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
        Console.WriteLine($"seek to {time}");
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