using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BankCustomersApp
{
    internal class BankUI
    {
        public Customer CurrentCustomer { get; set; }
        public Bank bank;
        public BankUI()
        {
            bank = new Bank();
            Greeting();
        }
        public void Greeting()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Owonikoko Microfinance Bank");
            Console.WriteLine();
        }

        public void StartApp()
        {
            Console.Clear();
            Greeting();
            Console.WriteLine("Please type the following prompt for any of the service listed");
            Console.WriteLine();
            Console.WriteLine("To open an acccount as a new customer enter: \n\r1. New Customer \n\r2. Login \n\r3. Help \n\r4. to LEAVE");

            string welcomeAction = Console.ReadLine();
            while (true)
            {
                if (welcomeAction == null)
                {
                    Console.WriteLine("Input cannot be empty");
                    Console.WriteLine();
                    Console.WriteLine("Please type: \n\r'1' to OPEN an account \n\r '2' Login \n\r '3' Help \n\r'4' Leave");
                    Console.WriteLine();
                    welcomeAction = Console.ReadLine();
                    continue;
                }
                if (welcomeAction == "1" || welcomeAction == "2" || welcomeAction == "3" || welcomeAction == "4") break;
                else Console.Write("Please Enter any of the valid options above 1-3: ");
                welcomeAction = Console.ReadLine();
            }
            if (welcomeAction == "1") CreateNewCustomerPrompt();
            else if (welcomeAction == "2") Login();
            else if (welcomeAction == "3") HelpPrompt();
            else Leave();
        }

        public void Login()
        {
            Console.Clear();
            Console.WriteLine("To Login Please provide your Email and password");
            string email, password;
            Console.Write("Input your account Email: ");
            email = Console.ReadLine();
            while (true)
            {
                if (email == null)
                {
                    Console.WriteLine("Email field cannot be empty");
                    continue;
                }
                Console.Write("Input your account Password: ");
                password = Console.ReadLine();
                if (password == null)
                {
                    Console.WriteLine("password field cannot be empty");
                    continue;
                }
                break;
            }
            
            CurrentCustomer = bank.Login(email, password);
            if(CurrentCustomer != null)
            {
                LandingPage();
            }else
            {
                Console.WriteLine("User not Found, Try again");
                Console.ReadLine();
                StartApp();
            } 
        }

        public void  CreateNewCustomerPrompt ()
        {
            Console.Clear();
            Console.Write("Type 0 For Savings Account and 1 For Current Account: ");
            var acctTypeSel = Console.ReadLine();
            while (true)
            {
                if (acctTypeSel == null)
                {
                    Console.WriteLine("Input cannot be empty");
                    Console.WriteLine();
                    Console.WriteLine("Please type: \n\r'1' to OPEN an account \n\r '2' To go to the HELP page \n\r '3' To QUIT");
                    Console.WriteLine();
                    acctTypeSel = Console.ReadLine();
                    continue;
                }
                if (acctTypeSel == "0" || acctTypeSel == "1") break;
                else Console.Write("Please Enter any of the valid options 0-1: ");
                acctTypeSel = Console.ReadLine();
            }
            if (acctTypeSel == "0") CreateNewSavingsAccountCustomer();
            else CreateNewCurrentAccountCustomer();
        }

        public void LandingPage()
        {
            Console.Clear();
            Console.WriteLine("Hello, {0}", CurrentCustomer.FullName);
            Console.WriteLine("What action would you like to take?");
            Console.WriteLine("1. Deposit \n\r2. Withdrawal \n\r3. Check accounts Details \n\r4.Transfer \n\r5. Statement of Account \n\r6. Create another Account \n\r7Logout");
            Console.Write("Please input a number from 1-6: ");
            var prompt = Console.ReadLine();
            while (true)
            {
                if (prompt == null)
                {
                    Console.Write("Please enter a number between 1-6: ");
                    prompt = Console.ReadLine();
                    continue;
                }

                if (prompt == "1" || prompt == "2" || prompt == "3" || prompt == "4" || prompt == "5" || prompt == "6" || prompt == "7")
                {
                    break;
                }
                else
                {
                    Console.Write("Please enter a number between 1-7: ");
                    prompt = Console.ReadLine();
                    continue;
                }
                break;
            }
            if (prompt == "1") Deposit();

            else if (prompt == "2") Withdrawal();

            else if (prompt == "3") AccountDetails();

            else if (prompt == "4") Transfer();

            else if (prompt == "5") SOA();

            else if (prompt == "6") CreateNewAcct();

            else Logout();
        }

        public void Logout()
        {
            StartApp();
        }

        public void CreateNewAcct()
        {
            Console.Clear();
            Console.WriteLine("What type of Account are you creating?");
            Console.WriteLine("1. Savings \n\r2. Current");
            Console.Write("please choose account type: ");
            var prompt = Console.ReadLine();
            while (true)
            {
                if (prompt == null)
                {
                    Console.Write("Input cannot be empty. Choose 1 or 2: ");
                    prompt = Console.ReadLine();
                    continue;
                }

                if (prompt == "1")
                {
                    NewSavingsAcct();
                    break;
                }
                else if (prompt == "2")
                {
                    NewCurrentAccount();
                    break;
                }
                else
                {
                    Console.Write("Invalid Input, pleae type 1 or 2: ");
                    prompt = Console.ReadLine();
                    continue;
                }
                break;
            }
        }
        public void NewSavingsAcct()
        {
            double initialDeposit = InitialDepositSavings();
            CurrentCustomer.OpenNewAccount("Savings", initialDeposit);
            Console.Clear();
            PageSuccessfulCreated("savings");
        }
        public void NewCurrentAccount()
        {
            double initialDeposit = InitialDepositCurrent();
            CurrentCustomer.OpenNewAccount("Current", initialDeposit);
            Console.Clear();
            PageSuccessfulCreated("current");
        }

        public void PageSuccessfulCreated(string acc)
        {
            Console.WriteLine("You have successfully Created a " + acc + " account");
            Console.WriteLine("Account details are has follow: \n\rAccount Number: {0}\n\rBalance: {1}", CurrentCustomer.Account[CurrentCustomer.Account.Count - 1].AccountNo, CurrentCustomer.Account[CurrentCustomer.Account.Count - 1].Balance);
            Console.WriteLine("Please save your details.\n\rPress Enter key to continue");
            Console.ReadLine();
            LandingPage();
        }
        public void Deposit()
        {
            Console.Clear();
            Console.Write("Input the account you want to deposit in: ");
            var getAmtIndex = GetAccountAmountAndIndex("deposit");
            CurrentCustomer.Account[(int) getAmtIndex[0]].Deposit("Credit alert!", getAmtIndex[1], "");
            //Customer.Account[(int)getAmtIndex[0]].Deposit("Credit alert!", getAmtIndex[1], "");
            Console.WriteLine("Press any Enter to go to Home page");
            Console.ReadLine();
            LandingPage();
        }

        public void Withdrawal()
        {
            Console.Clear();

            Console.Write("Input the account you want to Withdraw from: ");
            var getAmtIndex = GetAccountAmountAndIndex("withdraw");
            if (getAmtIndex[1] != 0)
            {
                CurrentCustomer.Account[(int) getAmtIndex[0]].Withdrawal("Debit alert!", getAmtIndex[1], "");
               // Customer.Account[(int)getAmtIndex[0]].Withdrawal("Debit alert!", getAmtIndex[1], "");
            }
            else
            {
                Console.WriteLine("Insufficient Balance");
            }
            Console.WriteLine("Press any key to go to Home page");
            Console.ReadLine();
            LandingPage();
        }


        public void AccountDetails()
        {
            Console.Clear();
            Console.WriteLine("ACCOUNT DETAILS");
            CurrentCustomer.PrintAllAccounts();
            Console.WriteLine("Press Enter key to go to Home Page");
            Console.ReadLine();
            LandingPage();
        }
        public void Transfer()
        {
            Console.Clear();
            if (CurrentCustomer.Account.Count < 2 && bank.Customers.Count < 2)
            {
                Console.WriteLine(CurrentCustomer.Account.Count);
                Console.WriteLine(bank.Customers.Count);

                Console.WriteLine("No account to transfer to. Press Enter to go to Home page");
                Console.ReadLine();
                LandingPage();
            }


            int index;
            string sendAcct, destAcct;
            double amount;
            

            List<Accounts> DestAccts;
            List<Accounts> SendAccts;
            Console.WriteLine("please enter the account you want to send from");
            sendAcct = Console.ReadLine();
            while (true)
            {
                if (sendAcct == null)
                {
                    Console.Write("Account field cannot be empty; re-enter account number: ");
                    sendAcct = Console.ReadLine();
                    continue;
                }
                if (!Accounts.AccountMailPair.ContainsKey(sendAcct) || Accounts.AccountMailPair[sendAcct] != CurrentCustomer.Email)
                {
                    Console.Write("Account not found. Kindly enter correct account number: ");
                    sendAcct = Console.ReadLine();
                    continue;
                }
                else
                {
                    SendAccts = bank.Customers[Accounts.AccountMailPair[sendAcct]].Account;
                    break;
                }

            }
            Console.Write("please enter the account you want to send to: ");
            destAcct = Console.ReadLine();

            while (true)
            {
                if (destAcct == null)
                {
                    Console.Write("Account field cannot be empty; re-enter account number: ");
                    destAcct = Console.ReadLine();
                    continue;
                }
                if (!Accounts.AccountMailPair.ContainsKey(destAcct))
                {
                    Console.Write("Account not found. Kindly enter correct account number: ");
                    destAcct = Console.ReadLine();
                    continue;
                }
                else
                {
                    DestAccts = bank.Customers[Accounts.AccountMailPair[destAcct]].Account;
                    
                    break;
                }

            }
            Console.Write("Kindly enter the amount you wish to transfer: ");
            bool amountCheck = double.TryParse(Console.ReadLine(), out amount);

            while (true)
            {
                if (amount == null)
                {
                    Console.Write("Amount field cannot be empty: ");
                    amount = double.Parse(Console.ReadLine());
                    continue;
                }

                if (!amountCheck || amount < 1)
                {
                    Console.Write("Kindly enter a valid amount: ");
                    amount = double.Parse(Console.ReadLine());
                    continue;
                }
                break;
            }

            int indexDes = 0;
            for (int i =0; i<DestAccts.Count; i++ )
            {
                if (DestAccts[i].AccountNo == destAcct)
                {
                    indexDes = i;
                }
            }
            index = 0;
            for (int i = 0; i < SendAccts.Count; i++)
            {
                if (SendAccts[i].AccountNo == sendAcct)
                {
                    index = i;
                }
            }
            CurrentCustomer.Account[index].Transfer("Transferred " + amount + " to " + destAcct, amount, DestAccts[indexDes]);

            Console.WriteLine("Press Enter to go back to Home page.");
            Console.ReadLine();
            LandingPage();
        }
        public void SOA()
        {
            Console.Clear();
            Console.WriteLine("Input an account to get the account statement");
            var prompt = Console.ReadLine();
            int index;
            List<Accounts> UserDetails;
            while (true)
            {
                if (prompt == null)
                {
                    Console.Write("Enter a valid account number: ");
                    prompt = Console.ReadLine();
                    continue;
                }
                
                if (!Accounts.AccountMailPair.ContainsKey(prompt) || Accounts.AccountMailPair[prompt] != CurrentCustomer.Email)
                {
                    Console.WriteLine("invalid Account. Enter another account: ");
                    prompt = Console.ReadLine();
                    continue;
                }
                else
                {
                    UserDetails = bank.Customers[Accounts.AccountMailPair[prompt]].Account;
                    index = Accounts._allAccounts.IndexOf(prompt);
                }
                break;
            }

            for(int i = 0; i < UserDetails.Count; i++)
            {
                if(UserDetails[i].AccountNo == prompt)
                {
                    index = i;
                }
            }
            Console.WriteLine("ACCOUNT STATEMENT ON ACCOUNT NO " + prompt);
            CurrentCustomer.Account[index].PrintTrans();
            //Customer.Account[index].PrintTrans();
            Console.WriteLine("Press Enter key to go to Home page");
            Console.ReadLine();
            LandingPage();
        }
        public List<double> GetAccountAmountAndIndex(string depOrWith)
        {
            string acct = Console.ReadLine();
            var amtIndex = new List<double>();
            List<Accounts> AllUserAccounts;
            Accounts DepositAcc;
            int index;
            double amount = 0;
            while (true)
            {
                if (acct == null)
                {
                    Console.Write("Please type an account: ");
                    acct = Console.ReadLine();
                    continue;
                }
                
                if (!Accounts.AccountMailPair.ContainsKey(acct) || Accounts.AccountMailPair[acct] != CurrentCustomer.Email)
                {
                    Console.Write("This account does not exist, check and try again: ");
                    acct = Console.ReadLine();
                    continue;
                }
                else
                {
                    DepositAcc = CurrentCustomer.Account.Where(x => x.AccountNo == acct).FirstOrDefault();
                    index = CurrentCustomer.Account.IndexOf(DepositAcc);
                }
                if (DepositAcc.Balance == 0 && depOrWith == "withdraw")
                {
                    Console.WriteLine("Insufficient funds");
                    break;
                }
                Console.Write("Enter the amount to " + depOrWith + ": ");
                bool correctAmount = double.TryParse(Console.ReadLine(), out amount);
                while (true)
                {
                    if (!correctAmount)
                    {
                        Console.Write("Invalid Amount, Enter amount again: ");
                        correctAmount = double.TryParse(Console.ReadLine(), out amount);
                        continue;
                    }
                    if (amount <= 0)
                    {
                        Console.Write("Invalid amount, Put amount greater than 0: ");
                        correctAmount = double.TryParse(Console.ReadLine(), out amount);
                        continue;
                    }
                    if ((depOrWith == "withdraw" && DepositAcc.AccountType == "Savings" && DepositAcc.Balance - amount < 1000))
                    {
                        Console.Write("Insufficient balance, savings acct can't be less than 1000. Enter lower amount: ");
                        correctAmount = double.TryParse(Console.ReadLine(), out amount);
                        continue;
                    }

                    if (depOrWith == "withdraw" && amount > DepositAcc.Balance)
                    {
                        Console.Write("Insufficient balance. Enter lower amount: ");
                        correctAmount = double.TryParse(Console.ReadLine(), out amount);
                        continue;
                    }

                    break;
                }
                break;
            }

            amtIndex.Add(index);
            amtIndex.Add(amount);

            return amtIndex;
        }
        public void CreateNewSavingsAccountCustomer()
        {
            Console.WriteLine("fill your correct data below.");
            var biodata = BiodataForm();
            double initialDeposit = InitialDepositSavings();

            CurrentCustomer = new Customer(biodata[0], biodata[1], biodata[2], initialDeposit, "Savings", biodata[3]);
            bank.Customers[biodata[2]] = CurrentCustomer;
            Console.Clear();
            Console.WriteLine("Your login details email: {0} and password: {1}. Your account number is {2} Account type is Savings", CurrentCustomer.Email, CurrentCustomer.password, CurrentCustomer.Account[CurrentCustomer.Account.Count - 1].AccountNo);
            Console.WriteLine("Thank you for opening account with us");
            Console.WriteLine("Press Enter key to Login into you account");
            Console.ReadLine();
            StartApp();
        }

        public void CreateNewCurrentAccountCustomer()
        {
            Console.WriteLine("fill your correct data below.");
            var biodata = BiodataForm();
            double initialDeposit = InitialDepositCurrent();

            CurrentCustomer = new Customer(biodata[0], biodata[1], biodata[2], initialDeposit, "Current", biodata[3]);
            bank.Customers[biodata[2]] = CurrentCustomer;
            Console.Clear();
            Console.WriteLine("Your login details email: {0} and password: {1}. Your account number is {2} Account type is Savings", CurrentCustomer.Email, CurrentCustomer.password, CurrentCustomer.Account[CurrentCustomer.Account.Count - 1].AccountNo);
            Console.WriteLine("Thank you for opening account with us");
            Console.WriteLine("Press Enter key to Login into you account");
            Console.ReadLine();
            StartApp();
        }

        public List<string> BiodataForm()
        {
            var biodata = new List<string>();
            string firstName, lastName, email, password;
            string pattName = @"^[a-zA-Z][a-zA-Z]*\s?'?-?[a-zA-Z,]{1,}$";
            string pattMail = @"^[a-z]\w+@\w+\.[a-z]{2,3}";
            string pattPassword = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{6,}$";
            Regex reg;

            Console.WriteLine("What's your Firstname?");
            firstName = Console.ReadLine();
            while (true)
            {
                reg = new Regex(pattName);
                while (true)
                {
                    if (firstName == null)
                    {
                        Console.Write("Firstname field cannot be empty, Input your firstname: ");
                        firstName = Console.ReadLine();
                        continue;
                    }
                    if (firstName.ToLower()[0] == firstName[0] || !reg.IsMatch(firstName))
                    {
                        Console.WriteLine("Firstname cannot start with a small letter or number or a single letter");
                        Console.Write("Reenter Firstname: ");
                        firstName = Console.ReadLine();
                        continue;
                    }
                    break;
                }
                Console.WriteLine("What's your Lastname?");
                lastName = Console.ReadLine();
                while (true)
                {
                    if (lastName == null)
                    {
                        Console.Write("LastName field cannot be empty, Input your lastname: ");
                        lastName = Console.ReadLine();
                        continue;
                    }
                    if (lastName.ToLower()[0] == lastName[0] || !reg.IsMatch(lastName))
                    {
                        Console.WriteLine("Lastname cannot start with a small letter or number or a single letter");
                        Console.Write("Reenter Lastname: ");
                        lastName = Console.ReadLine();
                        continue;
                    }
                    break;
                }
                reg = new Regex(pattMail);
                Console.WriteLine("What's your email Address?");
                email = Console.ReadLine();
                while (true)
                {
                    if (email == null)
                    {
                        Console.Write("Email field cannot be empty, Input your Email: ");
                        email = Console.ReadLine();
                        continue;
                    }
                    email = email.ToLower();
                    if (!reg.IsMatch(email))
                    {
                        Console.Write("Email not valid. Reenter Email: ");
                        email = Console.ReadLine();
                        continue;
                    }
                    break;
                }
                reg = new Regex(pattPassword);
                Console.WriteLine("Choose a password for your account \n\r Password Format: minimum of 6 characters, contains alphanumeric and at least one of this special characters @, #, $, %, ^, &, !");
                password = Console.ReadLine();
                while (true)
                {
                    if (password == null)
                    {
                        Console.WriteLine("Password field cannot be empty, Input your password");
                        email = Console.ReadLine();
                        continue;
                    }
                    if (!reg.IsMatch(password))
                    {
                        Console.WriteLine("Password format not supported, Format: minimum of 6 characters, contains alphanumeric and at least one of this special characters @, #, $, %, ^, &, !");
                        Console.Write("Reenter password: ");
                        password = Console.ReadLine();
                        continue;
                    }
                    break;
                }
                break;
            }
            biodata.Add(firstName);
            biodata.Add(lastName);
            biodata.Add(email);
            biodata.Add(password);
            return biodata;
        }

        public double InitialDepositSavings()
        {
            double initialDeposit;
            Console.WriteLine("Make a deposit to open a savings account with us.\nMinimum allowable deposit is 1000 Naira.");
            Console.WriteLine();
            Console.Write("Enter the amount you want to deposit here: ");
            bool validAmount = double.TryParse(Console.ReadLine(), out initialDeposit);
            while (true)
            {
                if (!validAmount || initialDeposit < 1000)
                {
                    Console.Write("Please put a valid amount of money not less than 1000: ");
                    validAmount = double.TryParse(Console.ReadLine(), out initialDeposit);
                    continue;
                }
                break;
            }

            return initialDeposit;
        }

        private double InitialDepositCurrent()
        {
            double initialDeposit;
            Console.WriteLine("The minimum amount for a Current account is 0, Make Deposit (Input 0 or more)");
            bool validAmount = double.TryParse(Console.ReadLine(), out initialDeposit);
            while (true)
            {
                if (!validAmount)
                {
                    Console.Write("Please put a valid amount of money: ");
                    validAmount = double.TryParse(Console.ReadLine(), out initialDeposit);
                    continue;
                }

                if (initialDeposit < 0)
                {
                    Console.Write("You can't borrow before opening account, put an amount: ");
                    validAmount = double.TryParse(Console.ReadLine(), out initialDeposit);
                    continue;
                }

                break;
            }

            return initialDeposit;
        }

        public void HelpPrompt()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Owonikoko Microfinance Bank");
            Console.WriteLine("We love you");
            Console.WriteLine("Will you like to open an account now or Leave? \n\r1. -To OPEN an account \n\r2. - to LEAVE Bank");

            string newAction = Console.ReadLine();
            while (true)
            {
                if (newAction == null)
                {
                    Console.WriteLine("Input cannot be empty!");
                    Console.WriteLine("Please Try again");
                    newAction = Console.ReadLine();
                    continue;
                }
                if (newAction == "1" || newAction == "2") break;
                else
                {
                    Console.Write("Invalid input, Reenter a number: ");
                    newAction = Console.ReadLine();
                    continue;
                }
            }
            if (newAction.ToLower() == "1") CreateNewCustomerPrompt();
            else Leave();

        }

        public void Leave()
        {
            Console.Clear();
            Console.WriteLine("Bye, Thank you for stopping by!");
            Console.WriteLine("Press Enter to enter the bank.");
            Console.ReadLine();
            StartApp();
        }
    }
}
