using Microsoft.AspNetCore.Mvc;
using TicketFlow.Application.Common.Models;
using TicketFlow.Application.Tickets.Commands.CreateTicket;
using TicketFlow.Application.Tickets.Queries.GetTicketsWithPagination;

namespace TicketFlow.WebUI.Controllers;

public class TicketsController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<TicketBriefDto>>> GetTicketsWithPagination([FromQuery] GetTicketsWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateTicketCommand command)
    {
        return await Mediator.Send(command);
    }

}
