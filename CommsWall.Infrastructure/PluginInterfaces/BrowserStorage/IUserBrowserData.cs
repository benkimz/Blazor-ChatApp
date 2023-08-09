using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommsWall.Infrastructure.PluginInterfaces.BrowserStorage
{
	public interface IUserBrowserData
	{
		void SetLoggedUserId(int userId);

		Task<int> GetLoggedUserIdAsync();

		void DeleteLoggedUserId();

        void SetSessionId(int sessionId);

        Task<int> GetSessionIdAsync();

        void DeleteSessionId();
    }
}
