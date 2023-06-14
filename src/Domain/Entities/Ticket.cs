using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketFlow.Domain.Entities;
public class Ticket : BaseAuditableEntity
{
    public int CategoryId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public Status? Status { get; set; }
    public PriorityLevel? Priority { get; set; }
    public long? AssignedId { get; set; }
    public Category Category { get; set; } = null!;

}
