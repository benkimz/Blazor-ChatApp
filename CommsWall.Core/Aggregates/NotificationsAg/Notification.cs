using CommsWall.Core.Aggregates.ChatSubscriberAg;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommsWall.Core.Aggregates.NotificationsAg
{
    public class Notification
    {
        public int Id { get; set; }

        public int TargetUserID { get; set; }

        public virtual ChatSubscriber TargetUser { get; set; }

        [MaxLength(120)]
        public string Description { get; set; }

        [Required]
        [MaxLength(320)]
        public string Message { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
