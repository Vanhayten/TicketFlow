using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketFlow.Domain.Entities;
public class Category : BaseAuditableEntity
{
    public string? title { get; set; }
    public ICollection<Ticket>? Tickets { get; set; }
}
