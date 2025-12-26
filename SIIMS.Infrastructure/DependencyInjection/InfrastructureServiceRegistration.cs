using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SIIMS.Application.Interfaces.Repositories;
using SIIMS.Infrastructure.Persistence.Context;
using SIIMS.Infrastructure.Persistence.Repositories;

namespace SIIMS.Infrastructure.DependencyInjection
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Register DbContext with SQL Server
            services.AddDbContext<SIIMSDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Register repositories
            services.AddScoped<ITicketRepository, TicketRepository>();

            return services;    
        }
    }
}
