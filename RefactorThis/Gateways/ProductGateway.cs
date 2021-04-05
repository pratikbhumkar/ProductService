using System;
using System.Collections.Generic;
using System.Linq;
using RefactorThis.Context;
using RefactorThis.Gateways.Interfaces;
using RefactorThis.Models.Entities;

namespace RefactorThis.Gateways
{
    public class ProductGateway: IProductGateway
    {
        private readonly DatabaseContext _databaseContext;
        public ProductGateway(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
       public List<Products> GetProducts()
        {
            _databaseContext.Database.EnsureCreated();
            var prods =  _databaseContext.Products;
            return prods.ToList();
        }

        public int Update(Products product)
        {
            _databaseContext.Database.EnsureCreated();
            Products result = _databaseContext.Products
                .FirstOrDefault(prod => prod.Id == product.Id);
            if (result != null)
            {
                result.Id = product.Id;
                result.DeliveryPrice = product.DeliveryPrice;
                result.Description = product.Description;
                result.Name = product.Name;
                result.Price = product.Price;
                return _databaseContext.SaveChanges();
            }
            return -1;
        }

        public Products Get(Guid id)
        {
            Products result = _databaseContext.Products.SingleOrDefault(prod => prod.Id == id);
            if (result != null)
            {
                return result;
            }
            //Raise exception here & handle in controller for not found.
            return null;
        }
        public Products GetByName(string name)
        {
            Products result = _databaseContext.Products.SingleOrDefault(prod => prod.Name == name);
            if (result != null)
            {
                return result;
            }
            //Raise exception here & handle in controller for not found.
            return null;
        }
        public int Save(Products product)
        {
            _databaseContext.Products.Add(product);
            return _databaseContext.SaveChanges();
        }

        public int Delete(Products product)
        {
            _databaseContext.Products.Remove(product);
            return _databaseContext.SaveChanges();
        }
    }
}
