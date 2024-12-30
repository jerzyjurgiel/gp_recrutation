using GP_Chatbot.Models;
using GP_Chatbot.Models.Dto;
using GP_Chatbot.Models.Mediator;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GP_Chatbot.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MessageController(IMediator mediator) : Controller
    {
        [HttpPost]
        public async Task<ActionResult<SendMessageResponse>> SendMessage(SendMessageRequest request)
        {
            var result = await mediator.Send(new MsgRequest()
            {
                ChatId = request.ChatId,
                Message = request.Message,
            });
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<SendMessageResponse>> CancelMessage(CancelMessageDto request)
        {
            await mediator.Send(new CancelRequest() { Message = request.Message, MessageId = request.MessageId });
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> RateMessage(RateMessageDto request)
        {
            await mediator.Send(new ApprovalRequest { Approval = request.Approval, MsgId = request.MsgId });
            return NoContent();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChatMessageDto>>> GetMessages(int? chatId)
        {
            if (!chatId.HasValue)
            {
                return new List<ChatMessageDto>();
            }
            else
            {
                var list = await mediator.Send(new GetMessagesRequest { ChatId = chatId.Value });
                return Ok(list);
            }
        }
    }
}
