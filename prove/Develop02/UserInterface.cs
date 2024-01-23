using System;

class UserInterface
{
    private Journal journal;

    public UserInterface(Journal journal)
    {
        this.journal = journal;
    }

    public void DisplayMenu()
    {
        Console.WriteLine("\n1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Load");
        Console.WriteLine("4. Save");
        Console.WriteLine("5. Quit");
    }

    public int GetMenuChoice()
    {
        Console.Write("Choose an option (1-5): ");
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5)
        {
            Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
            Console.Write("Choose an option (1-5): ");
        }
        return choice;
    }

    public void WriteNewEntry()
    {
        string date = DateTime.Now.ToString("yyyy-MM-dd");
        string prompt = GetRandomPrompt();
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();
        journal.AddEntry(new Entry(date, prompt, response));
        Console.WriteLine("Entry added successfully.");
    }

    private string GetRandomPrompt()
    {
        string[] prompts = {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "How happy were you when you attended sacrament?"
        };

        Random random = new Random();
        int index = random.Next(prompts.Length);
        return prompts[index];
    }

    public void DisplayJournal()
    {
        if (journal.Entries.Count == 0)
        {
            Console.WriteLine("Journal is empty.");
        }
        else
        {
            Console.WriteLine("\nJournal Entries:");
            journal.DisplayEntries();
        }
    }

    public void SaveJournalToFile()
    {
        Console.Write("Enter the filename to save the journal: ");
        string fileName = Console.ReadLine();
        journal.SaveToFile(fileName);
    }

    public void LoadJournalFromFile()
    {
        Console.Write("Enter the filename to load the journal: ");
        string fileName = Console.ReadLine();
        journal.LoadFromFile(fileName);
    }
}
