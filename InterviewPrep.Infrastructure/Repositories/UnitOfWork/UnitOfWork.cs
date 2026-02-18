using InterviewPrep.Infrastructure.Persistence;
using InterviewPrep.Infrastructure.Repositories.OrderRepository;
using InterviewPrep.Infrastructure.Repositories.ProductRepository;
using InterviewPrep.Infrastructure.Repositories.UnitOfWork;
using Microsoft.EntityFrameworkCore.Storage;

namespace InterviewPrep.Infrastructure.Repositories.UnitOfWork;

public class UnitOfWork(
    ApplicationDbContext context,
    IProductRepository productRepository,
    IOrderRepository orderRepository)
    : IUnitOfWork
{
    private IDbContextTransaction? _transaction;

    public IProductRepository Products { get; } = productRepository;
    public IOrderRepository Orders { get; } = orderRepository;

    public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
    {
        return await context.SaveChangesAsync(cancellationToken);
    }

    public async Task BeginTransactionAsync()
    {
        _transaction = await context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        if (_transaction != null)
        {
            await _transaction.CommitAsync();
            await _transaction.DisposeAsync();
        }
    }

    public async Task RollbackTransactionAsync()
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
        }
    }

    public void Dispose()
    {
        context.Dispose();
    }
}