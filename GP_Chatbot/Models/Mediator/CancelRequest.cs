using MediatR;

namespace GP_Chatbot.Models.Mediator
{
    public class CancelRequest : IRequest
    {
        public int MessageId { get; set; }
        public string Message { get; set; }
    }
}
