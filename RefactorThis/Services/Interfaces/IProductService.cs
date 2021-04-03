using System;
using RefactorThis.Models;

namespace RefactorThis.Services
{
    public interface IProductService
    {
        Products GetProducts();
        Product GetProduct(Guid id);
        int SaveProduct(Product product);
        int UpdateProduct(Guid id, Product product);
        int DeleteProduct(Guid id);
    }
}
