using CommsWall.Core.Aggregates.ChatSubscriberAg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommsWall.Infrastructure.ChatSubscribersScreen.QuerySubscribers.SubTasks
{
    public interface IQueryChatSubscribers
    { 
        Task<ChatSubscriber?> GetSubscriberByIdAsync(int userId);

        Task<IEnumerable<ChatSubscriber>> FetchAllSubscribersAsync();

        Task<IEnumerable<ChatSubscriber>> FilterSubscribersByNameAsync(string filter);
    }
}
