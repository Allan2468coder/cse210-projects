using System;

class Program
{
    static void Main(string[] args)
    {
        // Prompt for first name
        Console.Write("What is your first name? ");
        string first = Console.ReadLine();

        // Prompt for last name
        Console.Write("What is your last name? ");
        string last = Console.ReadLine();

        // Display formatted output
        Console.WriteLine($"Your name is {last}, {first} {last}.");
    }
}