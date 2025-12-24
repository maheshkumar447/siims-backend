using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIIMS.Domain.Enums
{
    /// <summary>
    /// Defines the urgency level of a ticket.
    /// Used for SLA calculations and prioritization.
    /// </summary>
    public enum TicketPriority
    {
        Low = 1,    
        Medium = 2,
        High = 3,
        Critical = 4
    }
}
