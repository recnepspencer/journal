using System;
using System.Collections.Generic;


public class PromptGenerator
{
    public List<string> prompts;
    private Random random;

    public PromptGenerator()
    {
        // Initialize the Random object
        random = new Random();

        // Initialize the list of prompts
        prompts = new List<string>
            {
                "Who was the most interesting person I interacted with today?",
                "What was the best part of my day?",
                "How did I see opportunities for growth today?",
                "What was the strongest emotion I felt today?",
                "If I could change one decision I made today, what would it be?"
            };
    }

    public string GetRandomPrompt()
    {
        int index = random.Next(prompts.Count);
        return prompts[index];
    }

}
