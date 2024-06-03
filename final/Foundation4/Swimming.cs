public class Swimming : Activity
{
    private int Laps { get; set; }

    public Swimming(DateTime date, int durationMinutes, int laps)
        : base(date, durationMinutes)
    {
        Laps = laps;
    }

    public override double GetDistance()
    {
        return (Laps * 50) / 1000.0;
    }
}
