using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RefactorThis.Context;
using RefactorThis.Gateways.Interfaces;
using RefactorThis.Models.DTO;

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
        public List<ProductOptionsDto> GetAll(Guid productId)
        {
            return _databaseContext.ProductOptions.Where(dto => dto.ProductId == productId).ToList();
        }
        
        public ProductOptionsDto Get(Guid productId, Guid id)
        {
            return _databaseContext.ProductOptions.FirstOrDefault(dto => dto.ProductId == productId && dto.Id == id);
        }

        public int Save(ProductOptionsDto productOption)
        {
            EntityEntry<ProductOptionsDto> result = _databaseContext.ProductOptions.Add(productOption);
            _databaseContext.SaveChanges();
            return (int)result.State;
        }

        public int Update(ProductOptionsDto productOption)
        {
            ProductOptionsDto result = _databaseContext.ProductOptions
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

        public int Delete(ProductOptionsDto productOption)
        {
            EntityEntry<ProductOptionsDto> result = _databaseContext.ProductOptions.Remove(productOption);
            _databaseContext.SaveChanges();
            return (int)result.State;
        }
    }
}
