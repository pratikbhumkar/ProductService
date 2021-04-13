using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RefactorThis.Exceptions;
using RefactorThis.Models;
using RefactorThis.Services.Interfaces;

namespace RefactorThis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductsController> _logger;
        public ProductsController(IProductService productService, ILogger<ProductsController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetProducts([FromQuery(Name = "name")] string name)
        {
            _logger.LogInformation($"ProductsController: GetProducts with name:{name}");
            try
            {
                if (String.IsNullOrEmpty(name))
                {
                    var productList = _productService.GetProducts();
                    return Ok(productList);
                }

                var products = _productService.GetProductByName(name);
                return Ok(products);
            }
            catch (NotFoundException nfe)
            {
                return NotFound(nfe.Message);
            }
            catch (Exception e)
            {
                _logger.LogError($"ProductOptionController: Error occurred while GetProducts with name:{name}" +
                                 $", message: {e.Message}");
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(Guid id)
        {
            _logger.LogInformation($"ProductsController: GetProducts with id:{id}");
            try
            {
                var product = _productService.GetProduct(id);
                return Ok(product);
            }
            catch (NotFoundException nfe)
            {
                return NotFound(nfe.Message);
            }
            catch (Exception e)
            {
                _logger.LogError($"ProductOptionController: Error occurred while GetProductById with id:{id}" +
                                 $", message: {e.Message}");
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductDto product)
        {
            _logger.LogInformation($"ProductsController: Creating Products with id:{product.Id}");
            try
            {
                int result = _productService.SaveProduct(product);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError($"ProductOptionController: Error occurred while CreateProduct with id:{product.Id}" +
                                 $", message: {e.Message}");
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateProduct(ProductDto product)
        {
            _logger.LogInformation($"ProductsController: UpdateProduct with id:{product.Id}");
            try
            {
                int result = _productService.UpdateProduct(product);
                return Ok(result);
            }
            catch (NotFoundException nfe)
            {
                return NotFound(nfe.Message);
            }
            catch (Exception e)
            {
                _logger.LogError($"ProductOptionController: Error occurred while UpdateProduct with id:{product.Id}" +
                                 $", message: {e.Message}");
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(Guid id)
        {
            _logger.LogInformation($"ProductsController: DeleteProduct with id:{id}");
            try
            {
                int result = _productService.DeleteProduct(id);
                return Ok(result);
            }
            catch (NotFoundException nfe)
            {
                return NotFound(nfe.Message);
            }
            catch (Exception e)
            {
                _logger.LogError($"ProductOptionController: Error occurred while DeleteProduct with id:{id}" +
                                 $", message: {e.Message}");
                return StatusCode(500, e.Message);
            }
        }
    }
}