using System.Net;
using System.Net.Sockets;
using System.Numerics;
using System.Text;

namespace ChattingAppServer;

public class Server
{
    TcpListener listener;
    IPEndPoint ipEndPoint;
    List<TcpClient> clients;

    public Server()
    {
        ipEndPoint = new IPEndPoint(IPAddress.Any, 8000);
        listener = new TcpListener(ipEndPoint);
    }

    public async void Run()
    {
        listener.Start();
        Console.WriteLine("Server Start");

        while (true)
        {
            Console.WriteLine("Client Listen...");
            TcpClient client = await listener.AcceptTcpClientAsync();
            clients.Add(client);

            _ = HandleClient(client);
        }
    }

    private async Task HandleClient(TcpClient client)
    {
        Console.WriteLine("New Client Accept");
        NetworkStream stream = client.GetStream();
        _ = ReadData(stream);
        _ = WriteData(stream);
    }

    private async Task ReadData(NetworkStream stream)
    {
        byte[] sizeBuffer = new byte[4];
        int read;

        while (true)
        {
            read = await stream.ReadAsync(sizeBuffer, 0, sizeBuffer.Length);
            if (read == 0)
                break;
            Console.WriteLine($"{read} bytes");

            int size = BitConverter.ToInt32(sizeBuffer, 0);
            byte[] buffer = new byte[size];

            read = await stream.ReadAsync(buffer, 0, buffer.Length);
            if (read == 0)
                break;
            Console.WriteLine("read data");

            string message = Encoding.UTF8.GetString(buffer,0,read);
        }
    }

    private async Task WriteData(NetworkStream stream)
    {

    }



    

}