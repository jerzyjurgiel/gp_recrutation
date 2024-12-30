using GP_Chatbot.Models.Dto;
using GP_Chatbot.Models.Entities;

namespace GP_Chatbot.Logic.Chatbot
{
    public interface IChatService
    {
        Task<ChatMessage> SaveMessage(string msg, int? chatId, bool isAi = false);
        Task<ChatMessageDto> CancelMessage(string msg, int? msgId);

        Task<IEnumerable<ChatMessageDto>> GetMessagesForChat(int chatId);
        Task SetMessageApproval(int msgId, bool? approval);
    }
}
