using CommsWall.Core.Aggregates.ChatMessageAg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommsWall.Infrastructure.ChatSessionsScreen.QueryMessages.SubTasks
{
    public interface IQueryChatMessages
    {
        Task<IEnumerable<ChatMessage>?> GetSessionMessages(int sessionId);

        Task<ChatMessage?> GetLastMessage(int sessionId);
    }
}
