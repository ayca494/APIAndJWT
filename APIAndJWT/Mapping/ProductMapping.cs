using APIAndJWT.Domain.Models;
using APIAndJWT.Resources;
using AutoMapper;
namespace APIAndJWT.Mapping
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<ProductResource, Product>();
            CreateMap<Product, ProductResource>();

        }
    }
}
