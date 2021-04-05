using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RefactorThis.Models.Entities
{
    [Table("Products")]
    public class Products
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal DeliveryPrice { get; set; }
    }
}
