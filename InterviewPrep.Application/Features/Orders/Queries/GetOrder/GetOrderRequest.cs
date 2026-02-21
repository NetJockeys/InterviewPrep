using InterviewPrep.Application.Shared.DataTransfer;
using InterviewPrep.Infrastructure.OrderContracts;
using MediatR;

namespace InterviewPrep.Application.Features.Orders.Queries.GetOrder;

public record GetOrderByIdRequest(long OrderId) : IRequest<HandlerResponseDto<ReadOrderContract>>;
