using System;

class Program
{
    static void Main(string[] args)
    {
        // Read the scripture library
        string[] lines = File.ReadAllLines("scriptures.txt");

        Random random = new Random();

        bool quit = false;
        List<int> usedScriptures = new List<int>();

        while (!quit)
        {
            // Choose a random scripture that has not been used
            int index;

            do
            {
                index = random.Next(lines.Length);
            }
            while (usedScriptures.Contains(index));

            usedScriptures.Add(index);

            // Separate the scripture information
            string[] parts = lines[index].Split('|');

            string book = parts[0];
            int chapter = int.Parse(parts[1]);
            int startVerse = int.Parse(parts[2]);
            int endVerse = int.Parse(parts[3]);
            string text = parts[4];

            // Create the scripture
            Reference reference = new Reference(
                book,
                chapter,
                startVerse,
                endVerse);

            Scripture scripture = new Scripture(reference, text);

            // Practice the scripture
            while (!scripture.IsCompletelyHidden())
            {
                Console.Clear();

                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine();
                Console.Write("Press Enter to hide words or type 'quit' to exit: ");

                string input = Console.ReadLine();

                if (input.ToLower() == "quit")
                {
                    quit = true;
                    break;
                }

                scripture.HideRandomWords(3);
            }

            if (quit)
            {
                break;
            }

            // Scripture is completely hidden
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            // Check if all scriptures have been used
            if (usedScriptures.Count == lines.Length)
            {
                Console.WriteLine("You have completed all the scriptures!");
                Console.WriteLine();
                Console.Write("Would you like to restart the scripture library? (yes/no): ");

                string restart = Console.ReadLine();

                if (restart.ToLower() == "yes")
                {
                    usedScriptures.Clear();
                }
                else
                {
                    quit = true;
                }
            }
            else
            {
                // Ask what to do after completing a scripture
                Console.WriteLine("1. Continue with another scripture");
                Console.WriteLine("2. Quit");
                Console.Write("Choose an option: ");

                string option = Console.ReadLine();

                while (option != "1" && option != "2")
                {
                    Console.Write("Please enter 1 to continue or 2 to quit: ");
                    option = Console.ReadLine();
                }

                if (option == "2")
                {
                    quit = true;
                }
            }
        }
    }
}