using System;
using System.Threading.Tasks;

namespace CommsWall.Core.Interfaces.Groups
{
    public interface IAdminTasks
    {
        Task AddUserToGroup(string userName, string groupId);

        Task RemoveUserFromGroup(string userName, string groupId);

        Task UpdateGroupName(string groupId, string newName);
    }
}
