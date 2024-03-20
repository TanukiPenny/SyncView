using MessagePack;
using SVCommon;
using SVCommon.Packet;

namespace SyncView;

public class SVListener : PacketHandler<SVClient>
{
    public override void OnPing(SVClient conn)
    {
        Console.WriteLine("Ping Received!");
        Program.SVClient.SendPing();
    }

    public override void OnBasicMessage(SVClient conn, BasicMessage msg)
    {
        Console.WriteLine(msg);
    }

    public override void OnLogin(SVClient conn, Login login)
    {
        throw new NotImplementedException();
    }

    public override void OnSerializationException(MessagePackSerializationException exception, int packetID)
    {
        Console.WriteLine(exception);    
    }

    public override void OnByteLengthMismatch(SVClient conn, int readBytes, int totalBytes)
    {
        Console.WriteLine(readBytes);   
        Console.WriteLine(totalBytes);   
    }

    public override void OnPacketHandlerException(Exception exception, int packetID)
    {
        Console.WriteLine(exception);   
    }
}