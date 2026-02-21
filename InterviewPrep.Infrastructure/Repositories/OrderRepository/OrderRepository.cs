using InterviewPrep.Domain.Entities;
using InterviewPrep.Infrastructure.OrderContracts;
using InterviewPrep.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace InterviewPrep.Infrastructure.Repositories.OrderRepository;

public class OrderRepository(ApplicationDbContext context) : IOrderRepository
{
    public async Task AddOrderAsync(Order order, CancellationToken cancellationToken)
    {
        await context.Orders.AddAsync(order, cancellationToken);
    }

    public async Task<ReadOrderContract?> GetOrderByIdAsync(long orderId, CancellationToken cancellationToken)
    {
       return await context.Orders
           .Where(o => o.OrderId == orderId)
           .Select(o => new ReadOrderContract
           {
               OrderId = o.OrderId,
               DatePlaced = o.DatePlaced,
               OrderLines = o.OrderLines
                   .Select(ol => new ReadOrderLineContract
                   {
                       OrderLineId = ol.OrderLineId,
                       OrderId = ol.OrderId,
                       ProductId = ol.ProductId,
                       Quantity = ol.Quantity,
                       ProductDescription = ol.Product.ProductDescription
                   })
                   .ToList()
           })
           .FirstOrDefaultAsync(cancellationToken);
    }
}