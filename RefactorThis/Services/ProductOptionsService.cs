using System;
using System.Collections.Generic;
using AutoMapper;
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
        public ProductOptionsService(IProductOptionsGateway productOptionsGateway, IMapper mapper)
        {
            _productOptionsGateway = productOptionsGateway;
            _mapper = mapper;
        }
        public List<Models.ProductOptionsDto> GetProductOptions(Guid productId)
        {
            List<ProductOptions> productOptionsList = _productOptionsGateway.GetAll(productId);
            List<Models.ProductOptionsDto> productOptionsDtoList = _mapper.Map<List<Models.ProductOptionsDto>>(productOptionsList);
            return productOptionsDtoList;
        }
        public Models.ProductOptionsDto GetProductOption(Guid productId, Guid id)
        {
            ProductOptions productOptions = _productOptionsGateway.Get(productId, id);
            ProductOptionsDto productOptionsDto = _mapper.Map<Models.ProductOptionsDto>(productOptions);
            return productOptionsDto;
        }
        public int DeleteProductOption(Guid id)
        {
            ProductOptions productOptions = new ProductOptions()
            {
                Id = id
            };
            return _productOptionsGateway.Delete(productOptions);
        }
        public int SaveProductOption(ProductOptionsDto productOptionsDto)
        {
            ProductOptions productOptions = _mapper.Map<ProductOptions>(productOptionsDto);
            return _productOptionsGateway.Save(productOptions);
        }
        public int UpdateProductOption(ProductOptionsDto productOptionsDto)
        {
            ProductOptions productOptions = _mapper.Map<ProductOptions>(productOptionsDto);
            return _productOptionsGateway.Update(productOptions);
        }
    }
}
