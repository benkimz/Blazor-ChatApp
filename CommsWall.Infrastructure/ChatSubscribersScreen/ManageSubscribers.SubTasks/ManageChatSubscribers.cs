using CommsWall.Core.Aggregates.ChatSubscriberAg;
using CommsWall.Infrastructure.PluginInterfaces.ChatSubscribersRp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommsWall.Infrastructure.ChatSubscribersScreen.ManageSubscribers.SubTasks
{
    public class ManageChatSubscribers : IManageChatSubscribers
    {
        private readonly IChatSubscribersRepository _chatSubscribersRepository;

        public ManageChatSubscribers(IChatSubscribersRepository chatSubscribersRepository)
        {
            _chatSubscribersRepository = chatSubscribersRepository;
        }

        public async Task AddSubscriber(int hostSysUserId, string userName, string avatarUrl)
        {
            await _chatSubscribersRepository.AddSubscriber(hostSysUserId, userName, avatarUrl);
        }

        public async Task<IEnumerable<ChatSubscriber>> GetAllSubscribers()
        {
            return await _chatSubscribersRepository.GetAllSubscribersAsync();
        }

        public async Task RemoveSubscriber(int userId)
        {
            await _chatSubscribersRepository.RemoveSubscriber(userId);
        }
    }
}
