using CommsWall.Core.Aggregates.ChatMessageAg;
using CommsWall.Core.Aggregates.ChatSessionAg;
using CommsWall.Core.Aggregates.ChatSubscriberAg;
using CommsWall.Infrastructure.ChatSessionsScreen.QuerySessions.SubTasks;
using CommsWall.Infrastructure.ChatSubscribersScreen.QuerySubscribers.SubTasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommsWall.Infrastructure.ChatSessionsScreen.QueryPastConversations.SubTasks
{
    public class QueryPastConversations : IQueryPastConversations
    {
        private readonly QueryChatSessions queryChatSessions;

        private readonly QueryChatSubscribers queryChatSubscribers;

        public QueryPastConversations(QueryChatSessions queryChatSessions, QueryChatSubscribers queryChatSubscribers)
        {
            this.queryChatSessions = queryChatSessions;
            this.queryChatSubscribers = queryChatSubscribers;
        }

        public async Task<List<Tuple<ChatSession, Dictionary<string, object>>>> GetConversationHistory(int userId)
        {
            List<Tuple<ChatSession, Dictionary<string, object>>> historyResult = new List<Tuple<ChatSession, Dictionary<string, object>>>();

            List<ChatSession>? userChatSessions = (await queryChatSessions.GetUserSessions(userId))?.ToList();
            if(userChatSessions is not null)
            {
                foreach(ChatSession chatSession in userChatSessions)
                {
                    /* query different for users and groups */
                    Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
                    if(chatSession.Category == SessionCategory.Private)
                    {
                        ChatSubscriber? targetUser = await queryChatSubscribers.GetSubscriberByIdAsync(chatSession.TargetIdentifier);
                        if(targetUser != null)
                        {
                            keyValuePairs.Add("TargetName", targetUser!.UserName);
                            keyValuePairs.Add("AvatarUrl", targetUser!.AvatarUrl);
                            keyValuePairs.Add("SessionId", chatSession.Id);
                            historyResult.Add(Tuple.Create(chatSession, keyValuePairs));
                        }
                    } // query for groups
                }
            }
            return historyResult;
        }
    }
}
