using CommsWall.Core.Aggregates.SubscriberAggregate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommsWall.Core.Aggregates.GroupsAggregate
{
    public class ChatGroup
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(320)]
        public string Description { get; set; }

        [Required]
        public ChatSubscriber Creator { get; set; }

        public List<ChatSubscriber> Admins { get; set; } = new List<ChatSubscriber>();

        public List<ChatSubscriber> Members { get; set; } = new List<ChatSubscriber>();
    }
}
