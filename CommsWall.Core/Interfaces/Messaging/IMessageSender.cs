using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommsWall.Core.Interfaces.Messaging
{
    public interface IMessageSender
    {
        Task SendMessageAsync(int sessionId, string textMessage, DateTime timeStamp);
    }
}
