public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        string[] words = text.Split(' ');
        foreach (string word in words)
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int count)
    {
        Random rnd = new Random();
        int hiddenCount = 0;
        while (hiddenCount < count)
        {
            int index = rnd.Next(_words.Count);
            if (!_words[index].IsHidden())
            {
                _words[index].Hide();
                hiddenCount++;
            }
        }
    }

    public string GetDisplayText()
    {
        string displayText = "";
        foreach (Word word in _words)
        {
            displayText += word.GetDisplayText() + " ";
        }
        return displayText.Trim();
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }

    public void DisplayScripture()
    {
        Console.WriteLine(GetDisplayText());
        Console.WriteLine($"Reference: {_reference.GetDisplayText()}");
        Console.WriteLine("\nPress Enter to continue or type 'quit' to finish:");
    }
}