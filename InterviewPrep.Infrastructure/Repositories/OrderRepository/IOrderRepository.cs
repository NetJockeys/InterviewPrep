using InterviewPrep.Domain.Entities;
using InterviewPrep.Infrastructure.OrderContracts;

namespace InterviewPrep.Infrastructure.Repositories.OrderRepository;

public interface IOrderRepository
{
    Task AddOrderAsync(Order order, CancellationToken cancellationToken);
    
    Task<ReadOrderContract?> GetOrderByIdAsync(long orderId, CancellationToken cancellationToken);
}