using InterviewPrep.Domain.Entities;
using InterviewPrep.Infrastructure.Persistence;

namespace InterviewPrep.Infrastructure.Repositories.OrderRepository;

public class OrderRepository(ApplicationDbContext context) : IOrderRepository
{
    public async Task AddOrderAsync(Order order, CancellationToken cancellationToken)
    {
        await context.Orders.AddAsync(order, cancellationToken);
    }
}