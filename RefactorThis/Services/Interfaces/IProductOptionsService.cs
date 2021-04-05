using System;
using System.Collections.Generic;
using RefactorThis.Models;

namespace RefactorThis.Services.Interfaces
{
    public interface IProductOptionsService
    {
        public List<ProductOptionsDto> GetProductOptions(Guid productId);
        public ProductOptionsDto GetProductOption(Guid productId, Guid id);
        public int SaveProductOption(ProductOptionsDto productOptionsDto);
        public int UpdateProductOption(ProductOptionsDto productOptionsDto);
        public int DeleteProductOption(Guid id);
    }
}
