class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("John", 14, 27); 
        string text = "Peace I leave with you, my peace I give unto you: not as the world giveth, give I unto you. Let not your heart be troubled, neither let it be afraid.";
        Scripture scripture = new Scripture(reference, text);

        int wordsCount = scripture.GetDisplayText().Split(' ').Length;
        while (true)
        {
            scripture.DisplayScripture();
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
            {
                return;
            }
            else
            {
                if (wordsCount >= 3)
                {
                    scripture.HideRandomWords(3);
                    wordsCount -= 3;
                }
                else
                {
                    scripture.HideRandomWords(wordsCount);
                    break;
                }
            }
        }

        Console.WriteLine("All words are hidden. Press any key to exit...");
        Console.ReadKey();
    }
}