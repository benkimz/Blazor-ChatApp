using CommsWall.Core.Aggregates.ChatMessageAg;
using Microsoft.AspNetCore.SignalR;

namespace CommsWall.WebApp.Hubs
{
    public class CommsHub : Hub
    {
        public Task SendMessage(string user, ChatMessage message)
        {
            return Clients.Client(user).SendAsync("IncomingMessage", message);
        }
    }
}
