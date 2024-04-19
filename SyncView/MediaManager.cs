// PB start
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
        
        // Add callback for OnPlaying
        Player.Playing += OnPlaying;
        
        // Start threads for syncing
        _timeUpdateThread = new Thread(TimeUpdateLoop);
        _timeUpdateThread.Start();
        _syncLoopThread = new Thread(SyncLoop);
        _syncLoopThread.Start();
    }

    // Stop and set new media
    public void NewMediaSelected(Uri uri)
    {
        Stop();
        CurrentMedia = uri;
    }
    
    // Triggers when playback starts
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
        
        // Set proper media label
        Program.MainForm.Invoke(() =>
        {
            Program.MainForm.CurrentMediaLabel.Text = $"Current Media: {CurrentMedia.ToString()}";
        });
    }
    
    // Correct playback time
    public void HandleTimeSync(TimeSync timeSync)
    {
        Log.Verbose("Handling time sync");
        long dif = Math.Abs(Player.Time - timeSync.Time);
        if (dif > 500)
        {
            SeekTo(timeSync.Time);
        }
    }
    
    // Runs in a thread to update the time display
    private void TimeUpdateLoop()
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
        
        Log.Information("Time Update started");
        while (true)
        {
            if (!Player.IsPlaying) continue;

            // Update the time display
            Program.MainForm.Invoke(() =>
            {
                Program.MainForm.VideoDataUpdate(Player.Time ,Player.Length);
            });
            Thread.Sleep(500);
        }
        // ReSharper disable once FunctionNeverReturns
    }
    
    // Runs in a thread to send syncing data
    private void SyncLoop()
    {
        Log.Information("Media time sync started");
        while (true)
        {
            // Only run is we are playing and are host
            if (!Player.IsPlaying) continue;
            if (!Program.SvClient.IsHost) continue;
            
            Log.Verbose("Sending time sync");
            
            // Send da time sync
            var timeSync = new TimeSync
            {
                Time = Player.Time
            };
            Program.SvClient?.Send(timeSync, MessageType.TimeSync);
            Thread.Sleep(500);
        }
        // ReSharper disable once FunctionNeverReturns
    }
    
    // Plays da media
    public void Play()
    {
        // Don't if media is null
        if (CurrentMedia == null) return;
        
        Media media = new Media(_libVlc, CurrentMedia);
        Player.Play(media);

        // If we are host we stop here
        if (!Program.SvClient.IsHost) return;
        
        Log.Information("Sending new media");
        
        // Send new media to other users
        var play = new Play
        {
            Uri = CurrentMedia
        };
        Program.SvClient.Send(play, MessageType.Play);
    }
    
    public void Pause()
    {
        Player.Pause();

        // Only send pause if we are host
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
        
        // Reset media label
        Program.MainForm.Invoke(() =>
        {
            Program.MainForm.CurrentMediaLabel.Text = "Current Media: None";
        });
        
        // Actually stop the player
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
// PB end