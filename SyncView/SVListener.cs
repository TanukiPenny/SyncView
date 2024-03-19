using MessagePack;
using SVCommon;
using SVCommon.Packet;

namespace SyncView;

public class SVListener : PacketHandler<SVClient>
{
    public override void OnPing(SVClient conn)
    {
        Console.WriteLine("Ping!");
        Program.SVClient.SendPing();
    }

    public override void OnBasicMessage(SVClient conn, BasicMessage msg)
    {
        throw new NotImplementedException();
    }

    public override void OnLogin(SVClient conn, Login login)
    {
        throw new NotImplementedException();
    }

    public override void OnSerializationException(MessagePackSerializationException exception, int packetID)
    {
        throw new NotImplementedException();    }

    public override void OnByteLengthMismatch(SVClient conn, int readBytes, int totalBytes)
    {
        throw new NotImplementedException();    }

    public override void OnPacketHandlerException(Exception exception, int packetID)
    {
        throw new NotImplementedException();    
    }
}