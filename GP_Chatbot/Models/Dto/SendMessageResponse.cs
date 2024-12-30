using GP_Chatbot.Models.Entities;

namespace GP_Chatbot.Models.Dto
{
    public class SendMessageResponse
    {
        public SendMessageResponse(ChatMessage message)
        {
            this.Id = message.Id;
            this.Message = message.Message;
            this.Approval = message.Approval;
            this.IsAI = message.IsAI;
        }

        public int Id { get; set; }
        public string Message { get; set; }
        public bool? Approval { get; set; }
        public bool IsAI { get; set; }
    }
}
