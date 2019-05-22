using MyApi.Commands.Abstractions.Requests;
using System.Threading.Tasks;

namespace MyApi.Commands.Abstractions
{
    public interface ISendMessageCommand
    {
        Task SendMessageAsync(MessageRequest request);
        string FormatMessage(string message);
    }
}
