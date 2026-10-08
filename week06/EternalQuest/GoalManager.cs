using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    private const string FileName = "goals.txt";

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine();
            Console.WriteLine($"Score: {_score}");
            Console.WriteLine($"Level: {GetLevel()}");
            Console.WriteLine();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Record Event");
            Console.WriteLine("  4. Display Score");
            Console.WriteLine("  5. Save Goals");
            Console.WriteLine("  6. Load Goals");
            Console.WriteLine("  7. Quit");

            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine() ?? "";

            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;

                case "2":
                    ListGoals();
                    break;

                case "3":
                    RecordEvent();
                    break;

                case "4":
                    DisplayScore();
                    break;

                case "5":
                    SaveGoals();
                    break;

                case "6":
                    LoadGoals();
                    break;

                case "7":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("The types of goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");

        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine() ?? "";

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine() ?? "";

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine() ?? "";

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine() ?? "0");

        if (type == "1")
        {
            SimpleGoal goal = new SimpleGoal(name, description, points);
            _goals.Add(goal);
        }
        else if (type == "2")
        {
            EternalGoal goal = new EternalGoal(name, description, points);
            _goals.Add(goal);
        }
        else if (type == "3")
        {
            Console.Write("How many times does this goal need to be completed? ");
            int target = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("What is the bonus for completing it? ");
            int bonus = int.Parse(Console.ReadLine() ?? "0");

            ChecklistGoal goal = new ChecklistGoal(
                name,
                description,
                points,
                target,
                bonus);

            _goals.Add(goal);
        }
        else
        {
            Console.WriteLine("Invalid goal type.");
            return;
        }

        Console.WriteLine("Goal created successfully!");
    }

    private void ListGoals()
    {
        Console.WriteLine("The goals are:");

        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    private void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("There are no goals to record.");
            return;
        }

        ListGoals();

        Console.Write("Which goal did you accomplish? ");
        int goalNumber = int.Parse(Console.ReadLine() ?? "0");

        if (goalNumber < 1 || goalNumber > _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        Goal selectedGoal = _goals[goalNumber - 1];

        int oldScore = _score;

        selectedGoal.RecordEvent(ref _score);

        if (_score > oldScore)
        {
            Console.WriteLine($"Congratulations! You have earned {_score - oldScore} points.");
        }
        else
        {
            Console.WriteLine("This goal has already been completed.");
        }
    }

    private void DisplayScore()
    {
        Console.WriteLine($"Your current score is: {_score}");
        Console.WriteLine($"Your current level is: {GetLevel()}");
    }

    private int GetLevel()
    {
        // Creativity feature: the player levels up every 1000 points.
        return (_score / 1000) + 1;
    }

    private void SaveGoals()
    {
        try
        {
            using (StreamWriter outputFile = new StreamWriter(FileName))
            {
                outputFile.WriteLine(_score);

                foreach (Goal goal in _goals)
                {
                    outputFile.WriteLine(goal.GetSaveString());
                }
            }

            Console.WriteLine($"Goals saved successfully to {Path.GetFullPath(FileName)}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving goals: {ex.Message}");
        }
    }

    private void LoadGoals()
    {
        if (!File.Exists(FileName))
        {
            Console.WriteLine($"The file '{FileName}' was not found.");
            Console.WriteLine("Save your goals first using option 5.");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(FileName);

            if (lines.Length == 0)
            {
                Console.WriteLine("The file is empty.");
                return;
            }

            _score = int.Parse(lines[0]);
            _goals.Clear();

            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                {
                    continue;
                }

                string[] parts = lines[i].Split(',');

                string goalType = parts[0];
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);

                if (goalType == "SimpleGoal")
                {
                    bool isComplete = bool.Parse(parts[4]);

                    SimpleGoal goal = new SimpleGoal(
                        name,
                        description,
                        points,
                        isComplete);

                    _goals.Add(goal);
                }
                else if (goalType == "EternalGoal")
                {
                    EternalGoal goal = new EternalGoal(
                        name,
                        description,
                        points);

                    _goals.Add(goal);
                }
                else if (goalType == "ChecklistGoal")
                {
                    int target = int.Parse(parts[4]);
                    int bonus = int.Parse(parts[5]);
                    int amountCompleted = int.Parse(parts[6]);

                    ChecklistGoal goal = new ChecklistGoal(
                        name,
                        description,
                        points,
                        target,
                        bonus,
                        amountCompleted);

                    _goals.Add(goal);
                }
            }

            Console.WriteLine("Goals loaded successfully.");
            Console.WriteLine($"Score loaded: {_score}");
            Console.WriteLine($"Level: {GetLevel()}");
            Console.WriteLine();
            ListGoals();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading goals: {ex.Message}");
        }
    }
}
