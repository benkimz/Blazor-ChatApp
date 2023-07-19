using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommsWall.Core.ChatAggregate.AppUser;
using CommsWall.Core.ChatAggregate.ChatSession;

namespace CommsWall.Core.ChatAggregate.ChatMessage
{
    public class ChatMessage
    {
        public ChatSession Session { get; set; }

        public string TextMessage { get; set; }

        public DateTime TimeStamp { get; set; }

        public int Id { get; set; }
    }
}
