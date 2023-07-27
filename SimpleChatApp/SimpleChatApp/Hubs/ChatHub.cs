using Microsoft.AspNetCore.SignalR;
using SimpleChatApp.Handler;

namespace SimpleChatApp.Hubs
{
    public class ChatHub : Hub
    {

        private readonly ChatHandler _chatHandler;

        public ChatHub(ChatHandler chatHandler)
        {
            _chatHandler = chatHandler;
        }

        public async Task GetChatUpdate(Chat chat)
        {
            do
            {
                var chats = _chatHandler.GetChats();
                Thread.Sleep(1000);
                await Clients.All.SendAsync("ChatsUpdate", chats);
            }while (true);
        }
    }
}
