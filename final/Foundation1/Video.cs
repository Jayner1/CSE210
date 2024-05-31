class Video
{
    private string _title;
    private string _author;
    private int _length;
    private List<Comment> _comments;

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }

    public override string ToString()
    {
        int lengthMinutes = _length / 60;
        int lengthSeconds = _length % 60;
        string commentsStr = string.Join("\n", _comments);
        return $"Title: {_title}, Author: {_author}, Length: {lengthMinutes}m {lengthSeconds}s, Comments: {GetCommentCount()}\n{commentsStr}";
    }
}