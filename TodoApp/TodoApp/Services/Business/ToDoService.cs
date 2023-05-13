using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TodoApp.Models;
using TodoApp.Services.Data;

namespace TodoApp.Services.Business
{
    public class ToDoService
    {
        ToDoDAO toDoDAO = new ToDoDAO();
        public List<TodoModel> UserTasks(int userId)
        {
            List<TodoModel> list = new List<TodoModel>();
            list = toDoDAO.GetAllUserTodo(userId);
            return list;
        }
        public List<TodoModel> SearchTasks(int userId,string search)
        {
            List<TodoModel> list = new List<TodoModel>();
            list = toDoDAO.SearchUserTodo(userId,search);
            return list;
        }
        
        public List<TodoModel> UserTask(int TaskId, int userId)
        {
            List<TodoModel> list = new List<TodoModel>();
            list = toDoDAO.GetUserTodo(TaskId, userId);
            return list;
        }

        public bool SaveNewTask(int UserId, TodoModel todoModel)
        {
            bool saved = false;
            saved = toDoDAO.InsertTodo(UserId, todoModel);
            return saved;
        }

        public bool UpdateTask(int taskId, TodoModel todoModel)
        {
            bool updated = false;
            updated = toDoDAO.UpadteTodo(taskId, todoModel);
            return updated;
        }
        public bool DeleteTask(int taskId)
        {
            bool deleted = false;
            deleted = toDoDAO.RemoveTodo(taskId);
            return deleted; 
        }

        public bool DeleteAllTask(int userId)
        {
            bool deleted = false;
            deleted = toDoDAO.RemoveAllUserTodo(userId);
            return deleted;
        }
    }
}