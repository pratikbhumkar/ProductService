using System;
using System.Collections.Generic;
using RefactorThis.Models.Entities;

namespace RefactorThis.Gateways.Interfaces
{
    public interface IProductGateway
    {
        List<Products> GetProducts();
        Products Get(Guid id);
        Products GetByName(string name);
        int Save(Products product);
        int Update(Products product);
        int Delete(Products product);
    }
}
