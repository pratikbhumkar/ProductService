using System;
using Microsoft.AspNetCore.Mvc;
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
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetProducts([FromQuery(Name = "name")] string name)
        {
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
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(Guid id)
        {
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
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(ProductDto product)
        {
            try
            {
                int result = _productService.SaveProduct(product);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Update(ProductDto product)
        {
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
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
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
                return StatusCode(500, e.Message);
            }
        }
    }
}