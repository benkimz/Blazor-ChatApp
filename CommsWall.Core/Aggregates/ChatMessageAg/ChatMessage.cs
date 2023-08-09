using CommsWall.Core.Aggregates.ChatSessionAg;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommsWall.Core.Aggregates.ChatMessageAg
{
    public class ChatMessage
    {
        public int Id { get; set; }

        [Required]
        public int SessionID { get; set; }

        [MaxLength(4096)]
        public required string TextMessage { get; set; }

        public virtual required ChatSession Session { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
