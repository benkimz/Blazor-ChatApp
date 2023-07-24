using CommsWall.Core.Aggregates.SessionsAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommsWall.Infrastructure.CommsChatSessions.QuerySessions
{
    public interface IQuerySessions
    {
        // filter: username or groupname hint
        Task<IEnumerable<ChatSession>> FilterMultiple(string filter);

        Task<ChatSession> FilterSingle(int sessionId);
    }
}
