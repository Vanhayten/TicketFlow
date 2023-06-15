
namespace TicketFlow.Domain.Events;
public class TicketCreatedEvent : BaseEvent
{
    public TicketCreatedEvent(Ticket item)
    {
        Item = item;
    }

    public Ticket Item { get; }
}
