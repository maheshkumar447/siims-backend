using SIIMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIIMS.Application.Interfaces.Repositories
{
    /// <summary>
    /// Defines data access operations for Ticket entity.
    /// This interface is implemented in the Infrastructure layer.
    /// </summary>
    public interface ITicketRepository
    {
        Task AddAsync(Ticket ticket);

        Task<Ticket?> GeByIdAsync(Guid ticketId);

        Task UpdateAsync(Ticket ticket);
    }
}
