using Task_One;

class Customer
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public static bool IsLoggedIn=false;
    public List<Accounts> Account = new List<Accounts>();
    static readonly string[] header = new string[] { "FULL NAME", "ACCOUNT NUMBER", "ACCOUNT TYPE", " AMOUNT BAL" };
    PrintTable printTable = new PrintTable(header);
    public string password;
    
    public Customer(string firstname, string lastname, string email, double initialDeposit, string accountType, string password)
    {
        FullName = firstname +" " + lastname;

        Email = email; 
       
        this.password = password;
        Account.Add(new Accounts(accountType, initialDeposit, Email));  
    }
    public void OpenNewAccount(string type, double initialDeposit)
    {
        Account.Add(new Accounts(type, initialDeposit, Email));
        
    }
    private void AppendToTableRow(string fullName, string acctNo, string acctType, double bal)
    {
        var row = new string[] { fullName, acctNo, acctType, Convert.ToString(bal) };
        printTable.AddRow(row);
    }
    public void PrintAllAccounts()
    {
        foreach(var account in Account)
        {
            AppendToTableRow(FullName, account.AccountNo, account.AccountType, account.Balance);
        }
        printTable.Print();
        printTable.ClearRow();  
    }
}
