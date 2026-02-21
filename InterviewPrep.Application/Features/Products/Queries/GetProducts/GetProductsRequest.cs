using InterviewPrep.Application.ViewModels;
using InterviewPrep.Infrastructure;
using MediatR;

namespace InterviewPrep.Application.Products.GetProducts;

public record GetProductsRequest : IRequest<IEnumerable<ReadProductViewModel>>
{
    
}