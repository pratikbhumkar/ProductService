using System;
using System.Collections.Generic;
using System.Linq;
using RefactorThis.Context;
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
            List<ProductOptions> productOptionsprods = _databaseContext.ProductOptions.Where(prod => prod.ProductId == productId).ToList();
            return productOptionsprods;
        }
        
        public ProductOptions Get(Guid productId, Guid id)
        {
            return _databaseContext.ProductOptions.FirstOrDefault(prod => prod.ProductId == productId && prod.Id == id);
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
            return -1;
        }

        public int Delete(ProductOptions productOption)
        {
            _databaseContext.ProductOptions.Remove(productOption);
            return _databaseContext.SaveChanges();
        }
    }
}
