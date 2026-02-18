using InterviewPrep.Infrastructure.Repositories.OrderRepository;
using InterviewPrep.Infrastructure.Repositories.ProductRepository;

namespace InterviewPrep.Infrastructure.Repositories.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IProductRepository Products { get; }
    IOrderRepository Orders { get; }

    Task<int> CommitAsync(CancellationToken cancellationToken = default);
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}