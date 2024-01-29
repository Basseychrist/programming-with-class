// ReflectionActivity.cs

using System;
using System.Threading;

// ReflectionActivity class
class ReflectionActivity : Activity
{
    private string[] prompts = { "Think of a time when you stood up for someone else.",
                                 "Think of a time when you did something really difficult.",
                                 "Think of a time when you helped someone in need.",
                                 "Think of a time when you did something truly selfless." };

    private string[] reflectionQuestions = { "Why was this experience meaningful to you?",
                                             "Have you ever done anything like this before?",
                                             "How did you get started?",
                                             // ... more questions
                                           };

    public ReflectionActivity() : base("Reflection", "Helps you reflect on times when you have shown strength and resilience.")
    {
    }

    public void PerformActivity()
    {
        StartActivity();

        Random random = new Random();

        for (int i = 0; i < duration; i++)
        {
            string prompt = prompts[random.Next(prompts.Length)];
            Console.WriteLine(prompt);
            Pause(3);

            foreach (string question in reflectionQuestions)
            {
                Console.WriteLine(question);
                Pause(3);
            }
        }

        EndActivity();
    }
}
