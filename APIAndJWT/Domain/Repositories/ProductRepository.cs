using APIAndJWT.Domain.Entities;
using APIAndJWT.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace APIAndJWT.Domain.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(UdemyAPIContext context):base(context)
        {
        }

        public async Task AddProductAsync(Product product)
        {
            await context.Products.AddAsync(product);
        }

        public async Task<Product> FindByIdAsync(int productId)
        {
            return await context.Products.FindAsync(productId);
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await context.Products.ToListAsync();
        }

        public async Task RemoveProductAsync(int productId)
        {
            var product = await FindByIdAsync(productId);
            context.Products.Remove(product);
        }

        public void UpdateProduct(Product product)
        {
            context.Products.Update(product);
        }
    }
}
