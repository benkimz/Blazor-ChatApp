using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommsWall.Core.Interfaces.Chats
{
    public interface IChatSession
    {
        Task StartGroupSessionAsync(string userId, int groupId);

        Task StartPrivateSessionAsync(string userId, int targetUserId);
    }
}