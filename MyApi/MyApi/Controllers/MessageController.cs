using Microsoft.AspNetCore.Mvc;
using MyApi.Commands.Abstractions;
using MyApi.Commands.Abstractions.Requests;
using System.Threading.Tasks;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    public class MessagesController : Controller
    {
        private readonly ISendMessageCommand _sendMessageCommand;

        public MessagesController(ISendMessageCommand sendMessageCommand)
        {
            _sendMessageCommand = sendMessageCommand;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody]MessageRequest request)
        {
            await _sendMessageCommand.SendMessageAsync(request);
            return new NoContentResult();
        }

        [HttpGet]
        public IActionResult GetGreeting()
        {
            return new OkObjectResult("Hello World");
        }
    }
}