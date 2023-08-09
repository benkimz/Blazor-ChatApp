using CommsWall.Core.Aggregates.ChatSubscriberAg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommsWall.Infrastructure.ChatSubscribersScreen.ManageSubscribers.SubTasks
{
    public interface IManageChatSubscribers
    {
        Task AddSubscriber(int hostSysUserId, string userName, string avatarUrl);

        Task RemoveSubscriber(int userId);

        Task<IEnumerable<ChatSubscriber>> GetAllSubscribers();
    }
}
