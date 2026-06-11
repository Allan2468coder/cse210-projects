using System;

public abstract class Activity
{
    private DateTime _date;
    private int _minutes;
    private static bool _useMiles = false; // toggle units

    public Activity(DateTime date, int minutes)
    {
        if (minutes <= 0) throw new ArgumentException("Minutes must be positive.");
        _date = date;
        _minutes = minutes;
    }

    public DateTime Date => _date;
    public int Minutes => _minutes;

    public static void UseMiles(bool useMiles) => _useMiles = useMiles;
    public static bool IsMiles => _useMiles;

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        string unit = _useMiles ? "miles" : "km";
        string speedUnit = _useMiles ? "mph" : "kph";
        string paceUnit = _useMiles ? "min per mile" : "min per km";

        return $"{_date:dd MMM yyyy} {GetType().Name} ({_minutes} min) - " +
               $"Distance {GetDistance():0.0} {unit}, " +
               $"Speed {GetSpeed():0.0} {speedUnit}, " +
               $"Pace: {GetPace():0.00} {paceUnit}";
    }
}
