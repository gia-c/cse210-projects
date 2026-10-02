using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        SetName("Breathing Activity");
        SetDescription(
            "This activity will help you relax by walking you through breathing " +
            "in and out slowly. Clear your mind and focus on your breathing."
        );
    }

    public void Run()
    {
        DisplayStartingMessage();

        int elapsed = 0;
        bool breatheIn = true;

        while (elapsed < GetDuration())
        {
            int breathTime = Math.Min(4, GetDuration() - elapsed);

            if (breatheIn)
            {
                Console.Write("Breathe in...");
            }
            else
            {
                Console.Write("Breathe out...");
            }

            ShowCountDown(breathTime);
            Console.WriteLine();

            elapsed += breathTime;
            breatheIn = !breatheIn;
        }

        DisplayEndingMessage();
    }
}