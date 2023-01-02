using APIAndJWT.Domain.Models;
using APIAndJWT.Domain.Repositories;
using APIAndJWT.Domain.Responses;
using APIAndJWT.Domain.Services;
using APIAndJWT.Domain.UnitOfWork;

namespace APIAndJWT.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IUnitOfWork unitOfWork;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            this.productRepository = productRepository;
            this.unitOfWork = unitOfWork;
        }
    
        public async Task<ProductResponse> AddProduct(Product product)
        {
            try
            {
                await productRepository.AddProductAsync(product);
                await unitOfWork.CompleteAsync();
                return new ProductResponse(product);
            }
            catch (Exception ex)
            {
                return new ProductResponse($"Ürün eklenirken bir hata oluştu::{ex.Message}");
            }
        }

        public async Task<ProductResponse> FindByIdAsync(int productId)
        {
            try
            {
                Product product = await productRepository.FindByIdAsync(productId);
                if (product == null)
                {
                    return new ProductResponse("Ürün bulunamadı.");
                }
                return new ProductResponse(product);
            }
            catch (Exception ex)
            {
                return new ProductResponse($"Ürün bulunurken bir hata oluştu::{ex.Message}");
            }
        }

        public async Task<ProductListResponse> ListAsync()
        {
            try
            {
                IEnumerable<Product> products = await productRepository.ListAsync();
                return new ProductListResponse(products);
            }
            catch (Exception ex)
            {
                return new ProductListResponse($"Ürün listelenirken hata oluştu::{ex.Message}");
            }
        }

        public async Task<ProductResponse> RemoveProduct(int productId)
        {
            try
            {
                Product product = await productRepository.FindByIdAsync(productId);
                if (product == null)
                {
                    return new ProductResponse("Silmeye çalıştığınız ürün bulunamadı.");
                }
                else
                {
                    await productRepository.RemoveProductAsync(productId);
                    await unitOfWork.CompleteAsync();
                    return new ProductResponse(product);
                }
            }
            catch (Exception ex )
            {
                return new ProductResponse($"Ürün silmeye çalışılırken hata oluştu::{ex.Message}");
            }
        }

        public async Task<ProductResponse> UpdateResponse(Product product, int productId)
        {
            try
            {
                var firstProduct = await productRepository.FindByIdAsync(productId);
                if (firstProduct == null)
                {
                    return new ProductResponse("Güncellemeye çalıştığınız ürün bulunamadı.");
                }

                firstProduct.Name=product.Name;
                firstProduct.Category=product.Category;
                firstProduct.Price= product.Price;

                productRepository.UpdateProduct(firstProduct);

                await unitOfWork.CompleteAsync();
                return new ProductResponse(firstProduct);
            }
            catch (Exception ex)
            {
                return new ProductResponse($"Ürün güncellenirken hata oluştu::{ex.Message}");
            }
        }
    }
}
