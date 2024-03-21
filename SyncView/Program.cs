namespace SyncView;

static class Program
{
    public static SvClient? SvClient;
    public static MediaManager? MediaManager;
    
    [STAThread]
    static void Main()
    {
        MediaManager = new MediaManager();
        
        SvClient = new SvClient("testing");
        SvClient.Connect();
        
        
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }
}