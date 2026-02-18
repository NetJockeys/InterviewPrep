using InterviewPrep.Domain.Entities;

namespace InterviewPrep.Infrastructure.Repositories.ProductRepository;

public interface IProductRepository
{
    Task AddProductAsync(Product product, CancellationToken cancellationToken);
}