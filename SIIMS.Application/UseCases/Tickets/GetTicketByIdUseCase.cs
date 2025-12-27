using SIIMS.Application.Common;
using SIIMS.Application.DTOs.Tickets;
using SIIMS.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIIMS.Application.UseCases.Tickets
{
    /// <summary>
    /// Handles retrieval of a ticket by its identifier.
    /// </summary>
    public class GetTicketByIdUseCase
    {
        private readonly ITicketRepository _ticketRepository;

        public GetTicketByIdUseCase(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        /// <summary>
        /// Retrieves ticket details for a given ticket ID.
        /// </summary>
        public async Task<TicketDetailsDto> ExecuteAsync(Guid ticketId)
        {
            var ticket = await _ticketRepository.GetByIdAsync(ticketId);
            if(ticket == null)
            {
                throw new NotFoundException($"Ticket with ID '{ticketId}' was not found.");
            }

            return new TicketDetailsDto
            {
                Id = ticket.Id,
                Title = ticket.Title,
                Description = ticket.Description,
                Category = ticket.Category,
                Priority = ticket.Priority,
                Status = ticket.Status,
                CreatedByUserId = ticket.CreatedByUserId,
                AssignedToUserId = ticket.AssignedToUserId,
                CreatedAt = ticket.CreatedAt,
                UpdatedAt = ticket.UpdatedAt
            };
        }
        
    }

}
