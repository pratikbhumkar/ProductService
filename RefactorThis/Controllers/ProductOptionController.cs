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
    public class ProductOptionController : ControllerBase
    {
        private readonly IProductOptionsService _productOptionsService;
        private readonly ILogger<ProductOptionController> _logger;
        public ProductOptionController(IProductOptionsService productOptionsService, ILogger<ProductOptionController> logger)
        {
            _productOptionsService = productOptionsService;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult GetOptions(Guid productId)
        {
            _logger.LogInformation($"ProductOptionController: GetOptions with ProductId:{productId}");
            try
            {
                var productOptions = _productOptionsService.GetProductOptions(productId);
                return Ok(productOptions);
            }
            catch (NotFoundException nfe)
            {
                return NotFound(nfe.Message);
            }
            catch (Exception e)
            {
                _logger.LogError($"ProductOptionController: Error occurred while GetOptions with ProductId:{productId}" +
                                 $", message: {e.Message}");
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{productId}/options/{id}")]
        public IActionResult GetOption(Guid productId, Guid id)
        {
            _logger.LogInformation($"ProductOptionController: GetOption with ProductId:{productId} and OptionId: {id}");
            try
            {
                var productOption = _productOptionsService.GetProductOption(productId,id);
                return Ok(productOption);
            }
            catch (NotFoundException nfe)
            {
                return NotFound(nfe.Message);
            }
            catch (Exception e)
            {
                _logger.LogError($"ProductOptionController: Error occurred while ProductId:{productId} and OptionId: {id}" +
                                 $", message: {e.Message}");
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("{productId}/options")]
        public IActionResult CreateOption(Guid productId, ProductOptionsDto options)
        {
            _logger.LogInformation($"ProductOptionController: CreateOption with ProductId:{productId} and OptionId: {options.Id}");
            try
            {
                var result = _productOptionsService.SaveProductOption(options);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ProductOptionController: Error occurred while CreateOption ProductId:{productId} " +
                                 $"and OptionId: {options.Id}" +
                                 $", message: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateOption(ProductOptionsDto options)
        {
            _logger.LogInformation($"ProductOptionController: UpdateOption with ProductId:{options.ProductId} and OptionId: {options.Id}");
            try
            {
                var result = _productOptionsService.UpdateProductOption(options);
                return Ok(result);
            }
            catch (NotFoundException nfe)
            {
                return NotFound(nfe.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ProductOptionController: Error occurred while UpdateOption ProductId:{options.ProductId} " +
                                 $"and OptionId: {options.Id}" +
                                 $", message: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteOption(Guid id)
        {
            _logger.LogInformation($"ProductOptionController: DeleteOption with OptionId: {id}");
            try
            {
                _productOptionsService.DeleteProductOption(id);
                return Ok();
            }
            catch (NotFoundException nfe)
            {
                return NotFound(nfe.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ProductOptionController: Error occurred while DeleteOption OptionId: {id} " +
                                 $", message: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
    }
}
