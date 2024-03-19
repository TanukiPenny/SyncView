using LiteNetLib;
using SVCommon;
using Yggdrasil.Network.Framing;
using Yggdrasil.Network.TCP;

namespace SyncView;

public class SVClient : TcpClient
{
    public SVListener Listener;
    
    private LengthPrefixFramer _framer = new(20000);

    public bool Shutdown = false;
    
    public static Thread ClientLoopThread;

    public SVClient()
    {
        Listener = new SVListener();
        _framer.MessageReceived += FramerReceivedData;
        
        ClientLoopThread = new Thread(ClientLoop);
        ClientLoopThread.Start();
    }

    private void ClientLoop()
    {
        while (!Shutdown)
        {
            if (!IsConnected())
            {
                Connect("127.0.0.1", 9052);
            }
        }
    }
    
    public bool IsConnected()
    {
        return Status == ClientStatus.Connected;
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
        
        int packetID = BitConverter.ToInt32(bytes, 0);
            
        byte[] finalBytes = new byte[bytes.Length - sizeof(int)];
            
        Array.Copy(bytes, sizeof(int), finalBytes, 0, finalBytes.Length);
            
        Listener.HandlePacket(this, finalBytes, packetID);
    }
    
    public void SendPing()
    {
        List<byte> bytes = new();
        bytes.Add(0);
        bytes.AddRange(BitConverter.GetBytes((int)MessageType.Ping));
        
        Send(_framer.Frame(bytes.ToArray()));
    }
}