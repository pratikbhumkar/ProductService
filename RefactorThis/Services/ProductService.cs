using System;
using System.Collections.Generic;
using RefactorThis.Gateways;
using RefactorThis.Gateways.Interfaces;
using RefactorThis.Models;

namespace RefactorThis.Services
{
    public class ProductService: IProductService
    {
        private readonly IProductGateway _productGateway;
        public ProductService(IProductGateway productGateway)
        {
            _productGateway = productGateway;
        }
        public List<Product> GetProducts()
        {
            return _productGateway.GetProducts();
        }

        public Product GetProduct(Guid id)
        {
            return _productGateway.Get(id);
        }

        public int SaveProduct(Product product)
        {
            return _productGateway.Save(product);
        }

        public int UpdateProduct(Guid id, Product product)
        {
            return _productGateway.Update(product);
        }
        
        public int DeleteProduct(Guid id)
        {
            return _productGateway.Delete(id);
        }
    }
}
