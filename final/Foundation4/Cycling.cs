public class Cycling : Activity
{
    private double SpeedKph { get; set; }

    public Cycling(DateTime date, int durationMinutes, double speedKph)
        : base(date, durationMinutes)
    {
        SpeedKph = speedKph;
    }

    public override double GetDistance()
    {
        return (SpeedKph * DurationMinutes) / 60;
    }

    public override string GetSummary()
    {
        double distanceKm = GetDistance();
        double pace = 60 / SpeedKph;
        return $"{Date.ToString("dd MMM yyyy")} Cycling ({DurationMinutes} min) - " +
               $"Distance: {distanceKm:0.0} km, Speed: {SpeedKph:0.0} kph, Pace: {pace:0.0} min per km";
    }
}
