using GP_Chatbot.Logic.Chatbot;
using GP_Chatbot.Models.Mediator;
using MediatR;

namespace GP_Chatbot.Mediators
{
    public class CancelHandler(IChatService chatService) : IRequestHandler<CancelRequest>
    {
        public async Task Handle(CancelRequest request, CancellationToken cancellationToken)
        {
            await chatService.CancelMessage(request.Message, request.MessageId);
        }
    }
}
