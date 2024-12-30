using GP_Chatbot.Models.Dto;
using MediatR;

namespace GP_Chatbot.Models.Mediator
{
    public class GetMessagesRequest : IRequest<IEnumerable<ChatMessageDto>>
    {
        public int ChatId { get; set; }
    }
}
