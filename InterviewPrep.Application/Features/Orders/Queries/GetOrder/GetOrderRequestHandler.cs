using InterviewPrep.Application.Shared.DataTransfer;
using InterviewPrep.Infrastructure.OrderContracts;
using InterviewPrep.Infrastructure.Repositories.OrderRepository;
using MediatR;

namespace InterviewPrep.Application.Features.Orders.Queries.GetOrder;

public class GetOrderRequestHandler(IOrderRepository orderRepository)
    : IRequestHandler<GetOrderByIdRequest, HandlerResponseDto<ReadOrderContract>>
{
    public async Task<HandlerResponseDto<ReadOrderContract>> Handle(GetOrderByIdRequest request, CancellationToken cancellationToken)
    {
        var order = await orderRepository
            .GetOrderByIdAsync(request.OrderId, cancellationToken);

        if (order is null)
        {
            return HandlerResponseDto<ReadOrderContract>
                .FailureNotFound()
                .WithMessage("Order not found.");
        }
        
        return HandlerResponseDto<ReadOrderContract>
            .Success(order);
    }
}