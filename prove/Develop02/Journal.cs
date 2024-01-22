using System;
using System.Collections.Generic;

public class Journal
{
    private List<Entry> entries;

    public Journal()
    {
        entries = new List<Entry>();
    }

    public void AddEntry(string prompt, string response)
    {
        Entry entry = new Entry
        {
            Prompt = prompt,
            Response = response,
            Date = DateTime.Now
        };
        entries.Add(entry);
    }

    public List<Entry> GetAllEntries()
    {
        return entries;
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in entries)
            {
                // Enclose response in double quotes to handle commas and quotation marks correctly
                string response = "\"" + entry.Response.Replace("\"", "\"\"") + "\"";
                string csvLine = $"{entry.Prompt},{response},{entry.Date.ToString()}";
                writer.WriteLine(csvLine);
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        entries.Clear();

        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] values = line.Split(',');
                if (values.Length == 3)
                {
                    string prompt = values[0];
                    string response = values[1].Trim('"');
                    DateTime date = DateTime.Parse(values[2]);

                    Entry entry = new Entry
                    {
                        Prompt = prompt,
                        Response = response,
                        Date = date
                    };
                    entries.Add(entry);
                }
            }
        }
    }
}
