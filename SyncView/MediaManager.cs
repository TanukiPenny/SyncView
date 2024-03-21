using LibVLCSharp.Shared;

namespace SyncView;

public class MediaManager
{
    public MediaPlayer Player { get; }
    private readonly LibVLC _libVlc = new();

    public MediaManager()
    {
        Player = new(_libVlc);

        Play(new Uri("http://15.204.205.117/Ferrari%20Swapped%20Subaru%20at%20the%202023%20Oregon%20Trail%20Rally%20-%20SS5%20Full%20Stage-%282160p24%29.mp4"));
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