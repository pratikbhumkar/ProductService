using System;
using RefactorThis.Gateways.Interfaces;
using RefactorThis.Models;
using RefactorThis.Services.Interfaces;

namespace RefactorThis.Services
{
    public class ProductOptionService: IProductOptionsService
    {
        private readonly IProductOptionsGateway _productOptionsGateway;
        public ProductOptionService(IProductOptionsGateway productOptionsGateway)
        {
            _productOptionsGateway = productOptionsGateway;
        }
        public ProductOptions GetProductOptions()
        {
            return _productOptionsGateway.GetAll();
        }
        public ProductOption GetProductOption(Guid id)
        {
            return _productOptionsGateway.Get(id);
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
