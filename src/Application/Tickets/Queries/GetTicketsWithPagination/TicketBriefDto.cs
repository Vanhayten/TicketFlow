using TicketFlow.Application.Common.Mappings;
using TicketFlow.Domain.Entities;

namespace TicketFlow.Application.Tickets.Queries.GetTicketsWithPagination;

public class TicketBriefDto : IMapFrom<Ticket>
{
    public int Id { get; set; }

    public int CategoryId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

}
