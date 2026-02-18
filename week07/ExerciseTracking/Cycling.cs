using System;

public class Cycling : Activity
{
    private double _speedKph;

    public Cycling(DateTime date, int minutes, double speedKph)
        : base(date, minutes)
    {
        _speedKph = speedKph;
    }

    protected override string ActivityName => "Cycling";

    public override double GetDistance()
    {
        return (_speedKph / 60.0) * Minutes;
    }

    public override double GetSpeed()
    {
        return _speedKph;
    }

    public override double GetPace()
    {
        return Minutes / GetDistance();
    }
}