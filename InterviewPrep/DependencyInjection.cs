using System.Reflection;
using InterviewPrep.Application.Products.GetProducts;

namespace InterviewPrep;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        return services;
    }
}