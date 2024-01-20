using System;
using System.Collections.Generic;

public class Journal
{
    private List<Entry> entries;

    public Journal()
    {
        entries = new List<Entry>();
    }

    public void AddEntry(Entry entry)
    {
        entries.Add(entry);
    }

    public List<Entry> GetEntries()
    {
        return entries;
    }
    
    public void ClearEntries()
    {
        entries.Clear();
    }
    
    public void LoadFromCSV(string filePath)
    {
        // Code to load entries from CSV file
        // Implement logic to parse CSV file and create Entry objects
    }
    
    public void SaveToCSV(string filePath)
    {
        // Code to save entries to CSV file
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            // Write CSV header
            writer.WriteLine("Prompt,Response,Date");

            // Write each entry to CSV file
            foreach (Entry entry in entries)
            {
                // Escape quotation marks in response
                string response = entry.Response.Replace("\"", "\"\"");

                // Write entry as CSV row
                writer.WriteLine($"\"{entry.Prompt}\",\"{response}\",\"{entry.Date.ToString("yyyy-MM-dd HH:mm:ss")}\"");
            }
        }
    }
}
