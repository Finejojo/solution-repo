using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankCustomersApp
{
    internal class Bank
    {
        public Dictionary<string, Customer> Customers { get; set; }
        public Bank()
        {
            Customers = new Dictionary<string, Customer>();
        }
        public Customer Login(string email, string password)
        {
            if (Customers == null || Customers.Count == 0)
            {
                return null;
            }
            if(!Customers.ContainsKey(email))
            {
                return null;
            }
            if(email == Customers[email].Email && password == Customers[email].password)
            {
                return Customers[email];
            }
            return null;
        }
        public void CreateCustomer(string firstname, string lastname, string email, double initialDeposit,string accountType,string password)
        {
            Customer newCustomer = new Customer(firstname, lastname, email, initialDeposit, accountType, password);
            Customers[email] = newCustomer;
        }
    }
}
