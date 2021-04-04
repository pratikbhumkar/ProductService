using System;
using System.Collections.Generic;
using RefactorThis.Models;

namespace RefactorThis.Services.Interfaces
{
    public interface IProductOptionsService
    {
        public List<ProductOptions> GetProductOptions(Guid productId);
        public ProductOptions GetProductOption(Guid productId, Guid id);
        public int SaveProductOption(ProductOptions productOptions);
        public int UpdateProductOption(ProductOptions productOptions);
        public int DeleteProductOption(Guid id);
    }
}
