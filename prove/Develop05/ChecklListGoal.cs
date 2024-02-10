// Checklist Goal class
public class ChecklistGoal : Goal
{
    public int RequiredCount { get; set; }
    public int BonusPoints { get; set; }
    public int CompletedCount { get; set; }

    public override void Display()
    {
        string status = IsCompleted ? "[X]" : "[ ]";
        Console.WriteLine($"{status} {Name}, {Description}, {Points} points. Completed {CompletedCount}/{RequiredCount} times");
    }
}
