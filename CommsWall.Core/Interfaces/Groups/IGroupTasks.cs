using System;
using System.Threading.Tasks;

namespace CommsWall.Core.Interfaces.Groups
{
    public interface IGroupTasks
    {
        Task JoinGroup(string userName, string groupId);

        Task LeaveGroup(string userName, string groupId);

        /*
            Will add: Report group, Report user, Block user, Unblock user,
        */
    }
}
