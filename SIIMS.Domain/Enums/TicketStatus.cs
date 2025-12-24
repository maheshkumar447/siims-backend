using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIIMS.Domain.Enums
{
    /// <summary>
    /// Represents the current lifecycle status of a ticket.
    /// This ensures only valid, predefined states are used.
    /// </summary>
    public enum TicketStatus
    {
        Open = 1,
        InProgress = 2,
        WaitingForResponse = 3,
        Resolved = 4,
        Closed = 5
    }
}
