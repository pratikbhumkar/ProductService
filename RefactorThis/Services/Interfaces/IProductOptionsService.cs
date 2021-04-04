using System;
using System.Collections.Generic;
using RefactorThis.Models;

namespace RefactorThis.Services.Interfaces
{
    public interface IProductOptionsService
    {
        public List<ProductOption> GetProductOptions(Guid productId);
        public ProductOption GetProductOption(Guid productId, Guid id);
        public int SaveProductOption(ProductOption productOption);
        public int UpdateProductOption(ProductOption productOption);
        public void DeleteProductOption(Guid id);
    }
}
