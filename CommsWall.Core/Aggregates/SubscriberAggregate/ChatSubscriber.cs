using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * UserName, Avatar, Activity, & LastSeen are independent of the main system
 */

namespace CommsWall.Core.Aggregates.SubscriberAggregate
{
    public class ChatSubscriber
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [MaxLength(255)]
        public string UserName { get; set; }

        [MaxLength(255)]
        public string Avatar { get; set; }

        [MaxLength(120)]
        public string Activity { get; set; }

        [Required]
        public DateTime LastSeen { get; set; }
    }
}
