using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.Extensions.Logging;
using RefactorThis.Gateways.Interfaces;
using RefactorThis.Models;
using RefactorThis.Models.Entities;
using RefactorThis.Services.Interfaces;

namespace RefactorThis.Services
{
    public class ProductOptionsService: IProductOptionsService
    {
        private readonly IProductOptionsGateway _productOptionsGateway;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductOptionsService> _logger;
        public ProductOptionsService(IProductOptionsGateway productOptionsGateway, IMapper mapper, ILogger<ProductOptionsService> logger)
        {
            _productOptionsGateway = productOptionsGateway;
            _mapper = mapper;
            _logger = logger;
        }
        public List<ProductOptionsDto> GetProductOptions(Guid productId)
        {
            _logger.LogInformation($"ProductOptionsService: GetProductOptions with id: {productId}");
            List<ProductOptions> productOptionsList = _productOptionsGateway.GetAll(productId);
            List<ProductOptionsDto> productOptionsDtoList = _mapper.Map<List<ProductOptionsDto>>(productOptionsList);
            return productOptionsDtoList;
        }
        public ProductOptionsDto GetProductOption(Guid productId, Guid id)
        {
            _logger.LogInformation($"ProductOptionsService: GetProductOption with productId: {productId}, id:{id} ");
            ProductOptions productOptions = _productOptionsGateway.Get(productId, id);
            ProductOptionsDto productOptionsDto = _mapper.Map<ProductOptionsDto>(productOptions);
            return productOptionsDto;
        }
        public int DeleteProductOption(Guid id)
        {
            ProductOptions productOptions = new ProductOptions()
            {
                Id = id
            };
            _logger.LogInformation($"ProductOptionsService: GetProductOption with id:{id} ");
            return _productOptionsGateway.Delete(productOptions);
        }
        public int SaveProductOption(ProductOptionsDto productOptionsDto)
        {
            _logger.LogInformation($"ProductOptionsService: SaveProductOption with productId: {productOptionsDto.ProductId}, " +
                                   $"product option id:{productOptionsDto.Id} ");
            ProductOptions productOptions = _mapper.Map<ProductOptions>(productOptionsDto);
            return _productOptionsGateway.Save(productOptions);
        }
        public int UpdateProductOption(ProductOptionsDto productOptionsDto)
        {
            _logger.LogInformation($"ProductOptionsService: UpdateProductOption with productId: {productOptionsDto.ProductId}, " +
                                   $"product option id:{productOptionsDto.Id} ");
            ProductOptions productOptions = _mapper.Map<ProductOptions>(productOptionsDto);
            return _productOptionsGateway.Update(productOptions);
        }
    }
}
