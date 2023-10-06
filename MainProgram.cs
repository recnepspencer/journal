using System;
using System.Collections.Generic;

public class MainProgram
{
    
    static void Main()
    {
        // Initialize a variable to hold the user's choice
        int userChoice = 0;
        bool isInvalidChoice = true;

        // Initialize a new Journal object
        Journal journal = new Journal();

        // Initialize a new PromptGenerator object
        PromptGenerator promptGenerator = new PromptGenerator();

        // Welcome user to the program
        Console.WriteLine("Welcome to the Journal App!");

        while (true) // Keep the program running
        {
            isInvalidChoice = true;  // Reset the flag for the new iteration

            while (isInvalidChoice)
            {
                // Ask the user to select an option
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Create a new journal entry");
                Console.WriteLine("2. Display entries");
                Console.WriteLine("3. Save entries to a file");
                Console.WriteLine("4. Load entries from a file");
                Console.WriteLine("5. Exit");

                // Try to parse the input to an integer
                if (Int32.TryParse(Console.ReadLine(), out userChoice))
                {
                    // Check if the parsed integer is a valid choice
                    if (userChoice >= 1 && userChoice <= 5)
                    {
                        isInvalidChoice = false; // Exit the inner while loop
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid option.");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid option.");
                }
            }

            // Handle the user's choice
            switch (userChoice)
            {
                case 1: // Create a new journal entry
                    string randomPrompt = promptGenerator.GetRandomPrompt();
                    journal.AddEntry(DateTime.Now, randomPrompt);
                    break;

                case 2: // Display entries
                    journal.DisplayAllEntries();
                    break;

                case 3: // Save entries to a file
                    journal.SaveEntriesToCsv();
                    break;

                case 4: // Load entries from a file
                    journal.LoadEntriesFromFile();
                    break;

                case 5: // Exit
                    Console.WriteLine("Exiting the Journal App. Goodbye!");
                    return; // Exit the program
            }
        }
    }
}
