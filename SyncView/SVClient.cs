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

    public void Connect()
    {
        Connect("15.204.205.117", 9052);
    }

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

    protected override void ReceiveData(byte[] buffer, int length)
    {
        _framer.ReceiveData(buffer, length);
    }

    private void FramerReceivedData(byte[] bytes)
    {
        if (bytes.Length < sizeof(int))
        {
            return;
        }

        int packetId = BitConverter.ToInt32(bytes, 0);

        byte[] finalBytes = new byte[bytes.Length - sizeof(Int32)];

        Array.Copy(bytes, sizeof(Int32), finalBytes, 0, finalBytes.Length);

        _listener.HandlePacket(this, finalBytes, packetId);
    }

    public void SendPing()
    {
        List<byte> bytes = new();
        bytes.AddRange(BitConverter.GetBytes((int)MessageType.Ping));

        Send(_framer.Frame(bytes.ToArray()));
    }

    public void Send<T>(T obj, MessageType packetId)
    {
        List<byte> bytes = new();
        bytes.AddRange(BitConverter.GetBytes((int)packetId));
        bytes.AddRange(MessagePackSerializer.Serialize(obj));

        Send(_framer.Frame(bytes.ToArray()));
    }
}