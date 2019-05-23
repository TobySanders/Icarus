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
            _subject = new SendMessageCommand(configuration.Object);
        }
        [Fact]
        public void FormatMessage_ValidData_ReturnsFormattedMessage()
        {
            var testMessage = "HelloWorld";
            var expectedResult = "helloworld";
            var result = _subject.FormatMessage(testMessage);

            Assert.Equal(expectedResult, result);
        }
    }
}
