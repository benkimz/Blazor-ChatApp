using CommsWall.Core.Aggregates.ChatSessionAg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommsWall.Infrastructure.ChatSessionsScreen.ManageSessions.SubTasks
{
    public interface IManageChatSessions
    {
        void Add(SessionCategory kind, int creatorId, int targetId);

        void Delete(int sessionId);
    }
}
