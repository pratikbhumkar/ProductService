﻿using System;
using System.Text.Json.Serialization;

namespace RefactorThis.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal DeliveryPrice { get; set; }

        [JsonIgnore] public bool IsNew { get; set; }

        public Product()
        {
            Id = Guid.NewGuid();
            IsNew = true;
        }
    }
}
