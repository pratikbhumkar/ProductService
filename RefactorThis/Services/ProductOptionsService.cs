using System;
using System.Collections.Generic;
using RefactorThis.Gateways.Interfaces;
using RefactorThis.Models;
using RefactorThis.Services.Interfaces;

namespace RefactorThis.Services
{
    public class ProductOptionsService: IProductOptionsService
    {
        private readonly IProductOptionsGateway _productOptionsGateway;
        public ProductOptionsService(IProductOptionsGateway productOptionsGateway)
        {
            _productOptionsGateway = productOptionsGateway;
        }
        public List<ProductOption> GetProductOptions(Guid productId)
        {
            return _productOptionsGateway.GetAll(productId);
        }
        public ProductOption GetProductOption(Guid productId, Guid id)
        {
            return _productOptionsGateway.Get(productId, id);
        }
        public void DeleteProductOption(Guid id)
        {
            _productOptionsGateway.Delete(id);
        }
        public int SaveProductOption(ProductOption productOption)
        {
            return _productOptionsGateway.Save(productOption);
        }
        public int UpdateProductOption(ProductOption productOption)
        {
            return _productOptionsGateway.Update(productOption);
        }
    }
}
