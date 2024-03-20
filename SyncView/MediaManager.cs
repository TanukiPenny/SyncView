using LibVLCSharp.Shared;

namespace SyncView;

public class MediaManager
{
    public MediaPlayer Player { get; }
    private readonly LibVLC _libVlc = new();

    public MediaManager()
    {
        Player = new(_libVlc);
    }

    public void Play(Uri? uri = null)
    {
        if (uri == null)
        {
            Player.Play();
            return;
        }
        Player.Play(new Media(_libVlc, uri));
    }

    public void Pause()
    {
        Player.Pause();
    }

    public void Stop()
    {
        Player.Stop();
        
    }

    public void SeekTo(TimeSpan timeSpan)
    {
        Player.SeekTo(timeSpan);
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