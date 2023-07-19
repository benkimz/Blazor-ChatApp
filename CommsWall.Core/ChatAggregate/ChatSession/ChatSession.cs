using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommsWall.Core.ChatAggregate.AppUser;

namespace CommsWall.Core.ChatAggregate.ChatSession
{
    public class ChatSession
    {
        public string SessionName { get; set; }

        public AppUser Creator { get; set; }

        public IEnumerable<AppUser> TargetUsers { get; set; } 

        public int SessionId { get; set; }
    }
}