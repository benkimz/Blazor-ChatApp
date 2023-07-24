using CommsWall.Core.Aggregates.MessageAggregate;
using CommsWall.Core.Aggregates.SessionsAggregate;
using CommsWall.Core.Aggregates.SubscriberAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommsWall.Infrastructure.PluginInterfaces.DataAccess.ChatSessions
{
    public interface IChatSessionsRepository
    {
        Task AddSession(int userId, int targetId, SessionCategories kind, DateTime timeStamp);
        Task DeleteSession(int sessionId);

        //filter sessions by username or groupname
        Task<IEnumerable<ChatSession>> GetSessions(string userOrGroupName);

        //get a session by its id
        Task<ChatSession> GetSession(int sessionId);

        //post | add a chat message
        Task PostMessage(int senderId, int sessionId, string textMessage, DateTime timeStamp);

        //get messages
        Task<IEnumerable<ChatMessage>> GetMessages(int sessionId);

        //get a message by id
        Task<ChatMessage> GetMessage(int sessionId, int messageId);

        //filter messages by text
        Task<IEnumerable<ChatMessage>> FilterMessages(int sessionId, string filter);
    }
}
