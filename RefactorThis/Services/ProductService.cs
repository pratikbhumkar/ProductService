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
    public class ProductService: IProductService
    {
        private readonly IProductGateway _productGateway;
        private readonly IProductOptionsGateway _productOptionsGateway;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductService> _logger;
        public ProductService(IProductGateway productGateway, IMapper mapper, IProductOptionsGateway productOptionsGateway, 
            ILogger<ProductService> logger)
        {
            _productGateway = productGateway;
            _mapper = mapper;
            _productOptionsGateway = productOptionsGateway;
            _logger = logger;
        }
        public List<ProductDto> GetProducts()
        {
            _logger.LogInformation("ProductService: Getting all products");
            List<Products> productDtoList = _productGateway.GetProducts();
            List<ProductDto> productList = _mapper.Map<List<ProductDto>>(productDtoList);
            return productList;
        }

        public ProductDto GetProduct(Guid id)
        {
            _logger.LogInformation($"ProductService: Getting product with id {id}");
            Products product = _productGateway.Get(id);
            ProductDto productDto = _mapper.Map<ProductDto>(product);
            return productDto;
        }

        public ProductDto GetProductByName(string name)
        {
            _logger.LogInformation($"ProductService: Getting product with name: {name}");
            Products product = _productGateway.GetByName(name);
            ProductDto productDto = _mapper.Map<ProductDto>(product);
            return productDto;
        }

        public int SaveProduct(ProductDto productDto)
        {
            _logger.LogInformation($"ProductService: Saving product with Id: {productDto.Id}");
            Products products = _mapper.Map<Products>(productDto);
            return _productGateway.Save(products);
        }

        public int UpdateProduct(ProductDto productDto)
        {
            _logger.LogInformation($"ProductService: Updating product with Id: {productDto.Id}");
            Products products = _mapper.Map<Products>(productDto);
            return _productGateway.Update(products);
        }
        
        public int DeleteProduct(Guid id)
        {
            _logger.LogInformation($"ProductService: Deleting product with Id: {id}");
            Products productDto = new Products()
            {
                Id = id
            };
            //Deleting product options by calling method to delete options.
            //Because if I want to use ef for that, I might have to alter database.
            DeleteCorrespondingProductOptions(id);
            return _productGateway.Delete(productDto);
        }

        private void DeleteCorrespondingProductOptions(Guid id)
        {
            _logger.LogInformation($"ProductService: Deleting product options for with Product Id: {id}");
            List<ProductOptions> productOptionsList = _productOptionsGateway.GetAll(id);
           foreach (ProductOptions productOption in productOptionsList)
           {
               _productOptionsGateway.Delete(productOption);
           }
        }
    }
}
