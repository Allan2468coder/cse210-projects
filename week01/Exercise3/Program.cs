using System;

class Program
{
    static void Main(string[] args)
    {
        // Step 1: Generate random magic number
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101); // 1–100

        // Step 2: Initialize guess variable
        int guess = -1;

        // Step 3: Loop until correct guess
        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }
    }
}
