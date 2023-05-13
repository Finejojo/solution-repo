using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TodoApp.Models;

namespace TodoApp.Services.Data
{
    
    public class ToDoDAO
    {
        string conString = ConfigurationManager.ConnectionStrings["todoConnectionString"].ConnectionString;
        public List<TodoModel> GetAllUserTodo(int userId)
        {
            var todoList = new List<TodoModel>();
            using(SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "sp_GetAllUserTask";
                command.Parameters.AddWithValue("@UserId", userId);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable data = new DataTable();
                connection.Open();
                adapter.Fill(data);
                connection.Close();
                foreach (DataRow row in data.Rows)
                {
                    todoList.Add(new TodoModel
                    {
                        TaskId = Convert.ToInt32(row["Id"]),
                        Task = Convert.ToString(row["Task"]),
                        Priority = Convert.ToString(row["Priority"]),
                        Category = Convert.ToString(row["Category"]),
                        Created = Convert.ToDateTime(row["CreatedAt"]),
                    });
                }
            }

            return todoList;
        }
        //sp_SearchUserTask
        public List<TodoModel> SearchUserTodo(int userId, string search="")
        {
            var todoList = new List<TodoModel>();
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "sp_SearchUserTask";
                command.Parameters.AddWithValue("@UserId", userId);
                command.Parameters.AddWithValue("@SearchString", search);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable data = new DataTable();
                connection.Open();
                adapter.Fill(data);
                connection.Close();
                foreach (DataRow row in data.Rows)
                {
                    todoList.Add(new TodoModel
                    {
                        TaskId = Convert.ToInt32(row["Id"]),
                        Task = Convert.ToString(row["Task"]),
                        Priority = Convert.ToString(row["Priority"]),
                        Category = Convert.ToString(row["Category"]),
                        Created = Convert.ToDateTime(row["CreatedAt"]),
                    });
                }
            }

            return todoList;
        }
        public List<TodoModel> GetUserTodo(int taskId, int userId)
        {
            var todoList = new List<TodoModel>();
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "sp_GetUserTask";
                command.Parameters.AddWithValue("@TaskId", taskId);
                command.Parameters.AddWithValue("@UserId", userId);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable data = new DataTable();
                connection.Open();
                adapter.Fill(data);
                connection.Close();
                foreach (DataRow row in data.Rows)
                {
                    todoList.Add(new TodoModel
                    {
                        Task = Convert.ToString(row["Task"]),
                        Priority = Convert.ToString(row["Priority"]),
                        Category = Convert.ToString(row["Category"]),
                        Created = Convert.ToDateTime(row["CreatedAt"]),
                    });
                }
            }

            return todoList;
        }
       
        public bool InsertTodo(int userId, TodoModel todoModel)
        {
            int id = 0;
            using(SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand sqlCommand = new SqlCommand("sp_InsertTask", connection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Task", todoModel.Task);
                sqlCommand.Parameters.AddWithValue("@Priority", todoModel.Priority);
                sqlCommand.Parameters.AddWithValue("@Category", todoModel.Category);
                sqlCommand.Parameters.AddWithValue("@UserId", userId);
                sqlCommand.Parameters.AddWithValue("@CreatedAt", todoModel.Created);

                connection.Open();
                id = sqlCommand.ExecuteNonQuery();
                connection.Close();

            }
            return id != 0;
        }

        public bool UpadteTodo(int taskId, TodoModel todoModel)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand sqlCommand = new SqlCommand("sp_UpdateTask", connection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@TaskId", taskId);
                sqlCommand.Parameters.AddWithValue("@Task", todoModel.Task);
                sqlCommand.Parameters.AddWithValue("@Priority", todoModel.Priority);
                sqlCommand.Parameters.AddWithValue("@Category", todoModel.Category);
                sqlCommand.Parameters.AddWithValue("@CreatedAt", todoModel.Created);

                connection.Open();
                id = sqlCommand.ExecuteNonQuery();
                connection.Close();

            }
            return id != 0;
        }

        public bool RemoveTodo(int taskId)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand sqlCommand = new SqlCommand("sp_DeleteTask", connection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@TaskId", taskId);
                
                connection.Open();
                id = sqlCommand.ExecuteNonQuery();
                connection.Close();

            }
            return id != 0;
        }

        public bool RemoveAllUserTodo(int userId)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand sqlCommand = new SqlCommand("sp_DeleteAllTask", connection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@UserId", userId);

                connection.Open();
                id = sqlCommand.ExecuteNonQuery();
                connection.Close();

            }
            return id != 0;
        }
    }
}