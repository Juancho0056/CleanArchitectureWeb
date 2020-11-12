using CleanArchitecture.Application.CommandsQueries.TodoBasics.Commands.Create;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.IntegrationTests.TodoItems.Commands
{
    using static Testing;

    public class CreateTodoBasicTests : TestBase
    {
        [Test]
        public void ShouldRequireMinimumFields()
        {
            var command = new CreateTodoBasicRequest();

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<ValidationException>();
        }

        [Test]
        public async Task ShouldCreateTodoItem()
        {
            var userId = await RunAsDefaultUserAsync();

            
            var command = new CreateTodoBasicRequest
            {
                Title = "Tasks"
            };

            var itemId = await SendAsync(command);
            var item2 = itemId.Data.FirstOrDefault();
            var item = await FindAsync<TodoBasic>(item2.Id);

            item.Should().NotBeNull();
            item.Title.Should().Be(command.Title);
            item.CreatedBy.Should().Be(userId);
            item.Created.Should().BeCloseTo(DateTime.Now, 10000);
            item.LastModifiedBy.Should().BeNull();
            item.LastModified.Should().BeNull();
        }
    }
}
