using System;
using RefactorThis.Models;

namespace RefactorThis.Gateways.Interfaces
{
    public interface IProductGateway
    {
        Products GetProducts();
        Product Get(Guid id);
        int Save(Product product);
        int Update(Product product);
        int Delete(Guid id);
    }
}
