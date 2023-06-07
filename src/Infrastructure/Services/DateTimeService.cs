using TicketFlow.Application.Common.Interfaces;

namespace TicketFlow.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
