using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TodoApp.Models;

namespace TodoApp.Services.Data
{
    public class RegistrationDAO
    {
        string conString = ConfigurationManager.ConnectionStrings["todoConnectionString"].ConnectionString;
        public bool RegisterUser(RegisterModel register)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                string Name = register.Firstname + " " + register.Lastname;
                SqlCommand sqlCommand = new SqlCommand("sp_InsertUser", connection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Name", Name);
                sqlCommand.Parameters.AddWithValue("@Email", register.Email);
                sqlCommand.Parameters.AddWithValue("@Password", register.Password);
                
                connection.Open();
                id = sqlCommand.ExecuteNonQuery();
                connection.Close();

            }
            return id != 0;
        }
    }
}