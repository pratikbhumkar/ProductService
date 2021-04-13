using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using RefactorThis.Context;
using RefactorThis.Exceptions;
using RefactorThis.Gateways.Interfaces;
using RefactorThis.Models.Entities;

namespace RefactorThis.Gateways
{
    public class ProductGateway: IProductGateway
    {
        private readonly ILogger<ProductGateway> _logger;
        private readonly DatabaseContext _databaseContext;
        public ProductGateway(DatabaseContext databaseContext, ILogger<ProductGateway> logger)
        {
            _databaseContext = databaseContext;
            _logger = logger;
        }
       public List<Products> GetProducts()
        {
            _logger.LogInformation($"ProductGateway: Getting all products.");
            _databaseContext.Database.EnsureCreated();
            var prods =  _databaseContext.Products;
            return prods.ToList();
        }

        public int Update(Products product)
        {
            _logger.LogInformation($"ProductGateway: Updating products with Id: {product.Id}.");
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
            _logger.LogError("Product Options Not found");
            throw new NotFoundException("Product Not found");
        }

        public Products Get(Guid id)
        {
            _logger.LogInformation($"ProductGateway: Getting products with Id: {id}.");
            Products result = _databaseContext.Products.SingleOrDefault(prod => prod.Id == id);
            if (result != null)
            {
                return result;
            }
            _logger.LogError("Product Options Not found");
            throw new NotFoundException("Product Not found");
        }
        public Products GetByName(string name)
        {
            _logger.LogInformation($"ProductGateway: Getting products with name: {name}.");
            Products result = _databaseContext.Products.SingleOrDefault(prod => prod.Name == name);
            if (result != null)
            {
                return result;
            }
            _logger.LogError("Product Options Not found");
            throw new NotFoundException("Product Not found");
        }
        public int Save(Products product)
        {
            _logger.LogInformation($"ProductGateway: Saving products with Id: {product.Id}.");
            _databaseContext.Products.Add(product);
            return _databaseContext.SaveChanges();
        }

        public int Delete(Products product)
        {
            _logger.LogInformation($"ProductGateway: Deleting products with Id: {product.Id}.");
            _databaseContext.Products.Remove(product);
            return _databaseContext.SaveChanges();
        }
    }
}
