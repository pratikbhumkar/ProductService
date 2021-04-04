﻿using System;
using Microsoft.AspNetCore.Mvc;
using RefactorThis.Models;
using RefactorThis.Services.Interfaces;

namespace RefactorThis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductOptionController : ControllerBase
    {
        private readonly IProductOptionsService _productOptionsService;
        public ProductOptionController(IProductOptionsService productOptionsService)
        {
            _productOptionsService = productOptionsService;
        }
        [HttpGet]
        public IActionResult GetOptions(Guid productId)
        {
            try
            {
                var productOptions = _productOptionsService.GetProductOptions(productId);
                return Ok(productOptions);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{productId}/options/{id}")]
        public IActionResult GetOption(Guid productId, Guid id)
        {
            try
            {
                var productOption = _productOptionsService.GetProductOption(productId,id);
                return Ok(productOption);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("{productId}/options")]
        public IActionResult CreateOption(Guid productId, ProductOptions options)
        {
            try
            {
                var result = _productOptionsService.SaveProductOption(options);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateOption(Guid id, ProductOptions options)
        {
            try
            {
                var result = _productOptionsService.UpdateProductOption(options);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteOption(Guid id)
        {
            try
            {
                _productOptionsService.DeleteProductOption(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
