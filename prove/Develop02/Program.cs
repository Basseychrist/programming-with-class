public class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool quit = false;

        while (!quit)
        {
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // Generate a random prompt
                    string[] prompts = { "Prompt 1", "Prompt 2", "Prompt 3", "Prompt 4", "Prompt 5" };
                    Random random = new Random();
                    string randomPrompt = prompts[random.Next(prompts.Length)];

                    // Get user response
                    Console.Write($"{randomPrompt}: ");
                    string response = Console.ReadLine();

                    // Create a new entry and add it to the journal
                    Entry entry = new Entry
                    {
                        Response = response,
                        Prompt = randomPrompt,
                        Date = DateTime.Now
                    };
                    journal.AddEntry(entry);
                    break;

                case "2":
                    // Display all entries in the journal
                    journal.DisplayEntries();
                    break;

                case "3":
                    // Load entries from a file
                    Console.Write("Enter the filename: ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadFromFile(loadFilename);
                    break;

                case "4":
                    // Save entries to a file
                    Console.Write("Enter the filename: ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveToFile(saveFilename);
                    break;

                case "5":
                    // Quit the program
                    quit = true;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}