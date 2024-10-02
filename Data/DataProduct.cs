using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DataProduct
    {
        public List<Product> ListProducts()
        {
            SqlConnection connection = new SqlConnection(Conexion.cadena);
            connection.Open();

            SqlCommand command = new SqlCommand("ListProducts", connection);
            command.CommandType = CommandType.StoredProcedure;

            List<Product> listProducts = new List<Product>();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Product product = new Product();
                product.product_id = Convert.ToInt32(reader["product_id"]);
                product.name = reader["name"].ToString();
                product.price = Convert.ToDecimal(reader["price"]);
                product.stock = Convert.ToInt32(reader["stock"]);
                product.active = Convert.ToBoolean(reader["active"]);
                listProducts.Add(product);
            }

            connection.Close();

            return listProducts;
        }
    }
}
