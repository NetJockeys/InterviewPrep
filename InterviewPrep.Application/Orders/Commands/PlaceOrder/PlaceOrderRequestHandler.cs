using InterviewPrep.Domain.Entities;
using InterviewPrep.Infrastructure;
using InterviewPrep.Infrastructure.Repositories.OrderRepository;
using InterviewPrep.Infrastructure.Repositories.ProductRepository;
using InterviewPrep.Infrastructure.Repositories.UnitOfWork;
using MediatR;

namespace InterviewPrep.Application.Orders.Commands.PlaceOrder;

public class PlaceOrderRequestHandler(
    IUnitOfWork unitOfWork
    ) : IRequestHandler<PlaceOrderRequest, long>
{
    public async Task<long> Handle(PlaceOrderRequest request, CancellationToken cancellationToken)
    {
        var order = new Order();
        var orderLines = request.OrderLines.Select(x => new OrderLine
        {
            ProductId = x.ProductId,
            Quantity = x.Quantity
        });
        order.AddOrderLines(orderLines);

        await unitOfWork.Orders.AddOrderAsync(order, cancellationToken);
        await unitOfWork.CommitAsync(cancellationToken);

        return order.OrderId;
    }
}