using MessagePack;
using Serilog;
using SVCommon;
using SVCommon.Packet;

namespace SyncView;

public class SvListener : PacketHandler<SvClient>
{
    public override void OnPing(SvClient conn)
    {
        conn.SendPing();
        Log.Verbose("Ping received");
    }

    public override void OnBasicMessage(SvClient conn, BasicMessage msg)
    {
        Log.Information("BasicMessage received: {msg}" ,msg.Message);
    }

    public override void OnLoginResponse(SvClient conn, LoginResponse loginResponse)
    {
        if (!loginResponse.Success) return;
        conn.IsHost = loginResponse.Host;
        Log.Information("LoginResponse received: Success - {success}, Host - {host}", loginResponse.Success, loginResponse.Host);
    }

    public override void OnDisconnectMessage(SvClient conn, DisconnectMessage disconnectMessage)
    {
        Log.Information("DisconnectMessage received: {disconnectMessage}", disconnectMessage.Message);
    }

    public override void OnHostChange(SvClient conn, HostChange hostChange)
    {
        if (conn.Nick == hostChange.Nick)
        {
            conn.IsHost = true;
        }
        Log.Information("HostChange received: {nick}", hostChange.Nick);
    }

    public override void OnNewMedia(SvClient conn, NewMedia newMedia)
    {
        Program.MainForm.MediaManager.CurrentMedia = newMedia.Uri;
        Program.MainForm.MediaManager.Play();
        Log.Information("NewMedia received: {newMediaUri}", newMedia.Uri);
    }

    public override void OnTimeSync(SvClient conn, TimeSync timeSync)
    {
        Program.MainForm.MediaManager.HandleTimeSync(timeSync);
        Log.Verbose("TimeSync received: {timeSyncTime}", timeSync.Time);
    }

    public override void OnUserJoin(SvClient conn, UserJoin userJoin)
    {
        Log.Information("UserJoin received: {nick}", userJoin.Nick);
    }

    public override void OnUserLeave(SvClient conn, UserLeave userLeave)
    {
        Log.Information("UserLeave received: {nick}", userLeave.Nick);
    }

    
    public override void OnSerializationException(MessagePackSerializationException exception, int packetId)
    {
        Log.Error(exception, "Exception in serialization");
    }

    public override void OnByteLengthMismatch(SvClient conn, int readBytes, int totalBytes)
    {
        Log.Warning("Byte Length Mismatch - Read: {readBytes}, Total: {totalBytes}", readBytes, totalBytes);
    }

    public override void OnPacketHandlerException(Exception exception, int packetId)
    {
        Log.Error(exception, "Exception in packet handler"); 
    }
}