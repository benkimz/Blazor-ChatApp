using CommsWall.Core.Aggregates.ChatSessionAg;
using CommsWall.Infrastructure.PluginInterfaces.ChatSessionsRp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommsWall.Infrastructure.ChatSessionsScreen.QuerySessions.SubTasks
{
    public class QueryChatSessions : IQueryChatSessions
    {
        private readonly IChatSessionsRepository _chatSessionsRepository;

        public QueryChatSessions(IChatSessionsRepository chatSessionsRepository)
        {
            _chatSessionsRepository = chatSessionsRepository;
        }

        public Task<IEnumerable<ChatSession>> GetUserSessions(int userId)
        {
            return _chatSessionsRepository.GetUserSessionsAsync(userId);
        }

        public Task<ChatSession?> GetSessionById(int sessionId)
        {
            return _chatSessionsRepository.GetSessionById(sessionId);
        }

        public Task<int?> GetSessionId(int senderId, int targetId, SessionCategory targetKind)
        {
            return _chatSessionsRepository.GetSessionId(senderId, targetId, targetKind);
        }
    }
}
