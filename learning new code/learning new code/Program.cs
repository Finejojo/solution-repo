using System;

namespace ATM
{
    public class ATMDispenser
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the amount to withdraw");
            int amount = int.Parse(Console.ReadLine());
            int hundredBills = amount / 100;
            amount %= 100;
            int fiftyBills = amount / 50;
            amount %= 50;
            int twentyBills = amount / 20;
            //amount %= 20;

            Console.WriteLine($"Number of $100 bill: {hundredBills} \nNumber of $50 bills: {fiftyBills} \nNumber of $20 bills: {twentyBills}");
        }
    }
}