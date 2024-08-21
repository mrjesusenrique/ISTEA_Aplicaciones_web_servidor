using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Data.SqlClient;

namespace ConsoleApp_AWS_2
{
    class Program
    {
        static void Main(string[] args)
        {
            CRUD oCRUD = new CRUD();
            //oCRUD.CreateProduct("Doritos", 19.99m);
            //oCRUD.ReadProducts();
            oCRUD.UpdateProduct(6, "Platano", 13.99m);
            //oCRUD.DeleteProduct(7);
        }
    }

    class CRUD
    {
        string connectionString = "Server=localhost;Database=ISTEA_AWS;Trusted_Connection=True;;TrustServerCertificate=True;";

        public void CreateProduct(string productName, decimal price)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Products (ProductName, Price) VALUES (@ProductName, @Price)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductName", productName);
                command.Parameters.AddWithValue("@Price", price);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void ReadProducts()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Products";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine("ID: {" + reader["ProductID"] + "}, Name: {" + reader["ProductName"] + "}, Price: {" + reader["Price"] + "}");
                }

                reader.Close();
                connection.Close();
                Console.ReadKey();
            }
        }

        public void UpdateProduct(int productId, string productName, decimal price)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Products SET ProductName = @ProductName, Price = @Price WHERE ProductID = @ProductID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductID", productId);
                command.Parameters.AddWithValue("@ProductName", productName);
                command.Parameters.AddWithValue("@Price", price);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void DeleteProduct(int productId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Products WHERE ProductID = @ProductID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductID", productId);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
