using CommsWall.Core.Aggregates.ChatGroupAg;
using CommsWall.Core.Aggregates.ChatSubscriberAg;
using CommsWall.Core.Aggregates.NotificationsAg;
using CommsWall.Infrastructure.Persistence;
using CommsWall.Infrastructure.PluginInterfaces.ChatSubscribersRp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommsWall.Data.Store.ChatSubscribersDST
{
    public class ChatSubscribersRepository : IChatSubscribersRepository
    {
        private readonly CommsDbContext _context;

        public ChatSubscribersRepository(CommsDbContext context)
        {
            _context = context;
        }

        public async Task AddSubscriber(int hostSysUserId, string userName, string avatarUrl)
        {
            await _context.ChatSubscribers.AddAsync(
                new ChatSubscriber
                {
                    SysIdentifier = hostSysUserId,
                    UserName = userName,
                    AvatarUrl = avatarUrl,
                    DateSubscribed = DateTime.Now
                }
                );
            await _context.SaveChangesAsync();
        }

        public Task EditAvatarUrl(int userId, string avatarUrl)
        {
            throw new NotImplementedException();
        }

        public Task EditUserName(int userId, string userName)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ChatSubscriber>> GetAllSubscribersAsync()
        {
            return Task.FromResult(_context.ChatSubscribers.AsEnumerable());
        }

        public Task<ChatSubscriber?> GetSubscriberByIdAsync(int userId)
        {
            return Task.FromResult(_context.ChatSubscribers.Find(userId));
        }

        public Task<IEnumerable<ChatSubscriber>> GetSubscriberByNameAsync(string name)
        {
            if(!string.IsNullOrWhiteSpace(name))
            return Task.FromResult(_context.ChatSubscribers.Where(user => user.UserName.ToLower().Contains(name.ToLower())).AsEnumerable());
            return Task.FromResult(_context.ChatSubscribers.AsEnumerable());
        }

        public async Task RemoveSubscriber(int userId)
        {
            var targetUser = await Task.FromResult(_context.ChatSubscribers.Single(user => user.Id == userId));
            if(targetUser != null)
            {
                _context.ChatSubscribers.Remove(targetUser);
            }
        }
    }
}
