using SIIMS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIIMS.Application.DTOs.Tickets
{
    /// <summary>
    /// DTO representing ticket details returned to API consumers.
    /// </summary>
    public class TicketDetailsDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public TicketCategory Category { get; set; }

        public TicketPriority Priority { get; set; }

        public TicketStatus Status { get; set; }

        public Guid CreatedByUserId { get; set;  }

        public Guid? AssignedToUserId { get; set;  }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
