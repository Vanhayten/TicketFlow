using TicketFlow.Application.Common.Exceptions;
using TicketFlow.Application.TodoItems.Commands.CreateTodoItem;
using TicketFlow.Application.TodoItems.Commands.DeleteTodoItem;
using TicketFlow.Application.TodoLists.Commands.CreateTodoList;
using TicketFlow.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace TicketFlow.Application.IntegrationTests.TodoItems.Commands;

using static Testing;

public class DeleteTodoItemTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidTodoItemId()
    {
        var command = new DeleteTodoItemCommand(99);

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteTodoItem()
    {
        var listId = await SendAsync(new CreateTodoListCommand
        {
            Title = "New List"
        });

        var itemId = await SendAsync(new CreateTodoItemCommand
        {
            ListId = listId,
            Title = "New Item"
        });

        await SendAsync(new DeleteTodoItemCommand(itemId));

        var item = await FindAsync<TodoItem>(itemId);

        item.Should().BeNull();
    }
}
