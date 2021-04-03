using System;
using System.Collections.Generic;
using RefactorThis.Gateways.Interfaces;
using RefactorThis.Models;

namespace RefactorThis.Gateways
{
    public class ProductOptionsGateway: IProductOptionsGateway
    {
        public ProductOptions GetAll()
        {
            ProductOptions productOptions = new ProductOptions();
            productOptions.Items = new List<ProductOption>();
            var conn = Helpers.NewConnection();
            conn.Open();
            var cmd = conn.CreateCommand();

            cmd.CommandText = $"select id from productoptions";

            var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                var id = Guid.Parse(rdr.GetString(0));
                productOptions.Items.Add(Get(id));
            }
            return productOptions;
        }

        public ProductOption Get(Guid id)
        {
            ProductOption productOption = new ProductOption();
            productOption.IsNew = true;
            var conn = Helpers.NewConnection();
            conn.Open();
            var cmd = conn.CreateCommand();

            cmd.CommandText = $"select * from productoptions where id = '{id}' collate nocase";

            var rdr = cmd.ExecuteReader();
            if (!rdr.Read())
                return null;

            productOption.ProductId = Guid.Parse(rdr["ProductId"].ToString());
            productOption.Name = rdr["Name"].ToString();
            productOption.Description = (DBNull.Value == rdr["Description"]) ? null : rdr["Description"].ToString();
            return productOption;
        }

        public int Save(ProductOption productOption)
        {
            var conn = Helpers.NewConnection();
            conn.Open();
            var cmd = conn.CreateCommand();

            cmd.CommandText = productOption.IsNew
                ? $"insert into productoptions (id, productid, name, description) values ('{productOption.Id}', '{productOption.ProductId}', '{productOption.Name}', '{productOption.Description}')"
                : $"update productoptions set name = '{productOption.Name}', description = '{productOption.Description}' where id = '{productOption.Id}' collate nocase";

            return cmd.ExecuteNonQuery();
        }

        public int Update(ProductOption productOption)
        {
            var conn = Helpers.NewConnection();
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = $"update productoptions set name = '{productOption.Name}', description = '{productOption.Description}' where id = '{productOption.Id}' collate nocase";
            return cmd.ExecuteNonQuery();
        }

        public int Delete(Guid id)
        {
            var conn = Helpers.NewConnection();
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = $"delete from productoptions where id = '{id}' collate nocase";
            cmd.ExecuteReader();
            return 1;
        }
    }
}
