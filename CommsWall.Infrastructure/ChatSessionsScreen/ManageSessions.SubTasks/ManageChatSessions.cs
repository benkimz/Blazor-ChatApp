using CommsWall.Core.Aggregates.ChatSessionAg;
using CommsWall.Infrastructure.PluginInterfaces.ChatSessionsRp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommsWall.Infrastructure.ChatSessionsScreen.ManageSessions.SubTasks
{
    public class ManageChatSessions : IManageChatSessions
    {
        private readonly IChatSessionsRepository _chatSessionsRepository;

        public ManageChatSessions(IChatSessionsRepository chatSessionsRepository)
        {
            _chatSessionsRepository = chatSessionsRepository;
        }

        public void Add(SessionCategory kind, int creatorId, int targetId)
        {
            _chatSessionsRepository.AddSession(kind, creatorId, targetId);
        }

        public void Delete(int sessionId)
        {
            _chatSessionsRepository.DeleteSession(sessionId);
        }
    }
}
