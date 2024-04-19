// PB start
using MessagePack;
using Serilog;
using SVCommon;
using SVCommon.Packet;
using Yggdrasil.Network.Framing;
using Yggdrasil.Network.TCP;

namespace SyncView;

public class SvClient : TcpClient
{
    private readonly SvListener _listener;

    public string Nick;
    public bool IsHost;

    private readonly LengthPrefixFramer _framer = new(20000);

    public bool Shutdown = false;

    public SvClient()
    {
        _listener = new SvListener();
        _framer.MessageReceived += FramerReceivedData;
    }

    // Connect to server
    public void Connect()
    {
        Connect("15.204.205.117", 9052);
    }

    // Send login packet
    public void Login(string nick)
    {
        Nick = nick;
        var login = new Login
        {
            Nick = nick
        };
        Send(login, MessageType.Login);
    }

    protected override void OnDisconnect(ConnectionCloseType type)
    {
        Log.Warning("Connection with server was {type}", type.ToString().ToLower());
    }

    protected override void OnReceiveException(Exception ex)
    {
        Log.Error(ex, "Exception in on receive");
    }

    public void DisconnectClient()
    {
        Disconnect();
    }

    // Override to hand incoming data to the framer
    protected override void ReceiveData(byte[] buffer, int length)
    {
        _framer.ReceiveData(buffer, length);
    }

    // Parse data after framed
    private void FramerReceivedData(byte[] bytes)
    {
        // If less then the size of an int then return, not good data
        if (bytes.Length < sizeof(int))
        {
            return;
        }

        // Get packet id from first bytes
        int packetId = BitConverter.ToInt32(bytes, 0);

        // Make array of data after packet id
        byte[] finalBytes = new byte[bytes.Length - sizeof(Int32)];
        Array.Copy(bytes, sizeof(Int32), finalBytes, 0, finalBytes.Length);

        // Send to packet handler
        _listener.HandlePacket(this, finalBytes, packetId);
    }

    // Send ping
    public void SendPing()
    {
        List<byte> bytes = new();
        bytes.AddRange(BitConverter.GetBytes((int)MessageType.Ping));

        Send(_framer.Frame(bytes.ToArray()));
    }

    // Send packet
    public void Send<T>(T obj, MessageType packetId)
    {
        List<byte> bytes = new();
        bytes.AddRange(BitConverter.GetBytes((int)packetId));
        bytes.AddRange(MessagePackSerializer.Serialize(obj));

        Send(_framer.Frame(bytes.ToArray()));
    }
}
// PB end