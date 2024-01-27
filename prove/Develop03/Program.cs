using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create a library of scriptures
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture("John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."),
            new Scripture("Proverbs 3:5-6", "Trust in the LORD with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight."),
           
        };

        // Start the gradual memorization process with a random scripture
        while (true)
        {
            Scripture randomScripture = GetRandomScripture(scriptures);

            Console.WriteLine(randomScripture.GetFullScripture());

            while (!randomScripture.AllWordsHidden())
            {
                Console.WriteLine("Press Enter to continue or type 'quit' to exit:");
                string userInput = Console.ReadLine();

                if (userInput.ToLower() == "quit")
                    return;

                // Hide a few random words
                randomScripture.HideRandomWords();

                // Clear console and display the updated scripture
                Console.Clear();
                Console.WriteLine(randomScripture.GetVisibleScripture());
            }

            Console.WriteLine("You have successfully memorized the scripture! Press Enter to continue or type 'quit' to exit:");
            break;

             
        }
    }

    static Scripture GetRandomScripture(List<Scripture> scriptures)
    {
        Random random = new Random();
        int index = random.Next(scriptures.Count);
        return scriptures[index];
    }
}
