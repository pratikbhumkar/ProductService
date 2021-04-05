using System;
using System.ComponentModel.DataAnnotations;

namespace RefactorThis.Models
{
    public class ProductOptionsDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        
    }
}
