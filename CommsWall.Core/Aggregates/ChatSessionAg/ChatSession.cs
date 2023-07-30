using CommsWall.Core.Aggregates.ChatMessageAg;
using CommsWall.Core.Aggregates.ChatSubscriberAg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommsWall.Core.Aggregates.ChatSessionAg
{
    public class ChatSession
    {
        public int Id { get; set; }

        public SessionCategory Category { get; set; }

        public int SenderId { get; set; }

        public virtual ChatSubscriber Sender { get; set; }

        public int TargetIdentifier { get; set; }

        public virtual ICollection<ChatMessage> Messages { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
