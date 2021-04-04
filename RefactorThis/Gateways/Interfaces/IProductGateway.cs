using System;
using System.Collections.Generic;
using RefactorThis.Models;

namespace RefactorThis.Gateways.Interfaces
{
    public interface IProductGateway
    {
        List<ProductDto> GetProducts();
        ProductDto Get(Guid id);
        int Save(ProductDto product);
        int Update(ProductDto product);
        int Delete(ProductDto product);
    }
}
