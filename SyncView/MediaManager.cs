using HtmlAgilityPack;
using LibVLCSharp.Shared;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace SyncView;

public class MediaManager
{
    public MediaPlayer Player { get; }
    private readonly LibVLC _libVlc = new();
    private List<Uri> MediaLinks;

    public MediaManager()
    {
        Player = new(_libVlc);
        MediaLinks = RequestAvailableMedia();

        Play(MediaLinks.First());
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