class Program
{
    static void Main()
    {
        Journal journal = new Journal();
        string filename = "journal.csv";

        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option: ");

            string input = Console.ReadLine();
            Console.WriteLine();

            switch (input)
            {
                case "1":
                    WriteEntry(journal);
                    break;
                case "2":
                    DisplayEntries(journal);
                    break;
                case "3":
                    LoadJournal(journal, filename);
                    break;
                case "4":
                    SaveJournal(journal, filename);
                    break;
                case "5":
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void WriteEntry(Journal journal)
    {
        string[] prompts = {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "What was the strongest emotion I felt today?",
            "How did I see the hand of the Lord in my life today?",
            "If I had one thing I could do over today, what would it be?"
        };

        Random random = new Random();
        int randomIndex = random.Next(prompts.Length);
        string prompt = prompts[randomIndex];

        Console.WriteLine(prompt);
        string response = Console.ReadLine();

        journal.AddEntry(prompt, response);
    }

    static void DisplayEntries(Journal journal)
    {
        List<Entry> entries = journal.GetAllEntries();

        foreach (Entry entry in entries)
        {
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Response: {entry.Response}");
            Console.WriteLine($"Date: {entry.Date}");
            Console.WriteLine();
        }
    }

    static void LoadJournal(Journal journal, string filename)
    {
        journal.LoadFromFile(filename);
        Console.WriteLine("Journal loaded successfully!");
    }

    static void SaveJournal(Journal journal, string filename)
    {
        journal.SaveToFile(filename);
        Console.WriteLine("Journal saved successfully!");
    }
}
