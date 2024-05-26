public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    public string ShortName => _shortName;
    public int Points => _points;

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public virtual string GetDetailsString()
    {
        return $"Name: {_shortName}, Description: {_description}, Points: {_points}";
    }
    public abstract string GetStringRepresentation();
    public abstract string Serialize();
    public abstract void Deserialize(string[] data);
}
