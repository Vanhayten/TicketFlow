using TicketFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace TicketFlow.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    DbSet<Category> Categories { get; }

    DbSet<Ticket> Tickets { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
