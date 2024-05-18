using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts;

    public ListingActivity() 
        : base("Listing Activity", 
               "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();
        string prompt = GetRandomPrompt();
        Console.WriteLine($"Prompt: {prompt}");

        DateTime startTime = DateTime.Now;
        int elapsed = 0;
        List<string> list = new List<string>();

        while (elapsed < _duration)
        {
            string item = GetListItem();
            if (string.IsNullOrEmpty(item))
            {
                Console.WriteLine("Time's up! Activity ended.");
                break;
            }
            list.Add(item);
            elapsed = (int)(DateTime.Now - startTime).TotalSeconds;
        }

    Console.WriteLine($"You listed {list.Count} items.");
    DisplayEndingMessage();
}

    private string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    private string GetListItem()
    {
        return Console.ReadLine()?.Trim();
    }
}
