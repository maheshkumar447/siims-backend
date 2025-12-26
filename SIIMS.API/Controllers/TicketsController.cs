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

        public TicketsController(CreateTicketUseCase createTicketUseCase)
        {
            _createTicketUseCase = createTicketUseCase;
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
    }
}
