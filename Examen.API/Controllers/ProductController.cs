using Examen.API.Contracts;
using Examen.API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Examen.API.Controllers
{
    [ApiController]
    [Route("v1/products")]
    [ApiVersion("1")]
    public class CompaniesController : ControllerBase
    {
        private readonly IProductRepository _productRepo;

        public CompaniesController(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var products = await _productRepo.GetProducts();

                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<IActionResult> GetProduct(int id)
        {
            try
            {
                var product = await _productRepo.GetProduct(id);

                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            try
            {
                var createdProduct = await _productRepo.CreateProduct(product);
                return CreatedAtRoute("GetProduct", new { id = createdProduct.Id }, createdProduct);
               
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            try
            {
                var dbProduct = await _productRepo.GetProduct(id);

                if (dbProduct == null)
                    return NotFound();

                await _productRepo.UpdateProduct(id, product);
                return NoContent();
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var dbProduct = await _productRepo.GetProduct(id);

                if (dbProduct == null)
                    return NotFound();

                await _productRepo.DeleteProduct(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
    }
}
