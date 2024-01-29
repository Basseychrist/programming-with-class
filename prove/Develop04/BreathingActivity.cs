// BreathingActivity.cs

using System;
using System.Threading;

class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "Welcome to the breathing activity. This activity will help you relax by walking you through breathing in and out slowly.")
    {
    }

    public void PerformActivity()
    {
        StartActivity();

        for (int i = 0; i < duration; i++)
        {
            Console.Write("Bre");
            GrowTextAnimation(5); // Simulate quick text growth
            Console.Write("athe");
            GrowTextAnimation(10); // Simulate slower text growth
            Console.WriteLine("in...");
            GrowTextAnimation(10); // Simulate slower text growth
            Console.Write("Br");
            GrowTextAnimation(5); // Simulate quick text growt
            Console.Write("athe");
            GrowTextAnimation(10); // Simulate quick text growth
            Console.WriteLine("out....");
            GrowTextAnimation(5); // Simulate slower text growth
        }

        EndActivity();
    }

    private void GrowTextAnimation(int growthRate)
    {
        int textLength = 0;
        for (int i = 0; i < 10; i++) // Simulating 10 steps of growth
        {
            textLength += growthRate;
            Console.Write(new string(' ', textLength) + "\r");
            Thread.Sleep(100); // Adjust sleep time for the desired animation speed
        }
        Console.WriteLine();
    }
}
