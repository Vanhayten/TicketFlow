using TicketFlow.Application.Common.Mappings;
using TicketFlow.Domain.Entities;

namespace TicketFlow.Application.TodoLists.Queries.ExportTodos;

public class TodoItemRecord : IMapFrom<TodoItem>
{
    public string? Title { get; set; }

    public bool Done { get; set; }
}
