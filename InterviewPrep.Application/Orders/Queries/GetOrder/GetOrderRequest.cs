using InterviewPrep.Application.Orders.ViewModels;
using MediatR;

namespace InterviewPrep.Application.Orders.Queries.GetOrder;

public record GetOrderByIdRequest(long OrderId) : IRequest<ReadOrderViewModel>;
