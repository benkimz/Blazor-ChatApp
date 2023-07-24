using CommsWall.Core.Aggregates.SessionsAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommsWall.Infrastructure.CommsChatSessions.QuerySessions
{
    public interface ISessionsQuery
    {
        Task Add(int userId, int targetId, SessionCategories kind);

        Task Delete(int sessionId);
    }
}
