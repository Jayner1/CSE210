using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> _prompts;

    public PromptGenerator()
    {
        _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What was your favorite food you ate today?",
            "If you could meet one apostle, who would it be and why?",
            "How many times did you pray today?",
            "What made you happy today?",
            "What are you going to do differently tomorrow?"
        };
    }

    public string GetRandomPrompt()
    {
        if (_prompts.Count == 0)
        {
            return "No prompts available.";
        }

        Random random = new Random();

        int randomIndex = random.Next(_prompts.Count);

        return _prompts[randomIndex];
    }
}
