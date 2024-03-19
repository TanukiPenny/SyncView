namespace SyncView;

static class Program
{
    public static SVClient SVClient;
    
    [STAThread]
    static void Main()
    {
        SVClient = new SVClient();
        
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }
}