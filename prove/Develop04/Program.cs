// Program.cs

using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");

            int choice = int.Parse(Console.ReadLine());

            Activity activity;

            switch (choice)
            {
                case 1:
                    activity = new BreathingActivity();
                    ((BreathingActivity)activity).PerformActivity();
                    break;
                case 2:
                    activity = new ReflectionActivity();
                    ((ReflectionActivity)activity).PerformActivity();
                    break;
                case 3:
                    activity = new ListingActivity();
                    ((ListingActivity)activity).PerformActivity();
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
            }
        }
    }
}
