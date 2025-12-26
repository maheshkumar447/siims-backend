using SIIMS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIIMS.Application.DTOs.Tickets
{
    /// <summary>
    /// DTO used to capture data required to create a new ticket.
    /// </summary>
    public class CreateTicketRequestDto
    {
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public TicketCategory Category { get; set; }

        public TicketPriority Priority { get; set; }

        public Guid CreatedByUserId { get; set; }

    }
}
