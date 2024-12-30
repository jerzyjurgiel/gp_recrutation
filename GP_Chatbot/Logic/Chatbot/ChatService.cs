using GP_Chatbot.DAL;
using GP_Chatbot.Logic.Ai;
using GP_Chatbot.Models;
using GP_Chatbot.Models.Dto;
using GP_Chatbot.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GP_Chatbot.Logic.Chatbot
{
    public class ChatService(ChatbotContext dbContext) : IChatService
    {
        public async Task<ChatMessageDto> CancelMessage(string msg, int? msgId)
        {
            var currentMessage = await dbContext.Messages.Where(x => x.Id == msgId && x.IsAI).SingleOrDefaultAsync();
            currentMessage.Message = msg;
            dbContext.SaveChanges();
            return new ChatMessageDto(currentMessage);
        }

        public async Task<IEnumerable<ChatMessageDto>> GetMessagesForChat(int chatId)
        {
            var messages = await dbContext.Messages.Where(x => x.ChatId == chatId).Select(x => new ChatMessageDto(x)).ToListAsync();
            return messages;
        }

        public async Task<ChatMessage> SaveMessage(string msg, int? chatId, bool isAi = false)
        {
            if (!chatId.HasValue)
            {
                var chat = new Chat();
                dbContext.Chats.Add(chat);
                dbContext.SaveChanges();
                chatId = chat.Id;
            }
            var newMsg = new ChatMessage
            {
                Message = msg,
                ChatId = chatId.Value,
                IsAI = isAi
            };
            dbContext.Messages.Add(newMsg);
            dbContext.SaveChanges();
            return newMsg;
        }

        public async Task SetMessageApproval(int msgId, bool? approval)
        {
            var msg = await dbContext.Messages.Where(x => x.Id == msgId && x.IsAI).SingleOrDefaultAsync();
            if (msg == null)
            {
                throw new KeyNotFoundException();
            }
            msg.Approval = approval;
            dbContext.SaveChanges();
        }
    }
}
