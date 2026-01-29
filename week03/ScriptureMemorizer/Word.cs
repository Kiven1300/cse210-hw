/*
 * Class: Word
 * Purpose: Represents a single word in a scripture that can be hidden or displayed
 * Encapsulation: Manages word state (hidden/visible)
 */

public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    // Returns the word as underscores if hidden, otherwise returns the actual word
    public string GetDisplayText()
    {
        if (_isHidden)
        {
            return new string('_', _text.Length);
        }
        return _text;
    }

    // Hides the word
    public void Hide()
    {
        _isHidden = true;
    }

    // Checks if the word is currently hidden
    public bool IsHidden()
    {
        return _isHidden;
    }

    // Gets the original text of the word
    public string GetText()
    {
        return _text;
    }
}
