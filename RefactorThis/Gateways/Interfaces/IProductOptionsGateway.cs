using System;
using System.Collections.Generic;
using RefactorThis.Models;

namespace RefactorThis.Gateways.Interfaces
{
    public interface IProductOptionsGateway
    {
        List<ProductOption> GetAll(Guid productId);
        ProductOption Get(Guid productId, Guid id);
        int Save(ProductOption productOption);
        int Update(ProductOption productOption);
        int Delete(Guid id);
    }
}
