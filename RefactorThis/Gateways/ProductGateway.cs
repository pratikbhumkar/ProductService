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
       public List<ProductDto> GetProducts()
        {
            using var dbContext = new DatabaseContext();
            dbContext.Database.EnsureCreated();
            return dbContext.Products.ToList();
        }

        public int Update(ProductDto product)
        {
            using var dbContext = new DatabaseContext();
            dbContext.Database.EnsureCreated();
            ProductDto result = dbContext.Products.SingleOrDefault(prod => prod.Id == product.Id);
            if (result != null)
            {
                result.Id = product.Id;
                result.DeliveryPrice = product.DeliveryPrice;
                result.Description = product.Description;
                result.Name = product.Name;
                result.Price = product.Price;
                return dbContext.SaveChanges();
            }
            return -1;
        }

        public ProductDto Get(Guid id)
        {
            using var dbContext = new DatabaseContext();
            var result = dbContext.Products.SingleOrDefault(prod => prod.Id == id);
            if (result != null)
            {
                return result;
            }
            //Raise exception here & handle in controller for not found.
            return null;
        }
        
        public int Save(ProductDto product)
        {
            using var dbContext = new DatabaseContext();
            EntityEntry<ProductDto> result = dbContext.Products.Add(product);
            dbContext.SaveChanges();
            return (int) result.State;
        }

        public int Delete(ProductDto product)
        {
            using var dbContext = new DatabaseContext();
            EntityEntry<ProductDto> result = dbContext.Products.Remove(product);
            return (int)result.State;
        }
    }
}
