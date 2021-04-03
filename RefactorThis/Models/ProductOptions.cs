using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RefactorThis.Models
{

    public class ProductOptions
    {
        public List<ProductOption> Items { get; set; }

        public ProductOptions()
        {
            LoadProductOptions(null);
        }

        public ProductOptions(Guid productId)
        {
            LoadProductOptions($"where productid = '{productId}' collate nocase");
        }

        private void LoadProductOptions(string where)
        {
            
        }
    }

    public class ProductOption
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [JsonIgnore] public bool IsNew { get; set; }

        public ProductOption()
        {
            Id = Guid.NewGuid();
            IsNew = true;
        }
        
    }
}
