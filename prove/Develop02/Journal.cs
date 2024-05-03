using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();
    private const string JournalFile = "journal.txt";

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("The journal is empty.");
        }
        else
        {
            Console.WriteLine("Journal Entries:");
            foreach (var entry in _entries)
            {
                Console.WriteLine(entry);
                Console.WriteLine("-------------------------");
            }
        }
    }

    public void SaveToFile()
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(JournalFile))
            {
                foreach (var entry in _entries)
                {
                    writer.WriteLine(entry.Date.ToString("o"));
                    writer.WriteLine(entry.Prompt);
                    writer.WriteLine(entry.Content);
                    writer.WriteLine("---");
                }
            }
            Console.WriteLine("Journal saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving the journal: {ex.Message}");
        }
    }

    public void LoadFromFile()
    {
        try
        {
            if (File.Exists(JournalFile))
            {
                _entries.Clear();
                string[] lines = File.ReadAllLines(JournalFile);
                Entry currentEntry = null;

                foreach (string line in lines)
                {
                    if (line == "---")
                    {
                        if (currentEntry != null)
                        {
                            _entries.Add(currentEntry);
                            currentEntry = null;
                        }
                    }
                    else if (currentEntry == null)
                    {
                        DateTime date = DateTime.Parse(line);
                        currentEntry = new Entry(date, string.Empty);
                    }
                    else
                    {
                        currentEntry.Content += line + Environment.NewLine;
                    }
                }

                Console.WriteLine("Journal loaded successfully.");
            }
            else
            {
                Console.WriteLine("No journal file found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading the journal: {ex.Message}");
        }
    }
}
