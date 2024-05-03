using System;

public class Entry
{
    public DateTime Date { get; set; }
    public string Prompt { get; set; }
    public string Content { get; set; }
    public string Empty { get; }

    public Entry(DateTime date, string prompt, string content)
    {
        Date = date;
        Prompt = prompt;
        Content = content;
    }

    public Entry(DateTime date, string empty)
    {
        Date = date;
        Empty = empty;
    }

    public override string ToString()
    {
        return $"{Date:G}\nPrompt: {Prompt}\n{Content}";
    }
}