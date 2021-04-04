using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RefactorThis.Context;
using RefactorThis.Gateways.Interfaces;
using RefactorThis.Models;

namespace RefactorThis.Gateways
{
    public class ProductGateway: IProductGateway
    {
        private readonly DatabaseContext _databaseContext;
        public ProductGateway(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
       public List<ProductDto> GetProducts()
        {
            _databaseContext.Database.EnsureCreated();
            return _databaseContext.Products.ToList();
        }

        public int Update(ProductDto product)
        {
            _databaseContext.Database.EnsureCreated();
            ProductDto result = _databaseContext.Products.SingleOrDefault(prod => prod.Id == product.Id);
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

        public ProductDto Get(Guid id)
        {
            ProductDto result = _databaseContext.Products.SingleOrDefault(prod => prod.Id == id);
            if (result != null)
            {
                return result;
            }
            //Raise exception here & handle in controller for not found.
            return null;
        }
        
        public int Save(ProductDto product)
        {
            EntityEntry<ProductDto> result = _databaseContext.Products.Add(product);
            _databaseContext.SaveChanges();
            return (int) result.State;
        }

        public int Delete(ProductDto product)
        {
            EntityEntry<ProductDto> result = _databaseContext.Products.Remove(product);
            _databaseContext.SaveChanges();
            return (int)result.State;
        }
    }
}
