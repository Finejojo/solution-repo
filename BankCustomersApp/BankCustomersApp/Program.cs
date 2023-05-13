using System.ComponentModel;
using System.ComponentModel.Design;
using System.Transactions;
using System.Text.RegularExpressions;
using BankCustomersApp;

class Program
{
    private static void Main(string[] args)
    {
        var ui = new BankUI();
        ui.StartApp();
        
        //Console.WriteLine(DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
        //string pattName = @"^[a-zA-Z][a-zA-Z]*\s?'?-?[a-zA-Z,]{1,}$";
        //string pattMail = @"^[a-z]\w+@\w+\.[a-z]{2,3}";
        //string pattPassword = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{6,}$";
        //Regex rg = new Regex(pattPassword);
        //string txt = "@Samule@B2";
        //Console.WriteLine(rg.IsMatch(txt));
    }
}