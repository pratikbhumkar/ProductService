using System;
using System.Collections.Generic;
using RefactorThis.Models;

namespace RefactorThis.Services.Interfaces
{
    public interface IProductService
    {
        List<ProductDto> GetProducts();
        ProductDto GetProduct(Guid id);
        ProductDto GetProductByName(string name);
        int SaveProduct(ProductDto productDto);
        int UpdateProduct(ProductDto productDto);
        int DeleteProduct(Guid id);
    }
}
