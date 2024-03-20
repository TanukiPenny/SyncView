using SVCommon;
using SVCommon.Packet;

namespace SyncView;

static class Program
{
    public static SVClient SVClient;
    
    [STAThread]
    static void Main()
    {
        SVClient = new SVClient();

        var a = new BasicMessage
        {
            Message = "Testinggg"
        };
        SVClient.Send(a, MessageType.BasicMessage);
        
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }
}