using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


// Main program
class Program
{
    static List<Goal> goals = new List<Goal>();

    static void Main(string[] args)
    {
        int choice;
        do
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create new goal");
            Console.WriteLine("2. List goals");
            Console.WriteLine("3. Save goals");
            Console.WriteLine("4. Load goals");
            Console.WriteLine("5. Record event");
            Console.WriteLine("6. Quit");
            Console.Write("Enter your choice: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    CreateGoal();
                    break;
                case 2:
                    ListGoals();
                    break;
                case 3:
                    SaveGoals();
                    break;
                case 4:
                    LoadGoals();
                    break;
                case 5:
                    RecordEvent();
                    break;
                case 6:
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

        } while (choice != 6);
    }

    static void CreateGoal()
    {
        Console.WriteLine("Select the type of goal:");
        Console.WriteLine("1. Simple goal");
        Console.WriteLine("2. Eternal goal");
        Console.WriteLine("3. Checklist goal");
        int type = int.Parse(Console.ReadLine());

        Console.Write("Enter the name of the goal: ");
        string name = Console.ReadLine();
        Console.Write("Enter a short description: ");
        string description = Console.ReadLine();
        Console.Write("Enter the number of points: ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case 1:
                goals.Add(new SimpleGoal { Name = name, Description = description, Points = points });
                break;
            case 2:
                goals.Add(new EternalGoal { Name = name, Description = description, Points = points });
                break;
            case 3:
                Console.Write("Enter the number of times for bonus: ");
                int requiredCount = int.Parse(Console.ReadLine());
                Console.Write("Enter the bonus points: ");
                int bonusPoints = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal { Name = name, Description = description, Points = points, RequiredCount = requiredCount, BonusPoints = bonusPoints });
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }

        Console.WriteLine("Goal created successfully.");
    }

    static void ListGoals()
    {
        Console.WriteLine("List of goals:");
        foreach (var goal in goals)
        {
            goal.Display();
        }
    }

    static void SaveGoals()
    {
        Console.Write("Enter file name to save goals: ");
        string fileName = Console.ReadLine();
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (var goal in goals)
            {
                writer.WriteLine($"{goal.GetType().Name},{goal.Name},{goal.Description},{goal.Points},{goal.IsCompleted}");
                if (goal.GetType() == typeof(ChecklistGoal))
                {
                    writer.WriteLine($"{((ChecklistGoal)goal).RequiredCount},{((ChecklistGoal)goal).BonusPoints},{((ChecklistGoal)goal).CompletedCount}");
                }
            }
        }
        Console.WriteLine("Goals saved successfully.");
    }

    static void LoadGoals()
    {
        Console.Write("Enter file name to load goals: ");
        string fileName = Console.ReadLine();
        if (File.Exists(fileName))
        {
            goals.Clear();
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts[0] == "SimpleGoal")
                    {
                        goals.Add(new SimpleGoal { Name = parts[1], Description = parts[2], Points = int.Parse(parts[3]), IsCompleted = bool.Parse(parts[4]) });
                    }
                    else if (parts[0] == "EternalGoal")
                    {
                        goals.Add(new EternalGoal { Name = parts[1], Description = parts[2], Points = int.Parse(parts[3]), IsCompleted = bool.Parse(parts[4]) });
                    }
                    else if (parts[0] == "ChecklistGoal")
                    {
                        goals.Add(new ChecklistGoal { Name = parts[1], Description = parts[2], Points = int.Parse(parts[3]), IsCompleted = bool.Parse(parts[4]), RequiredCount = int.Parse(parts[5]), BonusPoints = int.Parse(parts[6]), CompletedCount = int.Parse(parts[7]) });
                    }
                }
            }
            Console.WriteLine("Goals loaded successfully.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }

        static void RecordEvent()
    {
        Console.WriteLine("Select the goal you accomplished:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].Name}");
        }
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < goals.Count)
        {
            goals[index].IsCompleted = true;

            if (goals[index] is ChecklistGoal checklistGoal)
            {
                checklistGoal.CompletedCount++;
                if (checklistGoal.CompletedCount >= checklistGoal.RequiredCount)
                {
                    Console.WriteLine($"Congratulations! You achieved the bonus for {checklistGoal.Name}.");
                    checklistGoal.IsCompleted = true;
                }
            }

            Console.WriteLine("Enter the points earned for completing this goal:");
            int pointsEarned = int.Parse(Console.ReadLine());
            goals[index].Points += pointsEarned;

            Console.WriteLine("Event recorded successfully.");

            DisplayTotalPoints();
        }
        else
        {
            Console.WriteLine("Invalid goal selection.");
        }
    }

    static void DisplayTotalPoints()
    {
        int totalPoints = goals.Where(g => g.IsCompleted).Sum(g => g.Points);
        Console.WriteLine($"Total points earned: {totalPoints}");
    }

}