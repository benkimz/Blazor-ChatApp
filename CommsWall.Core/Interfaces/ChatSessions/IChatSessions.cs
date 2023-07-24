using CommsWall.Core.Aggregates.SessionsAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommsWall.Core.Interfaces.ChatSessions
{
    public interface IChatSessions
    {
        //start a new chat session to send messages in a group
        Task StartGroupSessionAsync(int userId, int targetGroupId, DateTime timeStamp, SessionCategories kind = SessionCategories.Group);

        //start a new chat session to send private messages to a specific user
        Task StartPrivateSessionAsync(int userId, int targetUserId, DateTime timeStamp, SessionCategories kind = SessionCategories.Private);

        //delete chat session | delete messages
        Task DeleteSessionAsync(int sessionId);
    }
}
