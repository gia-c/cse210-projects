using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;
    private Random _random;

    public ListingActivity()
    {
        SetName("Listing Activity");

        SetDescription(
            "This activity will help you reflect on the good things in your life " +
            "by having you list as many things as you can in a certain area."
        );

        _count = 0;

        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        _random = new Random();
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.WriteLine();

        Console.WriteLine("You may begin in:");
        ShowCountDown(5);
        Console.WriteLine();
        Console.WriteLine();

        _count = 0;

        DateTime startTime = DateTime.Now;

        while ((DateTime.Now - startTime).TotalSeconds < GetDuration())
        {
            Console.Write("> ");
            string answer = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(answer))
            {
                _count++;
            }
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {_count} items!");

        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }
}