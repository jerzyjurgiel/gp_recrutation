using GP_Chatbot.Models.Entities;

namespace GP_Chatbot.Models.Dto
{
    public class ChatMessageDto
    {
        public ChatMessageDto(ChatMessage message)
        {

            this.Id = message.Id;
            this.Message = message.Message;
            this.Approval = message.Approval;
            this.IsAI = message.IsAI;
            this.ChatId = message.ChatId;
        }

        public int Id { get; set; }
        public string Message { get; set; }
        public bool? Approval { get; set; }
        public bool IsAI { get; set; }

        public int ChatId { get; set; }
    }
}
