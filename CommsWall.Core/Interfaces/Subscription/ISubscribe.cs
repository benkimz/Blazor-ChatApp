using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommsWall.Core.Interfaces.Subscription
{
    public interface ISubscribe
    {
        //Subscribe and set defaults: UserName, Avatar, Activity, LastSeen
        Task SubscribeToChatService(int userId);

        //Unset | delete user from chat service
        Task UnsubscribeFromChatService(int userId);
    }
}
