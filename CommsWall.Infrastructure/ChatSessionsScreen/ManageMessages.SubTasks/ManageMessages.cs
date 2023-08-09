using CommsWall.Infrastructure.PluginInterfaces.ChatSessionsRp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommsWall.Infrastructure.ChatSessionsScreen.ManageMessages.SubTasks
{
    public class ManageMessages : IManageMessages
    {
        private readonly IChatSessionsRepository _chatSessionsRepository;

        public ManageMessages(IChatSessionsRepository chatSessionsRepository)
        {
            _chatSessionsRepository = chatSessionsRepository;
        }

        public void SendMessage(int sessionId, string textMessage)
        {
            _chatSessionsRepository.SendMessage(sessionId, textMessage);
        }
    }
}
