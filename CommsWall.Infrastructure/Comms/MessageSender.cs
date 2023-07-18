using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using CommsWall.Core.Interfaces.Chats;

namespace CommsWall.Infrastructure.Comms
{
    public class MessageSender : Hub<IMessageSender>
    {
        //
    }
}