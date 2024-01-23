using System;

class Program
{
    static void Main()
    {
        Journal journal = new Journal();
        UserInterface ui = new UserInterface(journal);

        int choice;
        do
        {
            ui.DisplayMenu();
            choice = ui.GetMenuChoice();

            switch (choice)
            {
                case 1:
                    ui.WriteNewEntry();
                    break;
                case 2:
                    ui.DisplayJournal();
                    break;
                case 3:
                    ui.LoadJournalFromFile();
                    break;
                case 4:
                    ui.SaveJournalToFile();
                    break;
                case 5:
                    Console.WriteLine("Exiting the program.");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please choose a valid option.");
                    break;
            }
        } while (choice != 5);
    }
}
