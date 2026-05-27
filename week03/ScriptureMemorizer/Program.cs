using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var scriptures = new List<Scripture>
        {
            new Scripture(
                Reference.Parse("John 3:16"),
                "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."),
            new Scripture(
                Reference.Parse("Proverbs 3:5-6"),
                "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight."),
            new Scripture(
                Reference.Parse("Philippians 4:13"),
                "I can do all this through him who gives me strength."),
            new Scripture(
                Reference.Parse("Psalm 23:1-2"),
                "The Lord is my shepherd, I lack nothing. He makes me lie down in green pastures; he leads me beside quiet waters."),
        };

        var random = new Random();
        var scripture = scriptures[random.Next(scriptures.Count)];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.ReferenceText);
            Console.WriteLine(scripture.GetRenderedText());
            Console.WriteLine();

            if (scripture.IsFullyHidden)
            {
                Console.WriteLine("All words are hidden. Great work on memorizing this scripture!");
                break;
            }

            Console.Write("Press Enter to hide more words, or type quit and press Enter: ");
            var userInput = Console.ReadLine()?.Trim().ToLower();
            if (userInput == "quit")
            {
                break;
            }

            scripture.HideRandomWords();
        }

        // Creativity: This program selects a scripture at random from a scripture library so the user can practice different passages each time.
        // It also hides only currently visible words and preserves punctuation while hiding words, improving the memorization experience.
    }
}