using System;

// Requerimiento excedido: Persistencia en archivo y carga
class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        
        string choice = "";
        while (choice != "5")
        {
            DisplayMenu();
            choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    WriteNewEntry(journal, promptGenerator);
                    break;
                case "2":
                    journal.DisplayAll();
                    break;
                case "3":
                    SaveJournal(journal);
                    break;
                case "4":
                    LoadJournal(journal);
                    break;
                case "5":
                    Console.WriteLine("\nGoodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.\n");
                    break;
            }
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("\n========== Journal Menu ==========");
        Console.WriteLine("1. Write New Entry");
        Console.WriteLine("2. Display Journal");
        Console.WriteLine("3. Save Journal to File");
        Console.WriteLine("4. Load Journal from File");
        Console.WriteLine("5. Exit");
        Console.WriteLine("==================================");
        Console.Write("Please select an option (1-5): ");
    }

    static void WriteNewEntry(Journal journal, PromptGenerator promptGenerator)
    {
        string prompt = promptGenerator.GetRandomPrompt();
        Console.WriteLine($"\n{prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();
        
        string date = DateTime.Now.ToString("yyyy-MM-dd");
        Entry entry = new Entry(prompt, response, date);
        journal.AddEntry(entry);
        
        Console.WriteLine("Entry saved successfully!\n");
    }

    static void SaveJournal(Journal journal)
    {
        Console.Write("\nEnter filename to save to: ");
        string filename = Console.ReadLine();
        journal.SaveToFile(filename);
    }

    static void LoadJournal(Journal journal)
    {
        Console.Write("\nEnter filename to load from: ");
        string filename = Console.ReadLine();
        journal.LoadFromFile(filename);
    }
}