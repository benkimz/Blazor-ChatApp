using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommsWall.Core.ChatAggregate.AppUser;
using CommsWall.Core.ChatAggregate.ChatMessage;

namespace CommsWall.Core.ChatAggregate.ChatGroup
{
    public class ChatGroup
    {
        public string GroupName { get; set; }

        public AppUser Admin { get; set; }

        public ICollection<ChatMessage> GroupMessages { get; set; }

        public int GroupId { get; set; }
    }
}