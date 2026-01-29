/*
 * Class: Scripture
 * Purpose: Represents a complete scripture with reference and text
 * Encapsulation: Manages words, hiding words, and checking if all words are hidden
 */

using System;
using System.Collections.Generic;

public class Scripture
{
    private ScriptureReference _reference;
    private List<Word> _words;

    public Scripture(ScriptureReference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        // Split text into words and create Word objects
        string[] wordTexts = text.Split(new[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries);
        foreach (string wordText in wordTexts)
        {
            _words.Add(new Word(wordText));
        }
    }

    // Returns the full scripture as a formatted string
    public string GetDisplayText()
    {
        string reference = _reference.GetReference();
        string text = "";

        foreach (Word word in _words)
        {
            text += word.GetDisplayText() + " ";
        }

        return $"{reference}\n{text.Trim()}";
    }

    // Hides a random number of words (3-5 words)
    public void HideRandomWords()
    {
        Random random = new Random();
        int wordsToHide = random.Next(3, 6); // Hide 3-5 words

        for (int i = 0; i < wordsToHide; i++)
        {
            int randomIndex = random.Next(_words.Count);
            _words[randomIndex].Hide();
        }
    }

    // Checks if all words in the scripture are hidden
    public bool AreAllWordsHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }

    // Gets the count of visible words (for tracking progress)
    public int GetVisibleWordCount()
    {
        int count = 0;
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                count++;
            }
        }
        return count;
    }

    // Gets the total word count
    public int GetTotalWordCount()
    {
        return _words.Count;
    }
}
