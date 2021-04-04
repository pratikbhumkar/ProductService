using System;
using System.Collections.Generic;
using RefactorThis.Models;

namespace RefactorThis.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Product GetProduct(Guid id);
        int SaveProduct(Product product);
        int UpdateProduct(Product product);
        int DeleteProduct(Guid id);
    }
}
