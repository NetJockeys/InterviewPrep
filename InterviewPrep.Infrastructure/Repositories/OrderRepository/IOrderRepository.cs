using InterviewPrep.Domain.Entities;

namespace InterviewPrep.Infrastructure.Repositories.OrderRepository;

public interface IOrderRepository
{
    Task AddOrderAsync(Order order, CancellationToken cancellationToken);
}