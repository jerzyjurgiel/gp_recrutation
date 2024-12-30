namespace GP_Chatbot.Models.Entities
{
    public class ChatMessage
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public bool? Approval { get; set; }
        public bool IsAI { get; set; }

        public int ChatId { get; set; }
        public Chat Chat { get; set; }
    }
}
