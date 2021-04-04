using System;
using System.Collections.Generic;
using AutoMapper;
using RefactorThis.Gateways.Interfaces;
using RefactorThis.Models;
using RefactorThis.Models.DTO;
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
        public List<ProductOptions> GetProductOptions(Guid productId)
        {
            List<ProductOptionsDto> productOptionsDtos = _productOptionsGateway.GetAll(productId);
            List<ProductOptions> productOptionsList = _mapper.Map<List<ProductOptions>>(productOptionsDtos);
            return productOptionsList;
        }
        public ProductOptions GetProductOption(Guid productId, Guid id)
        {
            ProductOptionsDto productOptionsDto = _productOptionsGateway.Get(productId, id);
            ProductOptions productOptions = _mapper.Map<ProductOptions>(productOptionsDto);
            return productOptions;
        }
        public int DeleteProductOption(Guid id)
        {
            ProductOptionsDto productOptionsDto = new ProductOptionsDto()
            {
                Id = id
            };
            return _productOptionsGateway.Delete(productOptionsDto);
        }
        public int SaveProductOption(ProductOptions productOptions)
        {
            ProductOptionsDto productOptionsDto = _mapper.Map<ProductOptionsDto>(productOptions);
            return _productOptionsGateway.Save(productOptionsDto);
        }
        public int UpdateProductOption(ProductOptions productOptions)
        {
            ProductOptionsDto productOptionsDto = _mapper.Map<ProductOptionsDto>(productOptions);
            return _productOptionsGateway.Update(productOptionsDto);
        }
    }
}
