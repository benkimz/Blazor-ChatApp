using CommsWall.Core.Aggregates.ChatMessageAg;
using CommsWall.Infrastructure.PluginInterfaces.ChatSessionsRp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommsWall.Infrastructure.ChatSessionsScreen.QueryMessages.SubTasks
{
    public class QueryMessages : IQueryMessages
    {
        private readonly IChatSessionsRepository _chatSessionsRepository;

        public QueryMessages(IChatSessionsRepository chatSessionsRepository)
        {
            _chatSessionsRepository = chatSessionsRepository;
        }

        public Task<IEnumerable<ChatMessage>?> GetSessionMessages(int sessionId)
        {
            return _chatSessionsRepository.GetChatMessages(sessionId);
        }
    }
}
