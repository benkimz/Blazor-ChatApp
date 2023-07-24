using CommsWall.Core.Aggregates.MessageAggregate;
using CommsWall.Core.Aggregates.SessionsAggregate;
using CommsWall.Core.Aggregates.SubscriberAggregate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommsWall.Core.Aggregates.SessionsAggregate
{
    public class ChatSession
    {
        public int Id { get; set; }

        public ChatSubscriber User { get; set; }

        [Required]
        public SessionCategories Kind { get; set; }

        [Required]
        public int TargetId { get; set; }

        public IEnumerable<ChatMessage> Messages { get; set; } = Enumerable.Empty<ChatMessage>();

        public DateTime TimeStamp { get; set; }
    }
}
