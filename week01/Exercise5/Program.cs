using System;

class Program
{
    static void Main(string[] args)
    {
        // Display the welcome message
        DisplayWelcome();

        // Ask for the user's name
        string name = PromptUserName();

        // Ask for the user's favorite number
        int number = PromptUserNumber();

        // Square the user's number
        int squaredNumber = SquareNumber(number);

        // Display the final result
        DisplayResult(name, squaredNumber);
    }

    // Displays the welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    // Asks for and returns the user's name
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    // Asks for and returns the user's favorite number
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        return int.Parse(Console.ReadLine());
    }

    // Returns the square of a number
    static int SquareNumber(int number)
    {
        return number * number;
    }

    // Displays the user's name and squared number
    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
    }
}