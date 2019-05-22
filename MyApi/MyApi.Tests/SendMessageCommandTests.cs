using Microsoft.Extensions.Configuration;
using Moq;
using MyApi.Commands;
using MyApi.Commands.Abstractions;
using Xunit;

namespace MyApi.Tests
{
    public class SendMessageCommandTests
    {
        private readonly ISendMessageCommand _subject;
        public SendMessageCommandTests()
        {
            var configuration = new Mock<IConfiguration>();
            //configuration.Setup(Config => Config.GetValue<string>("EventHubs:ConnectionString")).Returns((string s)=> "ConnectionString");
            //configuration.Setup(Config => Config.GetValue<string>("EventHubs:EventHubsName")).Returns((string s)=>"EventHubsName");
            _subject = new SendMessageCommand(configuration.Object);
        }
        [Fact]
        public void FormatMessage_ValidData_ReturnsFormattedMessage()
        {
            var testMessage = "HelloWorld";
            var expectedResult = "asdhjakshdkajsd";
            var result = _subject.FormatMessage(testMessage);

            Assert.Equal(expectedResult, result);
        }
    }
}
