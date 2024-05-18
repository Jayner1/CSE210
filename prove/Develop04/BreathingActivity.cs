public class BreathingActivity : Activity
{
    public BreathingActivity() 
        : base("Breathing Activity", 
               "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.") { }

    public void Run()
    {
        DisplayStartingMessage();

        int elapsed = 0;
        while (elapsed < _duration)
        {
            Console.WriteLine("Breathe in...");
            ShowCountDown(3);
            elapsed += 3;

            if (elapsed >= _duration) break;

            Console.WriteLine("Breathe out...");
            ShowCountDown(3);
            elapsed += 3;
        }

        DisplayEndingMessage();
    }
}
