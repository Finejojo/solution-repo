using SampleApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SampleApp.DAL
{
    public class Product_DAL
    {
        string conString = ConfigurationManager.ConnectionStrings["adoConnectionString"].ConnectionString;

        public List<ProductModel> GetAllProducts()
        {
            var products = new List<ProductModel>();
            
            using(SqlConnection conn = new SqlConnection(conString))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_GetAllProducts";
                SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);

                DataTable dtProducts = new DataTable();
                conn.Open();
                sqlDA.Fill(dtProducts);
                conn.Close();
                foreach(DataRow dr in dtProducts.Rows)
                {
                    products.Add(new ProductModel
                    {
                        ProductId = Convert.ToInt32(dr["ProductId"]),
                        Name = Convert.ToString(dr["Name"]),
                        Price = Convert.ToDecimal(dr["Price"])
                    });
                }
            }

            return products;
        }

        public List<ProductModel> GetProduct(int prodId)
        {
            var product = new List<ProductModel>();

            using (SqlConnection conn = new SqlConnection(conString))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "sp_GetProductById";
                cmd.Parameters.AddWithValue("@ProductId", prodId);
                SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);

                DataTable dtProducts = new DataTable();
                conn.Open();
                sqlDA.Fill(dtProducts);
                conn.Close();
                foreach (DataRow dr in dtProducts.Rows)
                {
                    product.Add(new ProductModel
                    {
                        ProductId = Convert.ToInt32(dr["ProductId"]),
                        Name = Convert.ToString(dr["Name"]),
                        Price = Convert.ToDecimal(dr["Price"])
                    });
                }
            }

            return product;
        }

        public bool InsertProduct(ProductModel productModel)
        {
            int id = 0;
            using (SqlConnection conn = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("sp_InsertProd",conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", productModel.Name);
                command.Parameters.AddWithValue("@Price", productModel.Price);

                conn.Open();
                id = command.ExecuteNonQuery();
                conn.Close();   
            }

            return id != 0;
        }

        public bool UpdateProduct(int prodId, ProductModel productModel)
        {
            int id = 0;
            using (SqlConnection conn = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("sp_UpdateProd", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProductId", prodId);
                command.Parameters.AddWithValue("@Name", productModel.Name);
                command.Parameters.AddWithValue("@Price", productModel.Price);

                conn.Open();
                id = command.ExecuteNonQuery();
                conn.Close();
            }

            return id != 0;
        }
    }
}