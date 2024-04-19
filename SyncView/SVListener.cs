// PB start
using System.Collections;
using MessagePack;
using Serilog;
using SVCommon;
using SVCommon.Packet;

namespace SyncView;

public class SvListener : PacketHandler<SvClient>
{

    #region Packet Overrides

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
        // Send response to login form and set host to the client
        Task.Run(() =>
        {
            Program.LoginForm.HandleLoginResult(loginResponse);
        });
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
        // if we are new host set that true
        if (conn.Nick == hostChange.Nick)
        {
            conn.IsHost = true;
        }

        if (Program.MainForm == null)
        {
            Log.Warning("Waiting for MainForm to be not null");
            Utils.WaitForMainForm();
        }

        if (!Program.MainForm.IsHandleCreated)
        {
            Log.Warning("Waiting for MainForm handle to be created");
            Utils.WaitForMainFormHandle();
        }
        
        // Correct host label
        Program.MainForm.Invoke(() =>
        {
            Program.MainForm.CurrentHostLabel.Text = $"Current Host: {hostChange.Nick}";
        });

        Log.Information("HostChange received: {nick}", hostChange.Nick);
    }
    
    public override void OnPlay(SvClient conn, Play play)
    {
        // Play the new media received
        Program.MediaManager.CurrentMedia = play.Uri;
        Program.MediaManager.Play();
        Log.Information("Play received: {playUri}", play.Uri);
    }

    public override void OnTimeSync(SvClient conn, TimeSync timeSync)
    {
        // Send time sync to media manager
        Program.MediaManager.HandleTimeSync(timeSync);
        Log.Verbose("TimeSync received: {timeSyncTime}", timeSync.Time);
    }

    public override void OnUserJoin(SvClient conn, UserJoin userJoin)
    {
        if (Program.MainForm == null)
        {
            Log.Warning("Waiting for MainForm to be not null");
            Utils.WaitForMainForm();
        }

        if (!Program.MainForm.IsHandleCreated)
        {
            Log.Warning("Waiting for MainForm handle to be created");
            Utils.WaitForMainFormHandle();
        }

        // Send system message to chat
        Program.MainForm.Invoke(() =>
        {
            Program.MainForm.AddChatMessage("System", $"{userJoin.Nick} has joined!");
        });
        
        Log.Information("UserJoin received: {nick}", userJoin.Nick);
    }

    public override void OnUserLeave(SvClient conn, UserLeave userLeave)
    {
        if (Program.MainForm == null)
        {
            Log.Warning("Waiting for MainForm to be not null");
            Utils.WaitForMainForm();
        }

        if (!Program.MainForm.IsHandleCreated)
        {
            Log.Warning("Waiting for MainForm handle to be created");
            Utils.WaitForMainFormHandle();
        }

        // Send system message to chat
        Program.MainForm.Invoke(() =>
        {
            Program.MainForm.AddChatMessage("System", $"{userLeave.Nick} has left");
        });
        
        Log.Information("UserJoin received: {nick}", userLeave.Nick);
    }

    public override void OnPause(SvClient conn)
    {
        Program.MediaManager.Pause();
    }

    public override void OnStop(SvClient conn)
    {
        Program.MediaManager.Stop();
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

    public override void OnChatMessage(SvClient conn, ChatMessage msg)
    {
        if (Program.MainForm == null)
        {
            Log.Warning("Waiting for MainForm to be not null");
            Utils.WaitForMainForm();
        }

        if (!Program.MainForm.IsHandleCreated)
        {
            Log.Warning("Waiting for MainForm handle to be created");
            Utils.WaitForMainFormHandle();
        }

        // Send chat message to chat
        Program.MainForm.Invoke(() =>
        {
            Program.MainForm.AddChatMessage(msg.Nick, msg.Message);
        });
    }

    #endregion
}
// PB end