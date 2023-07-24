using CommsWall.Core.Aggregates.SubscriberAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommsWall.Infrastructure.CommsChatSessions.MessagesRepository.Messaging
{
    public interface IMessageSendService
    {
        Task SendMessage(int senderId, int sessionId, string textMessage);
    }
}
