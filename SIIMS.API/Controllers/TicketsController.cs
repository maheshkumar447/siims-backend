using Microsoft.AspNetCore.Mvc;
using SIIMS.Application.DTOs.Tickets;
using SIIMS.Application.UseCases.Tickets;

namespace SIIMS.API.Controllers
{
    /// <summary>
    /// Exposes APIs related to ticket management.
    /// Acts as a thin layer delegating work to Application use cases.
    /// </summary>  

    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly CreateTicketUseCase _createTicketUseCase;
        private readonly GetTicketByIdUseCase _getTicketByIdUseCase;

        public TicketsController(CreateTicketUseCase createTicketUseCase, GetTicketByIdUseCase getTicketByIdUseCase)
        {
            _createTicketUseCase = createTicketUseCase;
            _getTicketByIdUseCase = getTicketByIdUseCase;
        }

        /// <summary>
        /// Creates a new support ticket.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateTicket([FromBody] CreateTicketRequestDto request)
        {
            var result = await _createTicketUseCase.ExecuteAsync(request);
            return CreatedAtAction(nameof(CreateTicket), result);
        }

        /// <summary>
        /// Retrieves a ticket by its unique identifier.
        /// </summary>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetTicketById(Guid id)
        {
            var ticket = await _getTicketByIdUseCase.ExecuteAsync(id);
            return Ok(ticket);
        }
    }
}
