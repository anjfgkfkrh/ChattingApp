// See https://aka.ms/new-console-template for more information
namespace ChattingAppServer;

using System.Diagnostics;

static class Program
{
    [STAThread]
    static async Task Main()
    {
        Server server = new Server();
        await server.StartServer();
    }
}