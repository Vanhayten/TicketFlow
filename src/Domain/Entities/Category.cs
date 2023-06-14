using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketFlow.Domain.Entities;
public class Category : BaseAuditableEntity
{
    public string? Title { get; set; }
    public IList<Ticket> Tickets { get; private set; } = new List<Ticket>();
}
