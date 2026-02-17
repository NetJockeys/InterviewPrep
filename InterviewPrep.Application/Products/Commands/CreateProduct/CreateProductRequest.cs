using InterviewPrep.Application.ViewModels;
using MediatR;

namespace InterviewPrep.Application.Products.Commands.CreateProduct;

public record CreateProductRequest( 
    string? ProductDescription ,
    decimal? ProductPrice
    ) : IRequest<long>;