using AutoMapper;
using Cimas.Entities.Products;
using Cimas.Models.From;
using Cimas.Models.To;
using Cimas.Service.Products;
using Cimas.Service.Products.Descriptors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cimas.Controllers
{
    [Authorize(Roles = "Worker")]
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public ProductController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        [HttpPost("add")]
        public async Task<int> AddProduct(AddProductModel model)
        {
            var descriptor = _mapper.Map<AddProductDescriptor>(model);
            return await _productService.AddProductAsync(descriptor);
        }

        [HttpPut("items/edit")]
        public async Task EditProducts([FromBody] EditProductModel[] models)
        {
            var descriptors = _mapper.Map<IEnumerable<EditProductDescriptor>>(models);
            await _productService.EditProductsAsync(descriptors);
        }

        [HttpDelete("del/{productId}")]
        public async Task DeleteProduct(int productId)
        {
            await _productService.DeleteProductAsync(productId);
        }

        [HttpGet("items/{workDayId}")]
        public async Task<IEnumerable<ProductResponse>> GetProductsByWorkDayId(int workDayId)
        {
            var products = await _productService.GetProductsByWorkDayIdAsync(workDayId);
            return _mapper.Map<IEnumerable<ProductResponse>>(products);
        }
    }
}
