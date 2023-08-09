using CommsWall.Core.Aggregates.ChatSessionAg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommsWall.Infrastructure.ChatSessionsScreen.QuerySessions.SubTasks
{
    public interface IQueryChatSessions
    {
        Task<IEnumerable<ChatSession>> GetUserSessions(int userId);

        Task<int?> GetSessionId(int senderId, int targetId, SessionCategory targetKind);

        Task<ChatSession?> GetSessionById(int sessionId);
    }
}
