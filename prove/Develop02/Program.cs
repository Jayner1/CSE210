class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        int option = 0;

        while (option != 5)
        {
            option = ShowMenu();
            HandleOption(option, journal, promptGenerator);
        }

        Console.WriteLine("Quitting the program...");
    }

    static int ShowMenu()
    {
        Console.WriteLine("\nWelcome to the Journal Program!");
        Console.WriteLine("\nJournal Menu:");
        Console.WriteLine("1. Write a new entry");
        Console.WriteLine("2. Display all entries");
        Console.WriteLine("3. Load entries from a file");
        Console.WriteLine("4. Save entries to a file");
        Console.WriteLine("5. Quit");
        Console.Write("Choose an option: ");

        int option;
        while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > 5)
        {
            Console.Write("Invalid option. Please try again: ");
        }

        return option;
    }

    static void HandleOption(int option, Journal journal, PromptGenerator promptGenerator)
    {
        switch (option)
        {
            case 1:
                AddNewEntry(journal, promptGenerator);
                break;
            case 2:
                journal.DisplayEntries();
                break;
            case 3:
                journal.LoadFromFile();
                break;
            case 4:
                journal.SaveToFile();
                break;
            case 5:
                // Quit
                break;
            default:
                Console.WriteLine("Invalid option.");
                break;
        }
    }

    static void AddNewEntry(Journal journal, PromptGenerator promptGenerator)
    {
        DateTime date = DateTime.Now;

        string prompt = promptGenerator.GetRandomPrompt();
        Console.WriteLine($"Prompt: {prompt}");

        Console.WriteLine("Please enter your journal entry:");
        string content = Console.ReadLine();

        Entry newEntry = new Entry(date, prompt, content);
        journal.AddEntry(newEntry);
    }
}