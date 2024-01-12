using System;

class Program
{
    static void Main(string[] args)
    {
      Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101); // Generating a random number between 1 and 100

        int guess;

        do
        {
            Console.WriteLine("What is your guess?");
            guess = Convert.ToInt32(Console.ReadLine());

            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }

        } while (guess != magicNumber);

    }
}