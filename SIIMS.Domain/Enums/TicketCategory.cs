using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIIMS.Domain.Enums
{
    /// <summary>
    /// Defines the functional category of a ticket.
    /// Helps in routing and analytics.
    /// </summary>
    public enum TicketCategory
    {
        Bug = 1,
        Incident = 2,
        FeatureRequest = 3,
        ServiceRequest = 4
    }
}
