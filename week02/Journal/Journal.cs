using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries;

    public Journal()
    {
        _entries = new List<Entry>();
    }

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("\nNo entries found in the journal.\n");
            return;
        }

        Console.WriteLine("\n--- Journal Entries ---");
        foreach (Entry entry in _entries)
        {
            Console.WriteLine(entry.GetEntryText());
            Console.WriteLine();
        }
    }

    /// <summary>
    /// Saves all entries to a file with the specified filename.
    /// </summary>
    /// <param name="filename">The name of the file to save to</param>
    public void SaveToFile(string filename)
    {
        try
       Requerimiento excedido: Guardar en archivo
                {
                    writer.WriteLine(entry.ToFileFormat());
                }
            }
            Console.WriteLine($"\nJournal saved to {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}");
        }
    }

    /// <summary>
    /// Loads entries from a file, replacing any existing entries in the journal.
    /// </summary>
    /// <param name="filename">The name of the file to load from</param>
    public void LoadFromFile(string filename)
    {
        try
        {
            _entries.Clear();
            
       Requerimiento excedido: Cargar desde archivo
            }

            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        Entry entry = Entry.FromFileFormat(line);
                        _entries.Add(entry);
                    }
                }
            }
            Console.WriteLine($"\nJournal loaded from {filename} ({_entries.Count} entries)");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading file: {ex.Message}");
        }
    }

    /// <summary>
    /// Gets the number of entries currently in the journal.
    /// </summary>
    public int GetEntryCount()
    {
        return _entries.Count;
    }
}
