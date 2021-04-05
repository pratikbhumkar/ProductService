using System;
using System.Collections.Generic;
using RefactorThis.Models.Entities;


namespace RefactorThis.Gateways.Interfaces
{
    public interface IProductOptionsGateway
    {
        List<ProductOptions> GetAll(Guid productId);
        ProductOptions Get(Guid productId, Guid id);
        int Save(ProductOptions productOption);
        int Update(ProductOptions productOption);
        int Delete(ProductOptions productOption);
    }
}
