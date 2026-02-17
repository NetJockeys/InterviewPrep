using AutoMapper;
using InterviewPrep.Application.ViewModels;
using InterviewPrep.Domain.Entities;
using InterviewPrep.Infrastructure;

namespace InterviewPrep.Application.Products.Mappings;

public class ProductMappingProfile : Profile
{
    public  ProductMappingProfile()
    {
        CreateMap<Product, ReadProductViewModel>();
    }
}