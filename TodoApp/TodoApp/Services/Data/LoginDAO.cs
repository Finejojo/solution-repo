using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using TodoApp.Models;

namespace TodoApp.Services.Data
{
    public class LoginDAO
    {
        string conString = ConfigurationManager.ConnectionStrings["todoConnectionString"].ConnectionString;
        public List<UserModel> GetUser(LoginModel login)
        {
            var userList = new List<UserModel>();
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "sp_GetUser";
                command.Parameters.AddWithValue("@Email", login.Email);
                command.Parameters.AddWithValue("@Password", login.Password);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable data = new DataTable();
                connection.Open();
                adapter.Fill(data);
                connection.Close();
                foreach (DataRow row in data.Rows)
                {
                    userList.Add(new UserModel
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        Name = Convert.ToString(row["Name"]),
                        
                    });
                }
            }

            return userList;
        }
    }
}