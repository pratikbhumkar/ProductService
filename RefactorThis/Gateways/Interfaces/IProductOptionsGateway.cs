using System;
using RefactorThis.Models;

namespace RefactorThis.Gateways.Interfaces
{
    public interface IProductOptionsGateway
    {
        ProductOptions GetAll();
        ProductOption Get(Guid id);
        int Save(ProductOption productOption);
        int Update(ProductOption productOption);
        int Delete(Guid id);
    }
}
