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
        public string UserName { get; set; }

        [MaxLength(255)]
        public string AvatarUrl { get; set; }

        public virtual ICollection<ChatGroup> UserGroups { get; set; }

        public virtual ICollection<ChatSession> UserSessions { get; set; }

        public virtual ICollection<Notification> Notifications { get; set; }

        [Required]
        public DateTime DateSubscribed { get; set; }
    }
}
