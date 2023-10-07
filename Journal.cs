using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Globalization;

public class Journal
{
    public List<Entry> Entries { get; set; }
    private const string FileName = "JournalFile.csv";  // Fixed filename

    public Journal()
    {
        Entries = new List<Entry>();
    }

    public void AddEntry(DateTime date, string prompt)
    {

        // Display the date and prompt to the user
        Console.WriteLine($"Date: {date} ");
        Console.WriteLine($"Prompt: {prompt}");

        // Get the user's response

        Console.WriteLine("Your Response:");
        string? response = Console.ReadLine();

        if (string.IsNullOrEmpty(response))
        {
            Console.WriteLine("Response cannot be null or empty.");
            return;
        }

        // Create a new Entry object and add it to the journal
        Entry newEntry = new Entry(date, prompt, response);
        Entries.Add(newEntry);

        Console.WriteLine("Entry saved successfully!");
    }

    public void DisplayAllEntries()
    {
        if (Entries.Count == 0)
        {
            Console.WriteLine("No entries to display.");
            return;
        }
        foreach (Entry entry in Entries)
        {
            Console.WriteLine(entry.DisplayEntry());
        }
    }

    public void SaveEntriesToCsv()
    {
        // Check if there are any entries to save
        if (Entries.Count == 0)
        {
            Console.WriteLine("No entries to save.");
            return;
        }

        // Create a StringBuilder object to store the CSV data
        StringBuilder sb = new StringBuilder();

        // Write header
        sb.AppendLine("Date,Prompt,Response");

        // Write data
        foreach (Entry entry in Entries)
        {
            string date = entry.Date.ToString("yyyy-MM-dd HH:mm:ss");
            string prompt = EscapeField(entry.Prompt);
            string response = EscapeField(entry.Response);

            sb.AppendLine($"{date},{prompt},{response}");
        }

        File.WriteAllText("JournalFile.csv", sb.ToString());
    }

    // Utility method for escaping special characters in CSV fields
    private string EscapeField(string field)
    {
        return field.Replace(",", "&#44;").Replace("\"", "&#34;");
    }

    public void LoadEntriesFromFile()
    {
        // Check if the file exists
        if (!File.Exists(FileName))
        {
            Console.WriteLine("Please create a journal first.");
            return;
        }
        
        // Read the file line by line
        using (StreamReader sr = new StreamReader(FileName))
        {
            string? line;
            bool isFirstLine = true;

            // Read the first line and ignore it
            while ((line = sr.ReadLine()) != null)
            {
                if (isFirstLine)
                {
                    isFirstLine = false;
                    continue;
                }

                // Split the line using the standard comma delimiter
                string[] fields = line.Split(',');

                // Convert and unescape the fields
                DateTime date = DateTime.ParseExact(fields[0], "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                string prompt = UnescapeField(fields[1]);
                string response = UnescapeField(fields[2]);

                // Create an Entry object and add it to Entries list
                Entry entry = new Entry(date, prompt, response);
                Entries.Add(entry);
            }
        }
    }


    private string UnescapeField(string field)
    {
        return field.Replace("&#44;", ",").Replace("&#34;", "\"");
    }
}
