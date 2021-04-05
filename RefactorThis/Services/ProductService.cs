using System;
using System.Collections.Generic;
using AutoMapper;
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
        public ProductService(IProductGateway productGateway, IMapper mapper, IProductOptionsGateway productOptionsGateway)
        {
            _productGateway = productGateway;
            _mapper = mapper;
            _productOptionsGateway = productOptionsGateway;
        }
        public List<ProductDto> GetProducts()
        {
            List<Products> productDtoList = _productGateway.GetProducts();
            List<ProductDto> productList = _mapper.Map<List<ProductDto>>(productDtoList);
            return productList;
        }

        public ProductDto GetProduct(Guid id)
        {
            Products product = _productGateway.Get(id);
            ProductDto productDto = _mapper.Map<ProductDto>(product);
            return productDto;
        }

        public ProductDto GetProductByName(string name)
        {
            Products product = _productGateway.GetByName(name);
            ProductDto productDto = _mapper.Map<ProductDto>(product);
            return productDto;
        }

        public int SaveProduct(ProductDto productDto)
        {
            Products products = _mapper.Map<Products>(productDto);
            return _productGateway.Save(products);
        }

        public int UpdateProduct(ProductDto productDto)
        {
            Products products = _mapper.Map<Products>(productDto);
            return _productGateway.Update(products);
        }
        
        public int DeleteProduct(Guid id)
        {
            Products productDto = new Products()
            {
                Id = id
            };
            DeleteCorrespondingProductOptions(id);
            return _productGateway.Delete(productDto);
        }

        private void DeleteCorrespondingProductOptions(Guid id)
        {
           List<ProductOptions> productOptionsList = _productOptionsGateway.GetAll(id);
           foreach (ProductOptions productOption in productOptionsList)
           {
               _productOptionsGateway.Delete(productOption);
           }
        }
    }
}
