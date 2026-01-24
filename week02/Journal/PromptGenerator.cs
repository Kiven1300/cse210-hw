using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> _prompts;
    private Random _random;

    public PromptGenerator()
    {
        _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What am I grateful for today?",
            "What challenge did I face today and how did I handle it?",
            "What made me smile or laugh today?",
            "What did I learn about myself today?",
            "How did I help someone else today?"
        };
        _random = new Random();
    }

    /// <summary>
    /// Gets a random prompt from the available prompts.
    /// </summary>
    /// <returns>A randomly selected prompt string</returns>
    public string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
    public string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }

    // Requerimiento excedido: Permitir agregar nuevos prompts
    /// </summary>
    public int GetPromptCount()
    {
        return _prompts.Count;
    }
}