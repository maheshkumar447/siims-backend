using Microsoft.EntityFrameworkCore;
using SIIMS.Application.Interfaces.Repositories;
using SIIMS.Domain.Entities;
using SIIMS.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIIMS.Infrastructure.Persistence.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly SIIMSDbContext _dbContext;

        // Injects DbContext using Dependency Injection.
        public TicketRepository(SIIMSDbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public async Task AddAsync(Ticket ticket)
        {
            await _dbContext.Tickets.AddAsync(ticket);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Ticket?> GetByIdAsync(Guid ticketId)
        {
            return await _dbContext.Tickets.FirstOrDefaultAsync(t => t.Id == ticketId);
        }

        public async Task UpdateAsync(Ticket ticket)
        {
            _dbContext.Tickets.Update(ticket);
            await _dbContext.SaveChangesAsync();
        }
    }
}
