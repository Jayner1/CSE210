public class EternalGoal : Goal
{
    private int _completions;

    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _completions = 0;
    }

    public override void RecordEvent()
    {
        _completions++;
    }

    public override bool IsComplete()
    {
        return false;  // Eternal goals are never fully complete
    }

    public override string GetStringRepresentation()
    {
        return $"[ ] Eternal Goal: {_shortName} - {_description} - Points: {_points} - Completions: {_completions}";
    }

    public override string Serialize()
    {
        return $"EternalGoal|{_shortName}|{_description}|{_points}|{_completions}";
    }

    public override void Deserialize(string[] data)
    {
        _completions = int.Parse(data[4]);
    }
}
