using GP_Chatbot.Logic.Chatbot;
using GP_Chatbot.Models.Dto;
using GP_Chatbot.Models.Mediator;
using MediatR;

namespace GP_Chatbot.Mediators
{
    public class MessageListHandler(IChatService chatService) : IRequestHandler<GetMessagesRequest, IEnumerable<ChatMessageDto>>
    {
        public async Task<IEnumerable<ChatMessageDto>> Handle(GetMessagesRequest request, CancellationToken cancellationToken)
        {
            return await chatService.GetMessagesForChat(request.ChatId);
        }
    }
}
