using APIAndJWT.Domain.Models;
using APIAndJWT.Domain.Responses;

namespace APIAndJWT.Domain.Services
{
    public interface IProductService //Services klasorü repositories klasorü ile haberleştiği için domain altına tanımlandı Controller ile haberleşecek Services dışarda tanımlanacak.
    {
        Task<ProductListResponse> ListAsync();
        Task<ProductResponse> AddProduct(Product product);
        Task<ProductResponse> RemoveProduct(int productId);
        Task<ProductResponse> UpdateResponse(Product product, int productId);
        Task<ProductResponse> FindByIdAsync(int productId);
    }
}
