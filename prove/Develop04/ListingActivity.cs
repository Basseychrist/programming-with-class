// ListingActivity.cs

using System;
using System.Threading;

// ListingActivity class
class ListingActivity : Activity
{
    private string[] listingPrompts = { "Who are people that you appreciate?",
                                        "What are personal strengths of yours?",
                                        "Who are people that you have helped this week?",
                                        "When have you felt the Holy Ghost this month?",
                                        "Who are some of your personal heroes?" };

    public ListingActivity() : base("Listing", "Helps you reflect on the good things in your life by listing items in a certain area.")
    {
    }

    public void PerformActivity()
    {
        StartActivity();

        Random random = new Random();
        string prompt = listingPrompts[random.Next(listingPrompts.Length)];
        Console.WriteLine(prompt);
        Pause(3);

        Console.WriteLine("Start listing...");

        // Simulating user listing items
        int itemsCount = 0;
        while (duration > 0)
        {
            // Simulating user entering an item
            // (In a real program, you would read user input or perform some action)
            itemsCount++;
            duration--;

            // Pause for the user to think about the next item
            Pause(3);
        }

        Console.WriteLine($"You listed {itemsCount} items.");

        EndActivity();
    }
}
