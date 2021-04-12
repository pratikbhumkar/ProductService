using System;
using System.Collections.Generic;
using System.Linq;
using RefactorThis.Context;
using RefactorThis.Exceptions;
using RefactorThis.Gateways.Interfaces;
using RefactorThis.Models.Entities;


namespace RefactorThis.Gateways
{
    public class ProductOptionsGateway: IProductOptionsGateway
    {
        private readonly DatabaseContext _databaseContext;
        public ProductOptionsGateway(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _databaseContext.Database.EnsureCreated();
        }
        public List<ProductOptions> GetAll(Guid productId)
        {
            List<ProductOptions> productOptions = _databaseContext.ProductOptions.Where(prod => prod.ProductId == productId).ToList();
            if (productOptions.Count>0)
            {
                return productOptions;
            }
            throw new NotFoundException("Product Options Not found");
        }
        
        public ProductOptions Get(Guid productId, Guid id)
        {
            ProductOptions options = _databaseContext.ProductOptions.SingleOrDefault(prod => prod.ProductId == productId && prod.Id == id);
            if (options != null)
            {
                return options;
            }
            throw new NotFoundException("Product Option Not found");
        }

        public int Save(ProductOptions productOption)
        {
            _databaseContext.ProductOptions.Add(productOption);
            return _databaseContext.SaveChanges();
        }

        public int Update(ProductOptions productOption)
        {
            ProductOptions result = _databaseContext.ProductOptions
                .SingleOrDefault(prodOption => prodOption.Id == productOption.Id);
            if (result != null)
            {
                result.Id = productOption.Id;
                result.Description = productOption.Description;
                result.Name = productOption.Name;
                result.ProductId = productOption.ProductId;
                return _databaseContext.SaveChanges();
            }
            throw new NotFoundException("Product Option Not found");
        }

        public int Delete(ProductOptions productOption)
        {
            _databaseContext.ProductOptions.Remove(productOption);
            return _databaseContext.SaveChanges();
        }
    }
}
