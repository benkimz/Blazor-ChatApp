using CommsWall.Core.Aggregates.ChatMessageAg;
using CommsWall.Core.Aggregates.ChatSessionAg;
using CommsWall.Core.Aggregates.ChatSubscriberAg;
using CommsWall.Infrastructure.Persistence;
using CommsWall.Infrastructure.PluginInterfaces.ChatSessionsRp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommsWall.Data.Store.ChatSessionsDST
{
    public class ChatSessionsRepository : IChatSessionsRepository
    {
        private readonly CommsDbContext _context;

        public ChatSessionsRepository(CommsDbContext context)
        {
            _context = context;
        }

        public void AddSession(SessionCategory category, int senderId, int targetId)
        {
			ChatSubscriber? sender = _context.ChatSubscribers.Find(senderId);
            ICollection<ChatSession>? sessions = sender!.UserSessions;

			sessions.Add(new ChatSession
			{
				Category = category,
				SenderId = senderId,
				Sender = sender!,
				TargetIdentifier = targetId,
				DateCreated = DateTime.Now,
			}); _context.SaveChanges();
         }

        public void DeleteSession(int sessionId)
        {
            var targetSession = _context.ChatSessions.Single(sessions => sessions.Id == sessionId);
            if (targetSession != null)
            {
                _context.ChatSessions.Remove(targetSession);
            }
        }

        public Task<IEnumerable<ChatSession>> GetUserSessionsAsync(int userId)
        {
            return Task.FromResult(_context.ChatSessions.Where(sess => sess.SenderId == userId).AsEnumerable());
        }

        public Task<ChatSession?> GetSessionById(int sessionId)
        {
            return Task.FromResult(_context.ChatSessions.Find(sessionId));
        }

        public Task<int?> GetSessionId(int senderId, int targetId, SessionCategory targetKind)
        {
            ChatSession? session = _context.ChatSessions.FirstOrDefault(sess => sess.SenderId == senderId && sess.TargetIdentifier == targetId && sess.Category == targetKind);
            return Task.FromResult(session?.Id);
		}

        public Tuple<ChatMessage, List<int>>? SendMessage(int sessionId, string textMessage)
        {
            ChatSession? session = _context.ChatSessions.Find(sessionId);
            if (session != null)
            {
                ChatMessage? ComposedMessage, MessageToDeliver;
                List<int> TargetUsersCollection = new List<int>();
                
                if (session!.Category == SessionCategory.Private)
                {
                    ChatSession? recipientSession = _context.ChatSessions.FirstOrDefault(sess => sess.SenderId == session.TargetIdentifier && session.Category == SessionCategory.Private && sess.TargetIdentifier == session.SenderId);
                    if (recipientSession == null)
                    {
                        AddSession(session!.Category, session!.TargetIdentifier, session!.SenderId);
                        recipientSession = _context.ChatSessions.FirstOrDefault(sess => sess.SenderId == session.TargetIdentifier && session.Category == SessionCategory.Private && sess.TargetIdentifier == session.SenderId);
                    }
                    ComposedMessage = new ChatMessage
                    {
                        SenderId = session.SenderId,
                        Session = session,
                        TextMessage = textMessage,
                        TimeStamp = DateTime.Now
                    };
                    session.Messages.Add(ComposedMessage);
                    if (recipientSession != null)
                    {
                        MessageToDeliver = new ChatMessage
                        {
                            SenderId = session.SenderId,
                            Session = recipientSession,
                            TextMessage = textMessage,
                            TimeStamp = DateTime.Now
                        };
                        recipientSession.Messages.Add(MessageToDeliver);
                        TargetUsersCollection.Add(recipientSession.SenderId);
                    }
                    _context.SaveChanges();
                   return Tuple.Create(ComposedMessage, TargetUsersCollection);
                }
                // Add group config
            }
            return null;
        }

        public Task<IEnumerable<ChatMessage>?> GetChatMessages(int sessionId)
        {
            return Task.FromResult(_context.ChatMessages.Where(msg => msg.SessionID == sessionId)?.AsEnumerable());
        }

        public Task<ChatMessage?> GetLastSessionMessage(int sessionId)
        {
            return Task.FromResult(_context.ChatMessages.OrderByDescending(s => s.Id).FirstOrDefault(message => message.SessionID == sessionId));
        }
    }
}
