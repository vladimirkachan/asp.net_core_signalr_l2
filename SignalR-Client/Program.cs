using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using SignalR_Common;

namespace SignalR_Client
{
    class Program
    {
        static HubConnection connection;

        static async Task Main(string[] args)
        {
            await InitSignalRConnection();
            for (; ; )
            {
                Console.WriteLine("Enter your message or command: ");
                var input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input)) continue;
                if (input.ToUpper() == "Q") return;
                if (input == "setname")
                {
                    Console.WriteLine("Enter your name: ");
                    var name = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(name)) continue;
                    await connection.SendAsync("SetName", name);
                    Console.WriteLine("Name saved");
                }
                else
                {
                    await connection.SendAsync("SendMessage", new Message {Title = "Simple message", Body = input});
                    Console.WriteLine("Message sent");
                }
            }
        }

        static Task InitSignalRConnection()
        {
            connection = new HubConnectionBuilder().WithUrl("http://localhost:32887/notification").Build();
            connection.On<Message>("Send", message =>
            {
                Console.WriteLine("New message from server");
                Console.WriteLine($"Title: {message.Title}");
                Console.WriteLine($"Body: {message.Body}");
            });
            return connection.StartAsync();
        }
    }
}
