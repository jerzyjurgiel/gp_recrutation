using GP_Chatbot.Logic.Chatbot;
using GP_Chatbot.Models.Mediator;
using MediatR;

namespace GP_Chatbot.Mediators
{
    public class ApprovalHandler(IChatService chatService) : IRequestHandler<ApprovalRequest>
    {
        public async Task Handle(ApprovalRequest request, CancellationToken cancellationToken)
        {
            await chatService.SetMessageApproval(request.MsgId, request.Approval);
        }
    }
}
