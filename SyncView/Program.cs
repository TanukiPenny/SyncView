using LibVLCSharp.Shared;
using SVCommon;
using SVCommon.Packet;

namespace SyncView;

static class Program
{
    public static SVClient SVClient;
    public static MediaManager MediaManager;
    
    [STAThread]
    static void Main()
    {
        MediaManager = new MediaManager();
        
        SVClient = new SVClient();
        var login = new Login()
        {
            Nick = "Tester 1"
        };
        SVClient.Send(login, MessageType.Login);
        
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }
}