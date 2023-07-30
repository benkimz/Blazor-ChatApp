using CommsWall.Core.Aggregates.ChatSubscriberAg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommsWall.Core.Aggregates.ChatGroupAg.AdminsAg
{
    public class GroupAdmin
    {
        public int Id { get; set; }

        public int UserID { get; set; }

        public virtual ChatSubscriber User { get; set; }

        public DateTime DatePromoted { get; set; }
    }
}
