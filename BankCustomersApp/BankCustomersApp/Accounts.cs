using Task_One;

class Accounts
{
    public string AccountType { get; set; }
    public static Dictionary<string,string> AccountMailPair = new Dictionary<string,string>();
    public static List<string> _allAccounts = new List<string>();
    static readonly string[] header = new string[] { "DATE", "DESCRIPTION",  "AMOUNT", " BALANCE" };
    PrintTable printTable = new PrintTable(header);
    public string AccountNo { get; set; }
    public double Balance { get; set; }
    public static int indexAcct = 0;
    public List<Transactions> Transaction;
    public Accounts(string accountType, double balance, string mail)
    {
        AccountType = accountType;
        AccountNo = GenerateAccountNo();
        Balance = balance;
        var desc = "Opening Balance";
        string date = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
        Transaction = new List<Transactions>();
        Transaction.Add(new Transactions {Date = date, Description = desc, Amount = balance, Balance = Balance });
        AccountMailPair.Add(AccountNo, mail);
        //AppendToTableRow(date, desc, balance, Balance);
        
    }
    private void AppendToTableRow(string date, string desc, double amount, double bal)
    {
        var row = new string[] {date, desc, Convert.ToString(amount), Convert.ToString(bal)};
        printTable.AddRow(row);
    }
    private string GenerateAccountNo()
    {
        //var acctNo = "0";
        var str = "012345678" + Convert.ToString(indexAcct);
        /*
        Random rd = new Random();
        for (int i = 0; i < 9; i++)
        {
            int rand_num = rd.Next(0, str.Length - 1);
            acctNo += str[rand_num];
        }

        while (_allAccounts.Contains(acctNo))
        {
            for (int i = 0; i < 9; i++)
            {
                int rand_num = rd.Next(0, str.Length - 1);
                acctNo += str[rand_num];
            }
        }
        */
        //_allAccounts.Add(str);
        //_allAccounts.Add(acctNo);
        indexAcct++;
        return str;
    }
    public void Withdrawal(string desc, double amount, string trans)
    {
        string date = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
        Balance -= amount;
        Transaction.Add(new Transactions {Date = date, Description = desc, Amount = amount, Balance = Balance });
        if(trans != "transfer")
        {
            Console.WriteLine("Take your "+ amount + " cash.");
        }
        //AppendToTableRow(date, desc, amount, Balance);
        
    }

    public void Transfer(string desc, double amount, Accounts destAcc)
    {
        if(Balance >= amount)
        {
            if (AccountType == "Savings" && Balance - amount < 1000)
            {
                Console.WriteLine("You must maintain a minimum balance of 1000, Insufficient funds.");
                return;
            }
            //int index = _allAccounts.IndexOf(destAcct);
            destAcc.Deposit("Transfer of N" + amount + " From " + AccountNo, amount, "transfer");
            //Customer.Account[index].Deposit("Transfer of N" +amount+" From "+AccountNo, amount, "transfer");
            Withdrawal(desc, amount, "transfer");
            Console.WriteLine("Transfer Successful!!!");
        }else
        {
            Console.WriteLine("Insufficient Funds");
            return;
        }
    }

    public void Deposit(string desc, double amount, string trans)
    {
        string date = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
        Balance += amount;
        Transaction.Add(new Transactions { Date = date, Description = desc, Amount = amount, Balance = Balance });
        //AppendToTableRow(date, desc, amount, Balance);
        if (trans != "transfer")
        {
            Console.WriteLine("You have successfully deposited " + amount + " into your account with this account number: " + AccountNo);
        }
    }
    public void PrintTrans()
    {
      
        if (Transaction.Count == 0) Console.WriteLine("No transactions on this account");
        foreach(var trans in Transaction)
        {
            AppendToTableRow(trans.Date, trans.Description, trans.Amount, trans.Balance);
        }
        printTable.Print();
        //foreach (var trans in Transaction) Console.WriteLine("Description: {0} - Amount: {1}", trans.Description, trans.Amount);
        printTable.ClearRow();
        
    }
}
