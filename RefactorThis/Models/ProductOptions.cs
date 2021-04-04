using System;

namespace RefactorThis.Models
{
    public class ProductOptions
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        
    }
}
