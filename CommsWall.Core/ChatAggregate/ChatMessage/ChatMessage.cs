using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommsWall.Core.ChatAggregate.AppUser;

namespace CommsWall.Core.ChatAggregate.ChatMessage
{
    public class ChatMessage
    {
        public string TextMessage { get; set; }

        public AppUser Sender { get; set; }

        public DateTime TimeStamp { get; set; }

        public int TargetGroupId { get; set; }

        public ChatGroup TargetGroup { get; set; }

        public int Id { get; set; }
    }
}
