using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR_Common;

namespace SignalR_Server
{
    public interface INotificationClient
    {
        Task Send(Message message);
    }
}
