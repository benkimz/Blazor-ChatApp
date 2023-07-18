using System;

namespace CommsWall.Core.Interfaces.Chats
{
    public interface IMessageActions
    {
        Task DeleteMessage(string messageId);

        Task ForwardMessage(string messageId, string targetUserId);
    }
}
