using APIAndJWT.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using APIAndJWT.Domain.Responses;
using APIAndJWT.Resources;
using APIAndJWT.Extentions;
using APIAndJWT.Domain.Models;

namespace APIAndJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            ProductListResponse productListResponse = await productService.ListAsync();
            if (productListResponse.Success)
            {
                return Ok(productListResponse.productList);
            }
            else
            {
                return BadRequest(productListResponse.Message);
            }
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetFindById(int id)
        {
            ProductResponse productResponse = await productService.FindByIdAsync(id);
            if (productResponse.Success)
            {
                return Ok(productResponse.Product);
            }
            else
            {
                return BadRequest(productResponse.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductResource productResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages()); //Name,Category ve Price boş gönderilirse burda hata verecek.
            }
            {
                Product product =mapper.Map<ProductResource,Product>(productResource);
                var Response = await productService.AddProduct(product);
                if (Response.Success)
                {
                    return Ok(Response.Product);
                }
                else
                {
                    return BadRequest(Response.Message);
                }
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(ProductResource productResource,int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            else
            {
                Product product = mapper.Map<ProductResource, Product>(productResource);
                var response = await productService.UpdateProduct(product, id);
                if (response.Success)
                {
                    return Ok(response.Product);
                }
                else
                {
                    return BadRequest(response.Message);
                }
                
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> RemoveProduct(int id)
        {
            ProductResponse response = await productService.RemoveProduct(id);
            if (response.Success)
            {
                return Ok(response.Product);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        //Silme işlemini id'ye göre değil isme ve kategorisine göre silme 
        //[HttpDelete("{name}/{category}")]
        //public async Task<IActionResult> RemoveProduct(string name, string category)
        //{
        //    ProductResponse response = await productService.RemoveProduct(name,category);
        //    if (response.Success)
        //    {
        //        return Ok(response.Product);
        //    }
        //    else
        //    {
        //        return BadRequest(response.Message);
        //    }
        //}
    }
}
