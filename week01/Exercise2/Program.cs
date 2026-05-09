using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask the user for their grade percentage
        Console.Write("What is your grade percentage? ");
        string gradeInput = Console.ReadLine();
        int gradePercentage = int.Parse(gradeInput);

        // Determine letter grade using a letter variable
        string letter = "";

        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Print letter grade once after all the conditions
        Console.WriteLine($"Your letter grade is: {letter}");

        // Check if student passed (70 or higher)
        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course!");
        }
        else
        {
            Console.WriteLine("Don't worry, you'll do better next time!");
        }
    }
}
