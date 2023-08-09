using CommsWall.Core.Aggregates.ChatGroupAg.GroupRolesAg;
using CommsWall.Core.Aggregates.ChatSubscriberAg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommsWall.Core.Aggregates.ChatGroupAg.MembersAg
{
    public class GroupMember
    {
        public int Id { get; set; }

        public int UserID { get; set; }

        public virtual required ChatSubscriber User { get; set; }

        public ChatGroupRoles Role { get; set; }

        public DateTime DateJoined { get; set; }
    }
}
