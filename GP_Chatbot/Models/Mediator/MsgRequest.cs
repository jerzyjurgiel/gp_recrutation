using GP_Chatbot.Models.Dto;
using GP_Chatbot.Models.Entities;
using MediatR;

namespace GP_Chatbot.Models.Mediator
{
    public class MsgRequest : IRequest<ChatMessageDto>
    {
        public int? ChatId { get; set; }
        public string Message { get; set; }
    }
}
