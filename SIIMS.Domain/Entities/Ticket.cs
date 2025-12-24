using SIIMS.Domain.Common;
using SIIMS.Domain.Enums;
using SIIMS.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIIMS.Domain.Entities
{
    /// <summary>
    /// Represents a support ticket raised by a user.
    /// This entity contains core business data and rules related to a ticket.
    /// Question: Why private set?
    /// </summary>
    public class Ticket : BaseEntity
    {
        public string Title { get; private set; }
        public string Description { get; private set; }

        public TicketCategory Category { get; private set; }

        public TicketPriority Priority { get; private set; }

        public TicketStatus Status { get; private set; }

        public Guid CreatedByUserId { get; private set; }

        public Guid? AssignedToUserId { get; private set; }

        //EF Core requirement
        private Ticket() { }

        public Ticket(string title, string description, TicketCategory category, TicketPriority priority, Guid createdByUserId)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new InvalidTicketDataException("Ticket title cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                throw new InvalidTicketDataException("Ticket description cannot be empty.");
            }
            Title = title;
            Description = description;
            Category = category;
            Priority = priority;
            Status = TicketStatus.Open;
            CreatedByUserId = createdByUserId;
        }

        /// <summary>
        /// Assigns the ticket to a support engineer.
        /// </summary>
        public void AssignTo(Guid userId)
        {
            if(Status == TicketStatus.Closed)
            {
                throw new InvalidTicketOperationException("Cannot assign a ticket that is already closed.");
            }
            AssignedToUserId = userId;
            Status = TicketStatus.InProgress;
            MarkAsUpdated();
        }

        /// <summary>
        /// Updates the status of the ticket.
        /// Business rules can be enforced here.
        /// </summary>
        public void UpdateStatus(TicketStatus newStatus)
        {
            if (Status == TicketStatus.Closed)
                throw new InvalidTicketOperationException(
                    "Closed tickets cannot change status.");

            if (Status == TicketStatus.Open && newStatus == TicketStatus.Closed)
                throw new InvalidTicketOperationException(
                    "Ticket must be resolved before closing.");

            Status = newStatus;
            MarkAsUpdated();
        }
    }
}
