
using System;
using System.Collections.Generic;

/*
 * EXCEEDING REQUIREMENTS:
 * This implementation includes:
 * 1. A library of multiple scriptures that are randomly selected for each session
 * 2. Progress tracking showing how many words are visible vs total
 * 3. Proper encapsulation with public/private access modifiers
 * 4. Support for both single verses and verse ranges
 * 5. Stretch challenge implemented: Only hides words that are not already hidden
 * 6. User-friendly interface with clear instructions and feedback
 */

class Program
{
    static void Main(string[] args)
    {
        // Create a list of scriptures for the user to practice with
        List<Scripture> scriptureLibrary = new List<Scripture>
        {
            // Single verse examples
            new Scripture(
                new ScriptureReference("John", 3, 16),
                "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."
            ),
            
            new Scripture(
                new ScriptureReference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."
            ),
            
            new Scripture(
                new ScriptureReference("Philippians", 4, 8),
                "Finally, brethren, whatsoever things are true, whatsoever things are honest, whatsoever things are just, whatsoever things are pure, whatsoever things are lovely, whatsoever things are of good report; if there be any virtue, and if there be any praise, think on these things."
            ),
            
            new Scripture(
                new ScriptureReference("Psalm", 23, 1, 3),
                "The Lord is my shepherd; I shall not want. He maketh me to lie down in green pastures: he leadeth me beside the still waters. He restoreth my soul: he leadeth me in the paths of righteousness for his name's sake."
            ),
            
            new Scripture(
                new ScriptureReference("1 John", 4, 7, 8),
                "Beloved, let us love one another: for love is of God; and every one that loveth is born of God, and knoweth God. He that loveth not knoweth not God; for God is love."
            )
        };

        // Main program loop
        bool practicing = true;
        while (practicing)
        {
            // Select a random scripture from the library
            Random random = new Random();
            Scripture currentScripture = scriptureLibrary[random.Next(scriptureLibrary.Count)];

            // Practice session for the selected scripture
            practicing = PracticeScripture(currentScripture);
        }

        Console.WriteLine("\nThank you for practicing! May these scriptures strengthen your faith and memory.");
    }

    // Handles the practice session for a single scripture
    static bool PracticeScripture(Scripture scripture)
    {
        Console.Clear();
        bool sessionActive = true;

        while (sessionActive)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine($"\n[Progress: {scripture.GetVisibleWordCount()}/{scripture.GetTotalWordCount()} words visible]");

            // Check if all words are hidden
            if (scripture.AreAllWordsHidden())
            {
                Console.WriteLine("\n✓ Congratulations! You've memorized the entire scripture!");
                Console.WriteLine("\nPress Enter to practice another scripture, or type 'quit' to exit.");
                string input = Console.ReadLine();
                return input?.ToLower() != "quit";
            }

            Console.WriteLine("\nPress Enter to hide more words, or type 'quit' to exit.");
            string userInput = Console.ReadLine();

            if (userInput?.ToLower() == "quit")
            {
                return false;
            }

            scripture.HideRandomWords();
        }

        return true;
    }
}