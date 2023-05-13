using System;
using static System.Console;

namespace WebApplica
{
    class Program
    {
        static void Main(string[] args)
        {
            Program newProgram =  new();
            newProgram.Standdard();
        }

        void Standdard()
        {
            Console.WriteLine("Enter a name: ");
            string name = Console.ReadLine();
            do { Console.WriteLine("You have to enter a name..."); }
            while (name == "");

            switch (name)
            {
                case "David":
                    { Console.WriteLine($"Hello {name}"); };
                    break;
                case "Victor":
                    { Console.WriteLine($"Hello {name}"); };
                    return;
                default:
                    { Console.WriteLine($"Hello New User"); };
                    break;
            }
            Console.WriteLine("Hello");
            Console.ReadKey();
        }
    }
}
