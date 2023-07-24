using CommsWall.Core.Aggregates.SubscriberAggregate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommsWall.Core.Aggregates.MessageAggregate
{
    public class ChatMessage
    {
        public int Id { get; set; }

        [Required]
        public ChatSubscriber Sender { get; set; }

        [Required]
        public int SessionId { get; set; }

        [MaxLength(2048)]
        public string TextMessage { get; set; }

        [Required]
        public DateTime TimeStamp { get; set; }
    }
}
