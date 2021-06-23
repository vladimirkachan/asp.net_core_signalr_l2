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
            return Clients.Others.SendAsync("Send", message);
        }
    }
}
