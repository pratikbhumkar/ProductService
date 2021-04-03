using System;
using RefactorThis.Models;

namespace RefactorThis.Services.Interfaces
{
    public interface IProductOptionsService
    {
        public ProductOptions GetProductOptions();
        public ProductOption GetProductOption(Guid id);
        public int SaveProductOption(ProductOption productOption);
        public int UpdateProductOption(ProductOption productOption);
        public void DeleteProductOption(Guid id);
    }
}
