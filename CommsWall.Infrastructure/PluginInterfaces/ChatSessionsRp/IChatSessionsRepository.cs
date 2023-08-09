using CommsWall.Core.Aggregates.ChatMessageAg;
using CommsWall.Core.Aggregates.ChatSessionAg;
using CommsWall.Core.Aggregates.ChatSubscriberAg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommsWall.Infrastructure.PluginInterfaces.ChatSessionsRp
{
    public interface IChatSessionsRepository
    {
        void AddSession(SessionCategory category, int senderId, int targetId);

        void DeleteSession(int sessionId);

        Task<IEnumerable<ChatSession>> GetUserSessionsAsync(int userId);

        Task<int?> GetSessionId(int senderId, int targetId, SessionCategory targetKind);

        Task<ChatSession?> GetSessionById(int sessionId);

        ChatMessage? SendMessage(int sessionId, string textMessage);

        Task<IEnumerable<ChatMessage>?> GetChatMessages(int sessionId);
    }
}
