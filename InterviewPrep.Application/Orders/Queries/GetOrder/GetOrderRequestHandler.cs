using InterviewPrep.Application.Orders.ViewModels;
using InterviewPrep.Infrastructure.Persistence;
using InterviewPrep.Infrastructure.Repositories.OrderRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InterviewPrep.Application.Orders.Queries.GetOrder;

public class GetOrderRequestHandler(ApplicationDbContext context)
    : IRequestHandler<GetOrderByIdRequest, ReadOrderViewModel>
{
    public async Task<ReadOrderViewModel> Handle(GetOrderByIdRequest request, CancellationToken cancellationToken)
    {
        var result = await context.Orders
            .Where(o => o.OrderId == request.OrderId)
            .Select(o => new ReadOrderViewModel
            {
                OrderId = o.OrderId,
                DatePlaced = o.DatePlaced,
                OrderLines = o.OrderLines
                    .Select(ol => new ReadOrderLineViewModel
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
        return result!;
    }
}