using CommsWall.Core.Aggregates.SessionsAggregate;
using CommsWall.Infrastructure.PluginInterfaces.DataAccess.ChatSessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommsWall.Infrastructure.CommsChatSessions.QuerySessions
{
    internal class QuerySessions : IQuerySessions
    {
        private readonly IChatSessionsRepository chatSessionsRepository;

        public QuerySessions(IChatSessionsRepository chatSessionsRepository)
        {
            this.chatSessionsRepository = chatSessionsRepository;
        }

        public Task<IEnumerable<ChatSession>> FilterMultiple(string filter)
        {
            return chatSessionsRepository.GetSessions(filter);
        }

        public Task<ChatSession> FilterSingle(int sessionId)
        {
            return chatSessionsRepository.GetSession(sessionId);
        }
    }
}
