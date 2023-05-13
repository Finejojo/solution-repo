class Transactions {
    public string Date { get; set; }
    public string Description { get; set; }
    public double Amount { get; set; }
    public double Balance { get; set; }
    /*
    public Transactions(string description, double amount)
    {
        Description = description;
        Amount = amount;
    }

    
    public double Withdrawal(double balance) { 
        return balance - Amount;
    }

    public double Deposit(double balance) { 
        return balance + Amount;
    }
    */
}
