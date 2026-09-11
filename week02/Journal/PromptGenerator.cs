public class PromptGenerator
{
    private List<string> _prompts = new List<string> // _prompts stores our list of prompts
    {   // This exceeds the minimum requirement of 5 prompts.
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What is something new I learned today?",
        "What is one thing I am grateful for today?"
    };

    public string GetRandomPrompt() // chooses and returns one random prompt
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}
