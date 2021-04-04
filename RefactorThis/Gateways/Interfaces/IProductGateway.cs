using System;
using System.Collections.Generic;
using RefactorThis.Models;

namespace RefactorThis.Gateways.Interfaces
{
    public interface IProductGateway
    {
        List<Product> GetProducts();
        Product Get(Guid id);
        int Save(Product product);
        int Update(Product product);
        int Delete(Guid id);
    }
}
