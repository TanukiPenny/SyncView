using System.Diagnostics.CodeAnalysis;
using System.Numerics;
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

    public MediaManager()
    {
        Player = new(_libVlc);
        Player.Playing += OnPlaying;
        
        _timeUpdateThread = new Thread(TimeUpdateLoop);
        _timeUpdateThread.Start();
        _syncLoopThread = new Thread(SyncLoop);
        _syncLoopThread.Start();
    }

    public void NewMediaSelected(Uri uri)
    {
        Stop();
        CurrentMedia = uri;
    }
    
    private void OnPlaying(object? sender, EventArgs e)
    {
        if (Program.MainForm == null)
        {
            Log.Warning("Waiting for MainForm to be not null");
            Utils.WaitForMainForm();
        }

        if (!Program.MainForm.IsHandleCreated)
        {
            Log.Warning("Waiting for MainForm handle to be created");
            Utils.WaitForMainFormHandle();
        }
        
        Program.MainForm.Invoke(() =>
        {
            Program.MainForm.CurrentMediaLabel.Text = $"Current Media: {CurrentMedia.ToString()}";
        });
    }
    
    public void HandleTimeSync(TimeSync timeSync)
    {
        Log.Verbose("Handling time sync");
        long dif = Math.Abs(Player.Time - timeSync.Time);
        if (dif > 500)
        {
            SeekTo(timeSync.Time);
        }
    }
    
    private void TimeUpdateLoop()
    {
        Log.Information("Time Update started");
        while (true)
        {
            if (!Player.IsPlaying) continue;
            
            if (Program.MainForm == null)
            {
                Log.Warning("Waiting for MainForm to be not null");
                Utils.WaitForMainForm();
            }

            if (!Program.MainForm.IsHandleCreated)
            {
                Log.Warning("Waiting for MainForm handle to be created");
                Utils.WaitForMainFormHandle();
            }

            Program.MainForm.Invoke(() =>
            {
                Program.MainForm.VideoDataUpdate(Player.Time ,Player.Length);
            });
        }
        // ReSharper disable once FunctionNeverReturns
    }
    
    private void SyncLoop()
    {
        Log.Information("Media time sync started");
        while (true)
        {
            if (!Player.IsPlaying) continue;
            if (!Program.SvClient.IsHost) continue;
            
            Log.Verbose("Sending time sync");
            
            var timeSync = new TimeSync
            {
                Time = Player.Time
            };
            Program.SvClient?.Send(timeSync, MessageType.TimeSync);
            Thread.Sleep(500);
        }
        // ReSharper disable once FunctionNeverReturns
    }
    
    public void Play()
    {
        if (CurrentMedia == null) return;

        Media media = new Media(_libVlc, CurrentMedia);
        Player.Play(media);

        if (!Program.SvClient.IsHost) return;
        
        Log.Information("Sending new media");
        
        var play = new Play
        {
            Uri = CurrentMedia
        };
        Program.SvClient.Send(play, MessageType.Play);
    }
    
    public void Pause()
    {
        Player.Pause();

        if (!Program.SvClient.IsHost) return;
        Program.SvClient.Send(new Pause(), MessageType.Pause);
    }
    
    public void Stop()
    {
        if (Program.MainForm == null)
        {
            Log.Warning("Waiting for MainForm to be not null");
            Utils.WaitForMainForm();
        }

        if (!Program.MainForm.IsHandleCreated)
        {
            Log.Warning("Waiting for MainForm handle to be created");
            Utils.WaitForMainFormHandle();
        }
        
        Program.MainForm.Invoke(() =>
        {
            Program.MainForm.CurrentMediaLabel.Text = "Current Media: None";
        });
        
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