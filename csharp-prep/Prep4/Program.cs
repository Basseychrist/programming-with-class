using System;

class Program
{
    static void Main(string[] args)
    {
    // Create a list to store numbers
        List<int> numbers = new List<int>();

        // Ask the user for a series of numbers until they enter 0
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int userInput;
        do
        {
            Console.Write("Enter number: ");
            userInput = int.Parse(Console.ReadLine());

            // Add the entered number to the list
            numbers.Add(userInput);

        } while (userInput != 0);

        // Remove the last 0 from the list
        numbers.Remove(0);

        // Check if there are numbers in the list
        if (numbers.Count > 0)
        {
            // Compute the sum of the numbers
            int sum = numbers.Sum();

            // Compute the average of the numbers
            double average = numbers.Average();

            // Find the maximum number in the list
            int maxNumber = numbers.Max();

            // Display the results
            Console.WriteLine($"The sum is: {sum}");
            Console.WriteLine($"The average is: {average}");
            Console.WriteLine($"The largest number is: {maxNumber}");
        }
        else
        {
            Console.WriteLine("No numbers entered. Exiting program.");
        }
    }
}