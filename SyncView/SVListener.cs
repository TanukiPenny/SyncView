using MessagePack;
using SVCommon;
using SVCommon.Packet;

namespace SyncView;

public class SvListener : PacketHandler<SvClient>
{
    public override void OnPing(SvClient conn)
    {
        conn.SendPing();
        // Console.WriteLine("Ping received");
    }

    public override void OnBasicMessage(SvClient conn, BasicMessage msg)
    {
        Console.WriteLine($"BasicMessage received: {msg.Message}");
    }

    public override void OnLoginResponse(SvClient conn, LoginResponse loginResponse)
    {
        if (!loginResponse.Success) return;
        conn.IsHost = loginResponse.Host;
        Console.WriteLine($"LoginResponse received: Success - {loginResponse.Success}, Host - {loginResponse.Host}");
    }

    public override void OnDisconnectMessage(SvClient conn, DisconnectMessage disconnectMessage)
    {
        Console.WriteLine($"DisconnectMessage received: {disconnectMessage.Message}");
    }

    public override void OnHostChange(SvClient conn, HostChange hostChange)
    {
        if (conn.Nick == hostChange.Nick)
        {
            conn.IsHost = true;
        }
        Console.WriteLine($"HostChange received: {hostChange.Nick}");
    }

    public override void OnNewMedia(SvClient conn, NewMedia newMedia)
    {
        Program.MainForm.MediaManager.CurrentMedia = newMedia.Uri;
        Program.MainForm.MediaManager.Play();
        Console.WriteLine($"NewMedia received: {newMedia.Uri}");
    }

    public override void OnTimeSync(SvClient conn, TimeSync timeSync)
    {
        Program.MainForm.MediaManager.HandleTimeSync(timeSync);
        Console.WriteLine($"TimeSync received: {timeSync.Time}");
    }

    public override void OnUserJoin(SvClient conn, UserJoin userJoin)
    {
        Console.WriteLine($"UserJoin received: {userJoin.Nick}");
    }

    public override void OnUserLeave(SvClient conn, UserLeave userLeave)
    {
        Console.WriteLine($"UserLeave received: {userLeave.Nick}");
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