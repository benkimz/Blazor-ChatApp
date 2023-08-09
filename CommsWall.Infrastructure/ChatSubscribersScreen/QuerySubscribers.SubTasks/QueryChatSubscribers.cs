using CommsWall.Core.Aggregates.ChatSubscriberAg;
using CommsWall.Infrastructure.PluginInterfaces.ChatSubscribersRp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommsWall.Infrastructure.ChatSubscribersScreen.QuerySubscribers.SubTasks
{
    public class QueryChatSubscribers : IQueryChatSubscribers
    {
        private readonly IChatSubscribersRepository _chatSubscribersRepository;

        public QueryChatSubscribers(IChatSubscribersRepository chatSubscribersRepository)
        {
            this._chatSubscribersRepository = chatSubscribersRepository;
        }

        public Task<IEnumerable<ChatSubscriber>> FetchAllSubscribersAsync()
        {
            return _chatSubscribersRepository.GetAllSubscribersAsync();
        }

        public Task<IEnumerable<ChatSubscriber>> FilterSubscribersByNameAsync(string filter)
        {
            return _chatSubscribersRepository.GetSubscriberByNameAsync(filter);
        }

        public Task<ChatSubscriber?> GetSubscriberByIdAsync(int userId)
        {
            return _chatSubscribersRepository.GetSubscriberByIdAsync(userId);
        }
    }
}
