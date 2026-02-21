using AutoMapper;
using InterviewPrep.Application.Products.GetProducts;
using InterviewPrep.Application.ViewModels;
using InterviewPrep.Infrastructure.Persistence;
using MediatR;

namespace InterviewPrep.Application.Features.Products.Queries.GetProducts;

public class GetProductsRequestHandler(
        ApplicationDbContext context,
        IMapper mapper
    )
    : IRequestHandler<GetProductsRequest, IEnumerable<ReadProductViewModel>>
{
    public async Task<IEnumerable<ReadProductViewModel>> Handle(GetProductsRequest request, CancellationToken cancellationToken)
    {
        var products = await context.Products
            .AsAsyncEnumerable()
            .ToListAsync(cancellationToken);
        
        return mapper.Map<IEnumerable<ReadProductViewModel>>(products);
    }
}