using TicketFlow.Application.TodoLists.Queries.ExportTodos;

namespace TicketFlow.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}
