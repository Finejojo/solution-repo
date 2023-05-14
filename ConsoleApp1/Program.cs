/*
 4- Write a program that picks a random number between 1 and 10.
 * Give the user 4 chances to guess the number.
 * If the user guesses the number, display "You Won", otherwise, display "You Lost".
 * (To make sure the program is behaving correctly, you can display the secret number on the console first.)
 */

using System;

namespace Exercise_4
{
    class RandomNumber
    {
        static void Main(string[] args)
        {
            int chances = 4, counter = 0, number;
            var luckyNumber = new Random().Next(1, 10);
            do
            {
                Console.Write("Guess the number between 1 and 10: ");
                number = int.Parse(Console.ReadLine());
                if (number == luckyNumber)
                {
                    Console.WriteLine($"You won! {number} is the lucky number");
                    break;
                }
                counter++;
            } while (counter < chances);
            if (!(luckyNumber == number))
            {
                Console.Write($"You lost! Lucky number is {luckyNumber}");
            }
        }
    }
}