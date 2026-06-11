using System;

public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int minutes, int laps)
        : base(date, minutes)
    {
        if (laps <= 0) throw new ArgumentException("Laps must be positive.");
        _laps = laps;
    }

    public override double GetDistance()
    {
        double km = (_laps * 50) / 1000.0;
        return IsMiles ? km * 0.62 : km;
    }

    public override double GetSpeed() => (GetDistance() / Minutes) * 60;

    public override double GetPace() => Minutes / GetDistance();

    public override string GetSummary()
    {
        return base.GetSummary() + $" ({_laps} laps)";
    }
}
