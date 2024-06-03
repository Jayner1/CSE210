using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2024, 6, 3), 30, 4.8),
            new Cycling(new DateTime(2024, 6, 3), 30, 20),
            new Swimming(new DateTime(2024, 6, 3), 30, 30)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
            Console.WriteLine();
        }
    }
}
