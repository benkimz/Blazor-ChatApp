using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommsWall.Core.Interfaces.Messaging
{
    public interface IMessageActions
    {
        Task DeleteMessageAsync(int sessionId, int messageId);

        Task ForwardMessageAsync(int sourceSessionId, int sourceMessageId, int targetSessionId, DateTime timeStamp);
    }
}
