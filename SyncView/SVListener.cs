using MessagePack;
using SVCommon;
using SVCommon.Packet;

namespace SyncView;

public class SvListener : PacketHandler<SvClient>
{
    public override void OnPing(SvClient conn)
    {
        conn.SendPing();
    }

    public override void OnBasicMessage(SvClient conn, BasicMessage msg)
    {
        Console.WriteLine(msg);
    }

    public override void OnLoginResponse(SvClient conn, LoginResponse loginResponse)
    {
        if (!loginResponse.Success) return;
        conn.IsHost = loginResponse.Host;
    }

    public override void OnDisconnectMessage(SvClient conn, DisconnectMessage disconnectMessage)
    {
        
    }

    public override void OnHostChange(SvClient conn, HostChange hostChange)
    {
        
    }

    public override void OnUserJoin(SvClient conn, UserJoin userJoin)
    {
        
    }

    public override void OnUserLeave(SvClient conn, UserLeave userLeave)
    {
        //TODO: Implement this
    }

    public override void OnSerializationException(MessagePackSerializationException exception, int packetId)
    {
        Console.WriteLine(exception);    
    }

    public override void OnByteLengthMismatch(SvClient conn, int readBytes, int totalBytes)
    {
        Console.WriteLine(readBytes);   
        Console.WriteLine(totalBytes);   
    }

    public override void OnPacketHandlerException(Exception exception, int packetId)
    {
        Console.WriteLine(exception);   
    }
}