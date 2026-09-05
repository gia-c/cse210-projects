using System;

class Program
{
    static void Main(string[] args)
    {
       Random randomGenerator = new Random();

        string playAgain = "yes";

        while (playAgain == "yes")
        {
            // Generate a random magic number from 1 to 100
            int magicNumber = randomGenerator.Next(1, 101);

            // Get the first guess
            Console.Write("What is your guess? ");
            string guessAnswer = Console.ReadLine();
            int guess = int.Parse(guessAnswer);

            // Keep track of the number of guesses
            int guessCount = 1;

            // Keep asking until the user guesses correctly
            while (guess != magicNumber)
            {
                if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("Higher");
                }

                Console.Write("What is your guess? ");
                guessAnswer = Console.ReadLine();
                guess = int.Parse(guessAnswer);

                guessCount++;
            }

            // The user guessed correctly
            Console.WriteLine("You guessed it!");
            Console.WriteLine($"You guessed it in {guessCount} guesses!");

            // Ask if the user wants to play again
            Console.Write("Do you want to play again? ");
            playAgain = Console.ReadLine().ToLower();
        }

        Console.WriteLine("Thanks for playing!");

    }
}