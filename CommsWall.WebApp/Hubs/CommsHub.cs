using CommsWall.Core.Aggregates.ChatMessageAg;
using Microsoft.AspNetCore.SignalR;

namespace CommsWall.WebApp.Hubs
{
    public class CommsHub : Hub
    {
        private static Dictionary<string, string> _commsMap = new Dictionary<string, string>();

        public override Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            var userCommsId = httpContext?.Request.Headers["user"].ToString();
            var commsUserId = Context.UserIdentifier;
            if (!_commsMap.ContainsKey(userCommsId!))
            {
                _commsMap.Add(userCommsId!, Context.UserIdentifier!);
            }
            Console.WriteLine($"======> user connecting {userCommsId}");
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            var httpContext = Context.GetHttpContext();
            var userCommsId = httpContext?.Request.Headers["user"].ToString();
            if (!_commsMap.ContainsKey(userCommsId!))
                _commsMap.Remove(userCommsId!);
            
            Console.WriteLine($"====> user disconnecting {userCommsId}");
            return base.OnDisconnectedAsync(exception);
        }

        public Task BroadcastMessage(int userId, string receivedMessage)
        {
            if (_commsMap.ContainsKey(userId.ToString()))
            {
                return Clients.User(_commsMap[userId.ToString()]).SendAsync("GetBroadcastedMessage", userId, receivedMessage);
            }
            Console.WriteLine("==========] Look Out: ");
            return Task.CompletedTask;
        }
    }
}
