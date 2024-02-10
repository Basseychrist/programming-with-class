// Simple Goal class
public class SimpleGoal : Goal
{
    public override void Display()
    {
        string status = IsCompleted ? "[X]" : "[ ]";
        Console.WriteLine($"{status} {Name}, {Description}, {Points} points");
    }
}
