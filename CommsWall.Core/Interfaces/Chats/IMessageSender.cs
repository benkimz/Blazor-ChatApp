using System.Threading.Tasks;
using System;

namespace CommsWall.Core.Interfaces.Chats
{
    public interface IMessageSender
    {
        Task SendPrivateMessage(string userId, string textMessage);
        
        Task SendGroupMessage(string groupId, string textMessage);
    }
}
