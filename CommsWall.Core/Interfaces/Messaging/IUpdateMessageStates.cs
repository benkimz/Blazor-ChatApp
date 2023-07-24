using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommsWall.Core.Interfaces.Messaging
{
    public interface IUpdateMessageStates
    {
        Task MarkMessageAsRead(int sessionId, int messageId);

        Task MarkMessageAsDelivered(int sessionId, int messageId);
    }
}
