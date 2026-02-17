using InterviewPrep.Domain.Entities;
using InterviewPrep.Infrastructure;
using InterviewPrep.Infrastructure.Persistence;
using MediatR;

namespace InterviewPrep.Application.Products.Commands.CreateProduct;

public class CreateProductRequestHandler(ApplicationDbContext context) : IRequestHandler<CreateProductRequest, long>
{
    public async Task<long> Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            ProductDescription = request.ProductDescription,
            ProductPrice = request.ProductPrice
        };

        await context.AddAsync(product, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return product.ProductId;
    }
}