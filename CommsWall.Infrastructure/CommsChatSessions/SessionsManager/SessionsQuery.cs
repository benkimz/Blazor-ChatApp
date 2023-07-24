using CommsWall.Core.Aggregates.SessionsAggregate;
using CommsWall.Infrastructure.PluginInterfaces.DataAccess.ChatSessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommsWall.Infrastructure.CommsChatSessions.QuerySessions
{
    public class SessionsQuery : ISessionsQuery
    {
        private readonly IChatSessionsRepository chatSessionsRepository;

        public SessionsQuery(IChatSessionsRepository chatSessionsRepository)
        {
            this.chatSessionsRepository = chatSessionsRepository;
        }

        public Task Add(int userId, int targetId, SessionCategories kind)
        {
            return chatSessionsRepository.AddSession(userId, targetId, kind, DateTime.Now);
        }

        public Task Delete(int sessionId)
        {
            return chatSessionsRepository.DeleteSession(sessionId);
        }
    }
}
