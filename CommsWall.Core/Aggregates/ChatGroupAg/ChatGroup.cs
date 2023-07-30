using CommsWall.Core.Aggregates.ChatGroupAg.AdminsAg;
using CommsWall.Core.Aggregates.ChatGroupAg.MembersAg;
using CommsWall.Core.Aggregates.ChatSubscriberAg;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommsWall.Core.Aggregates.ChatGroupAg
{
    public class ChatGroup
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string GroupName { get; set; }

        [Required]
        [MaxLength(255)]
        public string GroupDescription { get; set; }

        [MaxLength]
        public string AvatarUrl { get; set; }

        public int CreatorID { get; set; }

        public virtual ChatSubscriber Creator { get; set; }

        public virtual ICollection<GroupAdmin> GroupAdmins { get; set; }

        public virtual ICollection<GroupMember> GroupMembers { get; set; }
    }
}
