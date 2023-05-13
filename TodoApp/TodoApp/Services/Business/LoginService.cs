using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TodoApp.Models;
using TodoApp.Services.Data;

namespace TodoApp.Services.Business
{
    public class LoginService
    {
        LoginDAO loginDAO = new LoginDAO();
        public List<UserModel> Login(LoginModel login)
        {
            var listUser = new List<UserModel>();
            listUser = loginDAO.GetUser(login);
            return listUser;
        }
    }
}