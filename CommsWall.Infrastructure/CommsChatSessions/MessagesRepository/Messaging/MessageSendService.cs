using CommsWall.Core.Aggregates.SubscriberAggregate;
using CommsWall.Infrastructure.PluginInterfaces.DataAccess.ChatSessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommsWall.Infrastructure.CommsChatSessions.MessagesRepository.Messaging
{
    public class MessageSendService : IMessageSendService
    {
        private readonly IChatSessionsRepository chatSessionsRepository;

        public MessageSendService(IChatSessionsRepository chatSessionsRepository)
        {
            this.chatSessionsRepository = chatSessionsRepository;
        }

        public Task SendMessage(int senderId, int sessionId, string textMessage)
        {
            return chatSessionsRepository.PostMessage(senderId, sessionId, textMessage, DateTime.Now);
        }
    }
}
