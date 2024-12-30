using GP_Chatbot.Logic.Ai;
using GP_Chatbot.Logic.Chatbot;
using GP_Chatbot.Models.Dto;
using GP_Chatbot.Models.Entities;
using GP_Chatbot.Models.Mediator;
using MediatR;

namespace GP_Chatbot.Mediators
{
    public class ChatHandler(IChatService chatService, IAiService aiService) : IRequestHandler<MsgRequest, ChatMessageDto>
    {
        public async Task<ChatMessageDto> Handle(MsgRequest request, CancellationToken cancellationToken)
        {
            var addedMsg = await chatService.SaveMessage(request.Message, request.ChatId);
            var prompt = await aiService.GenerateResponseFromPrompt(request.Message);
            var aiMsg = await chatService.SaveMessage(prompt, addedMsg.ChatId, true);
            return new ChatMessageDto(aiMsg);
        }
    }
}
