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

            SqlCommand command = new SqlCommand("ListarProductos", connection);
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

        public void InsertProduct(Product product)
        {
            SqlConnection connection = new SqlConnection(Conexion.cadena);
            connection.Open();

            SqlCommand command = new SqlCommand("InsertarProductos", connection);
            command.CommandType = CommandType.StoredProcedure;

            // Parámetros del procedimiento almacenado
            command.Parameters.AddWithValue("@name", product.name);
            command.Parameters.AddWithValue("@price", product.price);
            command.Parameters.AddWithValue("@stock", product.stock);
            command.Parameters.AddWithValue("@active", product.active);

            command.ExecuteNonQuery();
            connection.Close();
        }


        public void UpdateProduct(Product product)
        {
            SqlConnection connection = new SqlConnection(Conexion.cadena);
            connection.Open();

            SqlCommand command = new SqlCommand("ActualizarProductos", connection);
            command.CommandType = CommandType.StoredProcedure;

            // Parámetros del procedimiento almacenado
            command.Parameters.AddWithValue("@productId", product.product_id);
            command.Parameters.AddWithValue("@name", product.name);
            command.Parameters.AddWithValue("@price", product.price);
            command.Parameters.AddWithValue("@stock", product.stock);
            command.Parameters.AddWithValue("@active", product.active);

            command.ExecuteNonQuery();
            connection.Close();
        }

    }
}
