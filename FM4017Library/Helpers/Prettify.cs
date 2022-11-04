namespace FM4017Library.Helpers;

public static class Prettify
{
    public static string? Unit(string? unit)
    {
        if (unit == "CELSIUS_DEGREES")
        {
            return "Temperature [°C]";
        }
        else if (unit == "PERCENTS")
        {
            return "Humidity [%RH]";
        }
        else if (unit == "KILOGRAMS")
        {
            return "kg";
        }
        else if (unit == "GENERIC")
        {
            return "State [1=Open, 0=Closed]";
        }

        return unit;
    }

    public static string? Name(string? name)
    {
        return name?.Replace("_", " ");
    }
}
