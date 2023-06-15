using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TicketFlow.Application.Common.Interfaces;
using TicketFlow.Application.TodoItems.Commands.CreateTodoItem;
using TicketFlow.Domain.Entities;
using TicketFlow.Domain.Enums;
using TicketFlow.Domain.Events;

namespace TicketFlow.Application.Tickets.Commands.CreateTicket;
public class CreateTicketCommand : IRequest<int>
{
    public int CategoryId { get; init; }

    public string? Title { get; init; }

    public string? Description { get; init; }

    public PriorityLevel? Priority { get; init; }
}

public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateTicketCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
    {
        var entity = new Ticket
        {
            CategoryId = request.CategoryId,
            Title = request.Title,
            Description = request.Description,
            Status = Status.Open,
            Priority = request.Priority,
        };

        entity.AddDomainEvent(new TicketCreatedEvent(entity));

        _context.Tickets.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }

}
