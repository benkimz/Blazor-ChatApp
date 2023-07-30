using CommsWall.Core.Aggregates.ChatGroupAg;
using CommsWall.Core.Aggregates.ChatGroupAg.AdminsAg;
using CommsWall.Core.Aggregates.ChatMessageAg;
using CommsWall.Core.Aggregates.ChatSessionAg;
using CommsWall.Core.Aggregates.ChatSubscriberAg;
using CommsWall.Core.Aggregates.NotificationsAg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommsWall.Infrastructure.Persistence
{
    public class CommsDbContext : DbContext
    {
        public CommsDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<ChatSubscriber> ChatSubscribers { get; set; }

        public DbSet<ChatGroup> ChatGroups { get; set; }

        public DbSet<ChatSession> ChatSessions { get; set; }

        public DbSet<ChatMessage> ChatMessages { get; set; }

        public DbSet<Notification> Notifications { get; set; }
    }
}
