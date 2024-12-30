using MediatR;

namespace GP_Chatbot.Models.Mediator
{
    public class ApprovalRequest: IRequest
    {
        public int MsgId { get; set; }
        public bool? Approval { get; set; }
    }
}
