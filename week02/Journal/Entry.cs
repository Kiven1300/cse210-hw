using System;

public class Entry
{
    private string _prompt;
    private string _response;
    private string _date;

    public Entry(string prompt, string response, string date)
    {
        _prompt = prompt;
        _response = response;
        _date = date;
    }

    public string GetPrompt()
    {
        return _prompt;
    }

    public string GetResponse()
    {
        return _response;
    }

    public string GetDate()
    {
        return _date;
    }

    public string GetEntryText()
    {
        return $"Date: {_date}\nPrompt: {_prompt}\n{_response}";
    }

    /// <summary>
    /// Returns a string in a format suitable for saving to a file.
    /// Uses a separator character (~|~) to separate fields.
    /// </summary>
    public string ToFileFormat()
    {
        return $"{_date}~|~{_prompt}~|~{_response}";
    }

    // Requerimiento excedido: Deserialización desde archivo
    pu Requerimiento excedido: Persistencia en archivoLength == 3)
        {
            return new Entry(parts[1], parts[2], parts[0]);
        }
        throw new FormatException("Invalid entry format");
    }
}
