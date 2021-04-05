using System;
using System.ComponentModel.DataAnnotations;

namespace RefactorThis.Models
{
    public class ProductDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        public decimal DeliveryPrice { get; set; }
    }
}
