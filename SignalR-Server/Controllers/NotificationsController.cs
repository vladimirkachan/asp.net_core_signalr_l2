using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using SignalR_Common;
using SignalR_Server.Hubs;

namespace SignalR_Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationsController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Push([FromBody] Message message, [FromServices] IHubContext<NotificationHub, INotificationClient> hubContext)
        {
            await hubContext.Clients.All.Send(message);
            return Ok();
        }
    }
}
