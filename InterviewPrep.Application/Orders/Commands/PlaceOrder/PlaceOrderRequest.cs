using MediatR;

namespace InterviewPrep.Application.Orders.Commands.PlaceOrder;


public record OrderLineDto(long ProductId, int Quantity);

public record PlaceOrderRequest(List<OrderLineDto> OrderLines) : IRequest<long>;
