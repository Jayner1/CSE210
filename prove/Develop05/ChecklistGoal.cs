public class ChecklistGoal : Goal
{
    private int _currentCount;
    private int _targetCount;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonus)
        : base(name, description, points)
    {
        _currentCount = 0;
        _targetCount = targetCount;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        if (_currentCount < _targetCount)
        {
            _currentCount++;
        }
    }

    public override bool IsComplete()
    {
        return _currentCount >= _targetCount;
    }

    public override string GetStringRepresentation()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} Checklist Goal: {_shortName} - {_description} - Points: {_points} - Completed {_currentCount}/{_targetCount} times";
    }

    public int GetBonus()
    {
        if (IsComplete())
        {
            return _bonus;
        }
        return 0;
    }

    public override string Serialize()
    {
        return $"ChecklistGoal|{_shortName}|{_description}|{_points}|{_currentCount}|{_targetCount}|{_bonus}";
    }

    public override void Deserialize(string[] data)
    {
        _currentCount = int.Parse(data[4]);
        _targetCount = int.Parse(data[5]);
        _bonus = int.Parse(data[6]);
    }
}
