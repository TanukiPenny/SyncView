using SVCommon;

namespace SyncView;

public class SVListener : PacketHandler<SVClient>
{
    private SVClient _svClient;
    
    public override void OnPing(SVClient conn)
    {
        _svClient = new SVClient();
        
        Console.WriteLine("Ping!");
        Program.SVClient.SendPing();
    }
}