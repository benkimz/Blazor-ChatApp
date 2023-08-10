using CommsWall.Core.Aggregates.ChatSessionAg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommsWall.Infrastructure.ChatSessionsScreen.QueryPastConversations.SubTasks
{
    public interface IQueryPastConversations
    {
        Task<List<Tuple<ChatSession, Dictionary<string, object>>>> GetConversationHistory(int userId);
    }
}
