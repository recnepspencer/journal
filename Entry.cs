using System;
using System.Collections.Generic;

public class Entry
{
    // Properties
    public DateTime Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }

    // Constructor
    public Entry(DateTime date, string prompt, string response)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
    }

    // Methods 
    public string SaveEntry(List<Entry> entries)
    {
        // Save the entry to the provided List<Entry>
        entries.Add(this);
        return "Entry saved successfully!";
    }

    public string DisplayEntry()
    {
        return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}";
    }
}
