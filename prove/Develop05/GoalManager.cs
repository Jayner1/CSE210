using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        while (true)
        {
            Console.WriteLine("\n1. Display Player Info\n2. List Goal Names\n3. Create Goal\n4. Record Event\n5. Save Goals\n6. Load Goals\n7. Exit");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    DisplayPlayerInfo();
                    break;
                case "2":
                    ListGoalNames();
                    break;
                case "3":
                    CreateGoal();
                    break;
                case "4":
                    RecordEvent();
                    break;
                case "5":
                    SaveGoals();
                    break;
                case "6":
                    LoadGoals();
                    break;
                case "7":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        ListGoalNames();
        Console.WriteLine($"Current Score: {_score}");
    }

    public void ListGoalNames()
    {
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetStringRepresentation());
        }
    }

    public void CreateGoal()
    {
        Console.Write("Enter goal type (simple/eternal/checklist): ");
        string goalType = Console.ReadLine().ToLower();
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter description: ");
        string description = Console.ReadLine();
        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine());

        if (goalType == "simple")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (goalType == "eternal")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (goalType == "checklist")
        {
            Console.Write("Enter target count: ");
            int targetCount = int.Parse(Console.ReadLine());
            Console.Write("Enter bonus points: ");
            int bonus = int.Parse(Console.ReadLine());
            _goals.Add(new ChecklistGoal(name, description, points, targetCount, bonus));
        }
    }

    public void RecordEvent()
    {
        ListGoalNames();
        Console.Write("Enter the goal name to record an event: ");
        string goalName = Console.ReadLine();
        var goal = _goals.Find(g => g.ShortName == goalName);
        if (goal != null)
        {
            goal.RecordEvent();
            if (goal is ChecklistGoal checklistGoal && checklistGoal.IsComplete())
            {
                _score += checklistGoal.GetBonus();
            }
            _score += goal.Points;
        }
        else
        {
            Console.WriteLine("Goal not found.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("Enter the filename to save goals: ");
        string filename = Console.ReadLine();
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.Serialize());
            }
        }
    }

    public void LoadGoals()
    {
        Console.Write("Enter the filename to load goals: ");
        string filename = Console.ReadLine();
        if (File.Exists(filename))
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                _score = int.Parse(reader.ReadLine());
                _goals.Clear();
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] data = line.Split('|');
                    Goal goal = null;
                    switch (data[0])
                    {
                        case "SimpleGoal":
                            goal = new SimpleGoal(data[1], data[2], int.Parse(data[3]));
                            break;
                        case "EternalGoal":
                            goal = new EternalGoal(data[1], data[2], int.Parse(data[3]));
                            break;
                        case "ChecklistGoal":
                            goal = new ChecklistGoal(data[1], data[2], int.Parse(data[3]), int.Parse(data[5]), int.Parse(data[6]));
                            break;
                    }
                    if (goal != null)
                    {
                        goal.Deserialize(data);
                        _goals.Add(goal);
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
