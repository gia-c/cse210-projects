using System;
using System.Collections.Generic;
// Enhancement: The program keeps a session log showing how many
// times each mindfulness activity has been completed.
class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, int> activityCounts = new Dictionary<string, int>
        {
            { "Breathing Activity", 0 },
            { "Reflection Activity", 0 },
            { "Listing Activity", 0 }
        };

        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. View my progress");
            Console.WriteLine("  5. Quit");
            Console.WriteLine();
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                    activityCounts["Breathing Activity"]++;
                    PauseBeforeMenu();
                    break;

                case "2":
                    ReflectionActivity reflection = new ReflectionActivity();
                    reflection.Run();
                    activityCounts["Reflection Activity"]++;
                    PauseBeforeMenu();
                    break;

                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    activityCounts["Listing Activity"]++;
                    PauseBeforeMenu();
                    break;

                case "4":
                    DisplayStatistics(activityCounts);
                    PauseBeforeMenu();
                    break;

                case "5":
                    running = false;
                    Console.WriteLine();
                    Console.WriteLine("Thank you for using the Mindfulness Program.");
                    break;

                default:
                    Console.WriteLine();
                    Console.WriteLine("Invalid choice. Please select 1-5.");
                    PauseBeforeMenu();
                    break;
            }
        }
    }

    static void DisplayStatistics(Dictionary<string, int> activityCounts)
    {
        Console.Clear();
        Console.WriteLine("Showing your progress: ");
        Console.WriteLine();

        foreach (var activity in activityCounts)
        {
            Console.WriteLine($"{activity.Key}: {activity.Value} time(s)");
        }

        Console.WriteLine();
    }

    static void PauseBeforeMenu()
    {
        Console.WriteLine();
        Console.WriteLine("Press Enter to return to the menu.");
        Console.ReadLine();
    }
}