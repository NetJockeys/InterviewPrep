using System.Reflection;
using InterviewPrep.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InterviewPrep.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer("Server=127.0.0.1;Database=InterviewPrep;User Id=sa;Password=ASmith25;TrustServerCertificate=True;"));
       
        
        return services;
    }
}