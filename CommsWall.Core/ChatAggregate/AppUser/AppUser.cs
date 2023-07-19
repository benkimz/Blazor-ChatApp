using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommsWall.Core.ChatAggregate.ChatGroup;
using CommsWall.Core.ChatAggregate.ChatMessage;

namespace CommsWall.Core.ChatAggregate.AppUser
{
    public class AppUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string AvatarUrl { get; set; }

        public IEnumerable<ChatGroup> UserGroups { get; set; }

        public IEnumerable<ChatMessage> UserMessages { get; set; }

        public int UserId { get; set; }
    }
}