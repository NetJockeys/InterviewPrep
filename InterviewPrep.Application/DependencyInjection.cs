using FluentValidation;
using InterviewPrep.Application.Products.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace InterviewPrep.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(DependencyInjection).Assembly;
        
        services.AddAutoMapper(cfg => { }, assembly);
        
        services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly));
        
        services.AddValidatorsFromAssembly(assembly);
        return services;
    }
}