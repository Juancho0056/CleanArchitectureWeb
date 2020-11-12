using CleanArchitecture.Application.CommandsQueries.TodoBasics.Commands.Create;
using CleanArchitecture.Application.Common.Behaviours;
using CleanArchitecture.Application.Common.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.UnitTests.Common.Behaviours
{
    public class RequestLoggerTests
    {
        private readonly Mock<ILogger<CreateTodoBasicRequest>> _logger;
        private readonly Mock<ICurrentUserService> _currentUserService;


        public RequestLoggerTests()
        {
            _logger = new Mock<ILogger<CreateTodoBasicRequest>>();

            _currentUserService = new Mock<ICurrentUserService>();

        }

        [Test]
        public async Task ShouldCallGetUserNameAsyncOnceIfAuthenticated()
        {
            _currentUserService.Setup(x => x.UserId).Returns("Administrator");

            var requestLogger = new LoggingBehaviour<CreateTodoBasicRequest>(_logger.Object, _currentUserService.Object);

            await requestLogger.Process(new CreateTodoBasicRequest {  Title = "title" }, new CancellationToken());

        }

        [Test]
        public async Task ShouldNotCallGetUserNameAsyncOnceIfUnauthenticated()
        {
            var requestLogger = new LoggingBehaviour<CreateTodoBasicRequest>(_logger.Object, _currentUserService.Object);

            await requestLogger.Process(new CreateTodoBasicRequest { Title = "title" }, new CancellationToken());

        }
    }
}
