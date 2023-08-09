using CommsWall.Infrastructure.PluginInterfaces.BrowserStorage;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommsWall.Infrastructure.BrowserStorageScreen
{
	public class UserBrowserData : IUserBrowserData
	{
		private readonly ProtectedSessionStorage _storageService;

        public UserBrowserData(ProtectedSessionStorage storageService)
        {
            _storageService = storageService;
        }

        private string loggedUserDataKey { get; set; } = "CommsUserId";

		public async void SetLoggedUserId(int userId)
		{
			await _storageService.SetAsync(loggedUserDataKey, userId);
		}

		public async Task<int> GetLoggedUserIdAsync()
		{
			var data = await _storageService.GetAsync<int>(loggedUserDataKey);
            return data.Success ? data.Value : 0;
		}

		public async void DeleteLoggedUserId()
		{
			await _storageService.DeleteAsync(loggedUserDataKey);
		}

        private string loggedChatSessionDataKey { get; set; } = "ActiveChatSessionID";

        public async void SetSessionId(int sessionId)
        {
            await _storageService.SetAsync(loggedChatSessionDataKey, sessionId);
        }

        public async Task<int> GetSessionIdAsync()
        {
            var data = await _storageService.GetAsync<int>(loggedChatSessionDataKey);
            return data.Success ? data.Value : 0;
        }

        public async void DeleteSessionId()
        {
            await _storageService.DeleteAsync(loggedChatSessionDataKey);
        }
    }
}
