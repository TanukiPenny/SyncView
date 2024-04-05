using HtmlAgilityPack;
using LibVLCSharp.Shared;
using Serilog;
using SVCommon;
using SVCommon.Packet;

namespace SyncView;

public class MediaManager
{
    public MediaPlayer Player { get; }
    private readonly LibVLC _libVlc = new();
    public Uri? CurrentMedia;
    private Thread? _syncLoopThread;
    private Thread? _timeUpdateThread;
    private bool _stopSync;
    private bool _stopTimeUpdate;

    public MediaManager()
    {
        Player = new(_libVlc);
        Player.Playing += OnPlaying;
    }

    public void NewMediaSelected(Uri uri)
    {
        Stop();
        _stopSync = false;
        _stopTimeUpdate = false;
        CurrentMedia = uri;
    }
    
    private void OnPlaying(object? sender, EventArgs e)
    {
        _timeUpdateThread = new Thread(TimeUpdateLoop);
        _timeUpdateThread.Start();
        if (!Program.SvClient.IsHost) return;
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
        while (!_stopTimeUpdate)
        {
            Program.MainForm?.VideoDataUpdate(Player.Time ,Player.Length);
        }
        _stopTimeUpdate = false;
        Log.Information("Time Update ended");
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
            Program.SvClient?.Send(timeSync, MessageType.TimeSync);
            Thread.Sleep(500);
        }
        _stopSync = false;
        Log.Information("Media time sync ended");
    }
    
    public void Play()
    {
        if (CurrentMedia == null) return;

        Media media = new Media(_libVlc, CurrentMedia);
        
        Player.Play(media);

        if (!Program.SvClient.IsHost) return;
        
        var play = new Play
        {
            Uri = CurrentMedia
        };
        Log.Information("Sending new media");
        Program.SvClient.Send(play, MessageType.Play);
    }
    
    public void Pause()
    {
        _stopSync = Player.IsPlaying;
        _stopTimeUpdate = Player.IsPlaying;
        Player.Pause();
    }
    
    public void Stop()
    {
        _stopSync = true;
        _stopTimeUpdate = true;
        CurrentMedia = null;
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