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
    public class ProductOptionsGateway: IProductOptionsGateway
    {
        private readonly DatabaseContext _databaseContext;
        private readonly ILogger<ProductOptionsGateway> _logger;
        public ProductOptionsGateway(DatabaseContext databaseContext, ILogger<ProductOptionsGateway> logger)
        {
            _databaseContext = databaseContext;
            _databaseContext.Database.EnsureCreated();
            _logger = logger;
        }
        public List<ProductOptions> GetAll(Guid productId)
        {
            _logger.LogInformation($"ProductOptionsGateway: Getting all product options with product id ${productId}.");
            List<ProductOptions> productOptions = _databaseContext.ProductOptions.Where(prod => prod.ProductId == productId).ToList();
            if (productOptions.Count>0)
            {
                return productOptions;
            }
            _logger.LogError("ProductOptionsGateway: Product Options Not found");
            throw new NotFoundException("Product Options Not found");
        }
        
        public ProductOptions Get(Guid productId, Guid id)
        {
            _logger.LogInformation($"ProductOptionsGateway: Getting product option with productId {productId} and option id {id}");
            ProductOptions options = _databaseContext.ProductOptions.SingleOrDefault(prod => prod.ProductId == productId && prod.Id == id);
            if (options != null)
            {
                return options;
            }
            _logger.LogError("ProductOptionsGateway: Product Options Not found");
            throw new NotFoundException("Product Option Not found");
        }

        public int Save(ProductOptions productOption)
        {
            _logger.LogInformation($"ProductOptionsGateway: Saving product option with OptionId as ${productOption.Id}");
            _databaseContext.ProductOptions.Add(productOption);
            return _databaseContext.SaveChanges();
        }

        public int Update(ProductOptions productOption)
        {
            _logger.LogInformation($"ProductOptionsGateway: Updating product option with OptionId as ${productOption.Id}");
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
            _logger.LogError("Product Options Not found");
            throw new NotFoundException("Product Option Not found");
        }

        public int Delete(ProductOptions productOption)
        {
            _logger.LogInformation($"ProductOptionsGateway: Deleting product option with OptionId as ${productOption.Id}");
            _databaseContext.ProductOptions.Remove(productOption);
            return _databaseContext.SaveChanges();
        }
    }
}
