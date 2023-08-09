using CommsWall.Core.Aggregates.ChatSubscriberAg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommsWall.Infrastructure.PluginInterfaces.ChatSubscribersRp
{
    public interface IChatSubscribersRepository
    {
        Task AddSubscriber(int hostSysUserId, string userName, string avatarUrl);

        Task RemoveSubscriber(int userId);

        Task EditUserName(int userId, string userName);

        Task EditAvatarUrl(int userId, string avatarUrl);

        Task<ChatSubscriber?> GetSubscriberByIdAsync(int userId);

        Task<IEnumerable<ChatSubscriber>> GetSubscriberByNameAsync(string name);

        Task<IEnumerable<ChatSubscriber>> GetAllSubscribersAsync();
    }
}
