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

        public AppUser GroupAdmin { get; set; }

        public string GroupDescription { get; set; } 

        public string GroupAvatar { get; set; }

        public IEnumerable<AppUser> GroupMembers { get; set; }

        public IEnumerable<ChatMessage> GroupMessages { get; set; }

        public int GroupId { get; set; }
    }
}