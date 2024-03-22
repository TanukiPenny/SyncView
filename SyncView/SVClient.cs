using MessagePack;
using SVCommon;
using SVCommon.Packet;
using Yggdrasil.Network.Framing;
using Yggdrasil.Network.TCP;

namespace SyncView;

public class SvClient : TcpClient
{
    private readonly SvListener _listener;

    public readonly string Nick;
    public bool IsHost;

    private readonly LengthPrefixFramer _framer = new(20000);

    public bool Shutdown = false;

    public SvClient(string nick)
    {
        Nick = nick;
        _listener = new SvListener();
        _framer.MessageReceived += FramerReceivedData;
    }

    public void Connect()
    {
        Connect("127.0.0.1", 9052);
        var login = new Login
        {
            Nick = Nick
        };
        Send(login, MessageType.Login);
    }

    protected override void OnDisconnect(ConnectionCloseType type)
    {
        Console.WriteLine(type);
    }

    protected override void OnReceiveException(Exception ex)
    {
        Console.WriteLine(ex);
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

        byte[] finalBytes = new byte[bytes.Length - sizeof(int)];

        Array.Copy(bytes, sizeof(int), finalBytes, 0, finalBytes.Length);

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