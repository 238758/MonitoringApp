namespace FM4017Library.Helpers;

public static class Prettify
{
    public static (string? unit, string? parameter) Unit(string? unit)
    {
        if (unit == "CELSIUS_DEGREES")
        {
            return ("[°C]", "Temperature");
        }
        else if (unit == "PERCENTS")
        {
            return ("[%RH]", "Humidity");
        }
        else if (unit == "GENERIC")
        {
            return ("[1=Closed, 0=Open]", "State");
        }

        return (unit, null);
    }

    public static string? ParameterUnit(string? unit)
    {
        if (unit == "CELSIUS_DEGREES")
        {
            return "Temperature [°C]";
        }
        else if (unit == "PERCENTS")
        {
            return "Humidity [%RH]";
        }
        else if (unit == "GENERIC")
        {
            return "State [1=Closed, 0=Open]";
        }

        return unit;
    }

    public static string? Name(string? name)
    {
        return name?.Replace("_", " ");
    }
}
