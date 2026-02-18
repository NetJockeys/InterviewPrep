using InterviewPrep.Domain.Entities;
using InterviewPrep.Infrastructure.Persistence;

namespace InterviewPrep.Infrastructure.Repositories.ProductRepository;

public class ProductRepository(ApplicationDbContext context) : IProductRepository
{
    public async Task AddProductAsync(Product product, CancellationToken cancellationToken)
    {
        await context.Products.AddAsync(product, cancellationToken);
    }
}