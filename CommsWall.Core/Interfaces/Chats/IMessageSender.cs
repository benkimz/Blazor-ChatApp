using System.Threading.Tasks;
using System;

namespace CommsWall.Core.Interfaces.Chats
{
    public interface IMessageSender
    {
        Task SendPrivateMessage(string userName, string textMessage);
        
        Task SendGroupMessage(string groupId, string textMessage);
    }
}
