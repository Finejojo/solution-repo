using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TodoApp.Models;
using TodoApp.Services.Data;

namespace TodoApp.Services.Business
{
    public class RegistrationService
    {
        RegistrationDAO _registrationDAO = new RegistrationDAO();

        public bool Register(RegisterModel register)
        {
            bool isRegister = false;
            isRegister = _registrationDAO.RegisterUser(register);
            return isRegister;
        }
    }
}