using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine();
            DisplayPlayerInfo();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            string input = Console.ReadLine() ?? string.Empty;

            switch (input)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
    }

    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        string typeInput = string.Empty;
        while (true)
        {
            Console.Write("Which type of goal would you like to create? ");
            typeInput = Console.ReadLine() ?? string.Empty;
            if (typeInput == "1" || typeInput == "2" || typeInput == "3")
            {
                break;
            }

            Console.WriteLine("Invalid goal type. Please enter 1, 2, or 3.");
        }

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine() ?? string.Empty;

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine() ?? string.Empty;

        Console.Write("What is the amount of points associated with this goal? ");
        int points = ReadIntFromConsole();

        if (typeInput == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (typeInput == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = ReadIntFromConsole();

            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = ReadIntFromConsole();

            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals found. Create one first.");
            return;
        }

        Console.WriteLine("Which goal did you accomplish?");
        ListGoalNames();
        Console.Write("Enter the number of the goal: ");
        int index = ReadIntFromConsole() - 1;

        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

        int pointsEarned = _goals[index].RecordEvent();
        _score += pointsEarned;

        Console.WriteLine($"You earned {pointsEarned} points!");
        Console.WriteLine($"You now have {_score} points.");
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("Filename cannot be empty.");
            return;
        }

        List<string> lines = new List<string> { _score.ToString() };
        foreach (Goal goal in _goals)
        {
            lines.Add(goal.GetStringRepresentation());
        }

        try
        {
            File.WriteAllLines(filename, lines);
            Console.WriteLine("Goals saved.");
        }
        catch (IOException)
        {
            Console.WriteLine("Unable to save goals to the specified file.");
        }
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("Filename cannot be empty.");
            return;
        }

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines;
        try
        {
            lines = File.ReadAllLines(filename);
        }
        catch (IOException)
        {
            Console.WriteLine("Unable to read the specified file.");
            return;
        }

        if (lines.Length == 0)
        {
            Console.WriteLine("File is empty.");
            return;
        }

        _goals.Clear();
        if (!int.TryParse(lines[0], out _score))
        {
            _score = 0;
        }

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');
            if (parts.Length == 0)
            {
                continue;
            }

            string type = parts[0];
            if (type == "SimpleGoal" && parts.Length >= 5)
            {
                string name = parts[1];
                string description = parts[2];
                if (int.TryParse(parts[3], out int points) && bool.TryParse(parts[4], out bool isComplete))
                {
                    _goals.Add(new SimpleGoal(name, description, points, isComplete));
                }
            }
            else if (type == "EternalGoal" && parts.Length >= 4)
            {
                string name = parts[1];
                string description = parts[2];
                if (int.TryParse(parts[3], out int points))
                {
                    _goals.Add(new EternalGoal(name, description, points));
                }
            }
            else if (type == "ChecklistGoal" && parts.Length >= 7)
            {
                string name = parts[1];
                string description = parts[2];
                if (int.TryParse(parts[3], out int points)
                    && int.TryParse(parts[4], out int bonus)
                    && int.TryParse(parts[5], out int target)
                    && int.TryParse(parts[6], out int amountCompleted))
                {
                    _goals.Add(new ChecklistGoal(name, description, points, target, bonus, amountCompleted));
                }
            }
        }

        Console.WriteLine("Goals loaded.");
    }

    private int ReadIntFromConsole()
    {
        while (true)
        {
            string input = Console.ReadLine() ?? string.Empty;
            if (int.TryParse(input, out int value))
            {
                return value;
            }

            Console.Write("Please enter a valid number: ");
        }
    }
}
