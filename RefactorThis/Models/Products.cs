using System;
using System.Collections.Generic;

namespace RefactorThis.Models
{
    public class Products
    {
        public List<Product> Items { get; set; }

        public Products()
        {
            LoadProducts(null);
        }

        public Products(string name)
        {
            LoadProducts($"where lower(name) like '%{name.ToLower()}%'");
        }

        private void LoadProducts(string where)
        {
            
        }
    }
}