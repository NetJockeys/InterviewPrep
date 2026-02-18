using System.Reflection;
using InterviewPrep.Infrastructure.Persistence;
using InterviewPrep.Infrastructure.Repositories.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InterviewPrep.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer("Server=127.0.0.1;Database=InterviewPrep;User Id=sa;Password=ASmith25;TrustServerCertificate=True;"));
       
        
        var assembly = Assembly.GetExecutingAssembly(); // Or typeof(ProductRepository).Assembly
        services.Scan(scan => scan
            .FromAssemblyOf<UnitOfWork>() // Infrastructure assembly
            .AddClasses(classes => classes.InNamespaces("InterviewPrep.Infrastructure.Repositories"))
            .AsImplementedInterfaces()
            .WithScopedLifetime()
        );
        
        return services;
    }
}