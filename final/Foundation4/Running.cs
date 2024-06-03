public class Running : Activity
{
    private double DistanceKm { get; set; }

    public Running(DateTime date, int durationMinutes, double distanceKm)
        : base(date, durationMinutes)
    {
        DistanceKm = distanceKm;
    }

    public override double GetDistance()
    {
        return DistanceKm;
    }
}
