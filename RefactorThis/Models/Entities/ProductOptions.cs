using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RefactorThis.Models.Entities
{
    [Table("ProductOptions")]
    public class ProductOptions
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
