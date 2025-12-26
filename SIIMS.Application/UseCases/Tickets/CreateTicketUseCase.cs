using SIIMS.Application.DTOs.Tickets;
using SIIMS.Application.Interfaces.Repositories;
using SIIMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIIMS.Application.UseCases.Tickets
{
    /// <summary>
    /// Handles the business workflow for creating a new ticket.
    /// Demonstrates Dependency Injection and clean separation of concerns.
    /// </summary>
    public class CreateTicketUseCase
    {
        private readonly ITicketRepository _ticketRepository;

        public CreateTicketUseCase(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<CreateTicketResponseDto> ExecuteAsync(CreateTicketRequestDto request)
        {
            // 1. Create domain entity (business rules enforced inside Ticket)
            var ticket = new Ticket(request.Title, request.Description, request.Category, request.Priority,
                request.CreatedByUserId);

            // 2. Persist entity using repository abstraction
            await _ticketRepository.AddAsync(ticket);

            // 3. Return response DTO
            return new CreateTicketResponseDto
            {
                TicketId = ticket.Id
            };
        }

    }
}
