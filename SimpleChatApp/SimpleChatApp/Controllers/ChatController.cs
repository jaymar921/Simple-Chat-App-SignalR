using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleChatApp.Handler;
using SimpleChatApp.Hubs;

namespace SimpleChatApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly ChatHandler chatHandler;

        public ChatController(ChatHandler handler)
        {
            this.chatHandler = handler;
        }

        [HttpPost]
        public IActionResult PostChat(Chat chat)
        {
            // process the chat
            chatHandler.AddChat(chat);
            return Accepted(chat);
        }
    }
}
