using Microsoft.Azure.EventHubs;
using MyApi.Commands.Abstractions;
using MyApi.Commands.Abstractions.Requests;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace MyApi.Commands
{
    public class SendMessageCommand : ISendMessageCommand
    {
        private readonly IConfiguration _configuration;

        public SendMessageCommand(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public string FormatMessage(string message)
        {
            return message.ToLower();
        }

        public async Task SendMessageAsync(MessageRequest request)
        {
            var connectionString = _configuration.GetValue<string>("EventHubs:ConnectionString");

            var eventHubClient = EventHubClient.CreateFromConnectionString(connectionString);
            var formattedMessage = FormatMessage(request.Body);
            await eventHubClient.SendAsync(new EventData(Encoding.UTF8.GetBytes(formattedMessage)));

            return;
        }
    }
}
