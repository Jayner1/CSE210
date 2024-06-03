using System;

public abstract class Activity
{
    public DateTime Date { get; private set; }
    public int DurationMinutes { get; private set; }

    protected Activity(DateTime date, int durationMinutes)
    {
        Date = date;
        DurationMinutes = durationMinutes;
    }

    public abstract double GetDistance();
    public double GetSpeed()
    {
        return (GetDistance() / DurationMinutes) * 60;
    }

    public double GetPace()
    {
        return DurationMinutes / GetDistance();
    }

    public virtual string GetSummary()
    {
        return $"{Date.ToString("dd MMM yyyy")} {GetType().Name} ({DurationMinutes} min) - " +
               $"Distance: {GetDistance():0.0} km, Speed: {GetSpeed():0.0} kph, Pace: {GetPace():0.0} min per km";
    }
}
