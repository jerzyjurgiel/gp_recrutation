using Microsoft.EntityFrameworkCore;

namespace GP_Chatbot.Models.Entities
{
    public class Chat
    {
        public int Id { get; set; }
        public List<ChatMessage> Messages { get; } = new();
    }
}
