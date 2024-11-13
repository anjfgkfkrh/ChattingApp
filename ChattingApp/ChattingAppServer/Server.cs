using ChatLib.Events;
using ChatLib.Handlers;
using ChatLib.Models;
using ChatLib.Sockets;
using System.Net;
using System.Net.Sockets;
using System.Numerics;
using System.Text;

namespace ChattingAppServer;

public class Server
{
    private ChatServer _server;
    private ClientRoomManager _roomManager;

    private ChatHub CreateNewStateChatHub(ChatHub hub, ChatState state)
    {
        return new ChatHub
        {
            RoomId = hub.RoomId,
            UserName = hub.UserName,
            State = state,
        };
    }

    private void AddClientMessageList(ChatHub hub)
    {
        string message = hub.State switch
        {
            ChatState.Connect => $"서버에 연결되었습니다 {hub} ",
            ChatState.Disconnect => $"서버 연결이 해제되었습니다 {hub} ",
            _ => $"{hub}: {hub.Message}"
        };
        Console.WriteLine(message);
    }

    private void Connected(object? sender, ChatEventArgs e)
    {
        var hub = CreateNewStateChatHub(e.Hub, ChatState.Connect);

        _roomManager.Add(e.ClientHandler);
        _roomManager.SendToMyRoom(hub);

        Console.WriteLine(e.Hub);
        AddClientMessageList(hub);
    }

    private void Disconnected(object? sender, ChatEventArgs e)
    {
        var hub = CreateNewStateChatHub(e.Hub, ChatState.Disconnect);

        _roomManager.Remove(e.ClientHandler);
        _roomManager.SendToMyRoom(hub);

        Console.WriteLine(e.Hub);
        AddClientMessageList(hub);
    }

    private void Received(object? sender, ChatEventArgs e)
    {
        _roomManager.SendToMyRoom(e.Hub);

        AddClientMessageList(e.Hub);
    }

    private void RunningStateChanged(bool isRunning)
    {

    }

    public async Task StartServer()
    {
        Console.WriteLine("서버 시작");
        await _server.StartAsync();
    }

    public Server()
    {
        Console.WriteLine("서버 초기화 중..");
        _roomManager = new ClientRoomManager();
        _server = new ChatServer(IPAddress.Parse("127.0.0.1"), 8080);
        _server.Connected += Connected;
        _server.Disconnected += Disconnected;
        _server.Received += Received;
        _server.RunningStateChanged += RunningStateChanged;
        Console.WriteLine("서버 초기화 완료");
    }



    

}