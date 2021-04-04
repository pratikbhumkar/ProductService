using System;
using System.Collections.Generic;
using RefactorThis.Models.DTO;

namespace RefactorThis.Gateways.Interfaces
{
    public interface IProductOptionsGateway
    {
        List<ProductOptionsDto> GetAll(Guid productId);
        ProductOptionsDto Get(Guid productId, Guid id);
        int Save(ProductOptionsDto productOption);
        int Update(ProductOptionsDto productOption);
        int Delete(ProductOptionsDto productOption);
    }
}
