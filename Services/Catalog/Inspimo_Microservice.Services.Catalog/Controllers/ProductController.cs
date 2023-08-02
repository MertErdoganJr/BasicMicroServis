using Inspimo_Microservice.Services.Catalog.Dtos;
using Inspimo_Microservice.Services.Catalog.Services.Abstract;
using Inspimo_MicroService.Shared.ControllerBases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Inspimo_Microservice.Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]  
    public class ProductController : CustomBaseController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _productService.GetAllAsync();
            return CreateActionResultInstance(values);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProductDto createProductDto)
        {
            var value = await _productService.CreateAsync(createProductDto);
            return CreateActionResultInstance(value);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var values = await _productService.DeleteAsync(id);
            return CreateActionResultInstance(values);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            var values = await _productService.UpdateAsync(updateProductDto);
            return CreateActionResultInstance(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdProduct(string id)
        {
            var values = await _productService.GetByIdAsync(id);
            return CreateActionResultInstance(values);
        }
    }
}
