using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
    private List<Entry> entries = new List<Entry>();

    public List<Entry> Entries
    {
        get { return entries; }
    }

    public void AddEntry(Entry entry)
    {
        entries.Add(entry);
    }

    public void DisplayEntries()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine(entry.ToString());
            }
        }
        Console.WriteLine("Journal saved to file: " + fileName);
    }

    public void LoadFromFile(string fileName)
    {
        entries.Clear();

        try
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    string[] parts = reader.ReadLine().Split('|');
                    if (parts.Length == 3)
                    {
                        string date = parts[0].Trim();
                        string prompt = parts[1].Trim();
                        string response = parts[2].Trim();
                        entries.Add(new Entry(date, prompt, response));
                    }
                }
            }
            Console.WriteLine("Journal loaded from file: " + fileName);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found: " + fileName);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error loading file: " + ex.Message);
        }
    }
}
