public class SimpleGoal : Goal
{
    private bool _completed;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _completed = false;
    }

    public override void RecordEvent()
    {
        if (!_completed)
        {
            _completed = true;
        }
    }

    public override bool IsComplete()
    {
        return _completed;
    }

    public override string GetStringRepresentation()
    {
        string status = _completed ? "[X]" : "[ ]";
        return $"{status} Simple Goal: {_shortName} - {_description} - Points: {_points}";
    }

    public override string Serialize()
    {
        return $"SimpleGoal|{_shortName}|{_description}|{_points}|{_completed}";
    }

    public override void Deserialize(string[] data)
    {
        _completed = bool.Parse(data[4]);
    }
}
