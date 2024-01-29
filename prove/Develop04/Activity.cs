// Activity.cs

using System;
using System.Threading;

// Base class for all activities
class Activity
{
    private string name;
    private string description;
    protected int duration;

    public Activity(string name, string description)
    {
        this.name = name;
        this.description = description;
    }

    public void StartActivity()
    {
        Console.WriteLine($"Starting {name} activity...");
        Console.WriteLine(description);
        SetDuration();
        Console.WriteLine("Prepare to begin...");
        Pause(3);
    }

    public void EndActivity()
    {
        Console.WriteLine($"Good job! You have completed the {name} activity for {duration} seconds.");
        Pause(3);
    }

    private void SetDuration()
    {
        Console.Write("How long will you want for your session? Enter the duration in seconds: ");
        duration = int.Parse(Console.ReadLine());
    }

    protected void Pause(int seconds)
    {
        Console.Write(".");
        Thread.Sleep(seconds * 1000); // Sleep for the specified duration
        Console.WriteLine();
    }
}
