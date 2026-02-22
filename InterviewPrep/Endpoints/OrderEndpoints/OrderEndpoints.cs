using InterviewPrep.Api.Endpoints;
using InterviewPrep.Application.Features.Orders.Queries.GetOrder;
using InterviewPrep.Application.Features.Orders.ViewModels;
using InterviewPrep.HttpResponses;
using MediatR;

namespace InterviewPrep.Endpoints.OrderEndpoints;

public class OrderEndpoints : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/orders")
            .WithTags("Orders");

        group.MapGet("/{orderId:long}", async (long orderId, IMediator mediator) =>
            {
                var result = await mediator.Send(new GetOrderByIdRequest(orderId));
                return result.ToMinimalApiResult();
            })
            .WithName("GetOrder")
            .Produces<ReadOrderViewModel>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status400BadRequest);

    }
}