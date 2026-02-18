using InterviewPrep.Domain.Entities;
using InterviewPrep.Infrastructure.Repositories.ProductRepository;
using InterviewPrep.Infrastructure.Repositories.UnitOfWork;
using MediatR;

namespace InterviewPrep.Application.Products.Commands.CreateProduct;

public class CreateProductRequestHandler(
    IProductRepository productRepository,
    IUnitOfWork unitOfWork
    ) : IRequestHandler<CreateProductRequest, long>
{
    public async Task<long> Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            ProductDescription = request.ProductDescription,
            ProductPrice = request.ProductPrice
        };

        await productRepository.AddProductAsync(product, cancellationToken);
        await unitOfWork.CommitAsync(cancellationToken);

        return product.ProductId;
    }
}