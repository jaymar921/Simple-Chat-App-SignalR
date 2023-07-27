namespace SimpleChatApp.Handler
{
    public class ChatHandler
    {
        private readonly List<Chat> chats;

        public ChatHandler()
        {
            this.chats = new List<Chat>();
        }

        public IReadOnlyCollection<Chat> GetChats() => this.chats;

        public void AddChat(Chat chat)
        {
            this.chats.Add(chat);
        }
    }
}
