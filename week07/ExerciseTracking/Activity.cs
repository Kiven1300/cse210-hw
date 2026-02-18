using System;

public abstract class Activity
{
    private DateTime _date;
    private int _minutes;

    protected Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    protected DateTime Date => _date;
    protected int Minutes => _minutes;

    protected abstract string ActivityName { get; }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        double distance = GetDistance();
        double speed = GetSpeed();
        double pace = GetPace();

        return $"{Date:dd MMM yyyy} {ActivityName} ({Minutes} min): Distance {distance:0.0} km, Speed: {speed:0.0} kph, Pace: {pace:0.00} min per km";
    }
}