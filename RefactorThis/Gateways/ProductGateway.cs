using System;
using System.Collections.Generic;
using RefactorThis.Gateways.Interfaces;
using RefactorThis.Models;

namespace RefactorThis.Gateways
{
    public class ProductGateway: IProductGateway
    {
        public Products GetProducts()
        {
            Products products = new Products();
            products.Items = new List<Product>();
            var conn = Helpers.NewConnection();
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = $"select id from Products";

            var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                var id = Guid.Parse(rdr.GetString(0));
                products.Items.Add(Get(id));
            }
            return products;
        }

        public int Update(Product product)
        {
            var conn = Helpers.NewConnection();
            conn.Open();
            var cmd = conn.CreateCommand();

            cmd.CommandText = $"update Products set name = '{product.Name}', description = '{product.Description}', price = {product.Price}, deliveryprice = {product.DeliveryPrice} where id = '{product.Id}' collate nocase";

            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        public Product Get(Guid id)
        {
            Product product = new Product();
            product.IsNew = true;
            var conn = Helpers.NewConnection();
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = $"select * from Products where id = '{id}' collate nocase";

            var rdr = cmd.ExecuteReader();
            if (!rdr.Read())
                return product;

            product.IsNew = false;
            product.Id = Guid.Parse(rdr["Id"].ToString());
            product.Name = rdr["Name"].ToString();
            product.Description = (DBNull.Value == rdr["Description"]) ? null : rdr["Description"].ToString();
            product.Price = decimal.Parse(rdr["Price"].ToString());
            product.DeliveryPrice = decimal.Parse(rdr["DeliveryPrice"].ToString());
            return product;
        }
        
        public int Save(Product product)
        {
            var conn = Helpers.NewConnection();
            conn.Open();
            var cmd = conn.CreateCommand();

            cmd.CommandText = product.IsNew
                ? $"insert into Products (id, name, description, price, deliveryprice) values ('{product.Id}', '{product.Name}', '{product.Description}', {product.Price}, {product.DeliveryPrice})"
                : $"update Products set name = '{product.Name}', description = '{product.Description}', price = {product.Price}, deliveryprice = {product.DeliveryPrice} where id = '{product.Id}' collate nocase";

            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        public int Delete(Guid id)
        {
            foreach (var option in new ProductOptions(id).Items)
                option.Delete();

            var conn = Helpers.NewConnection();
            conn.Open();
            var cmd = conn.CreateCommand();

            cmd.CommandText = $"delete from Products where id = '{id}' collate nocase";
            return cmd.ExecuteNonQuery();
        }
    }
}
