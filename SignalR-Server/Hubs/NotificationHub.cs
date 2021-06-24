using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignalR_Common;

namespace SignalR_Server.Hubs
{
    public class NotificationHub : Hub
    {
        public Task SendMessage(Message message)
        {
            Debug.WriteLine(Context.ConnectionId);
            if (Context.Items.ContainsKey("user_name"))
                message.Title = $"Message from user: {Context.Items["user_name"]}";
            return Clients.Others.SendAsync("Send", message);
        }
        public Task SetName(string name)
        {
            Context.Items.TryAdd("user_name", name);
            return Task.CompletedTask;
        }
    }
}
