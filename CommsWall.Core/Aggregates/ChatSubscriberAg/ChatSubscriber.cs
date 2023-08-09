using CommsWall.Core.Aggregates.ChatGroupAg;
using CommsWall.Core.Aggregates.ChatSessionAg;
using CommsWall.Core.Aggregates.NotificationsAg;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommsWall.Core.Aggregates.ChatSubscriberAg
{
    public class ChatSubscriber
    {
        public int Id { get; set; }

        [Required]
        public int SysIdentifier { get; set; }

        [Required]
        [MaxLength(255)]
        public required string UserName { get; set; }

        [MaxLength(255)]
        public required string AvatarUrl { get; set; }

        public virtual ICollection<ChatGroup> UserGroups { get; set; } = new List<ChatGroup>();

        public virtual ICollection<ChatSession> UserSessions { get; set; } = new List<ChatSession>();

        public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

        [Required]
        public DateTime DateSubscribed { get; set; }
    }
}
