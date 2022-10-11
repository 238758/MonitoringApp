namespace FM4017Library.Helpers;

public static class Prettify
{
    public static string? Unit(string? unit)
    {
        if (unit == "CELSIUS_DEGREES")
        {
            return "°C";
        }
        else if (unit == "PERCENTS")
        {
            return "% RH";
        }

        return unit;
    }

    public static string? Name(string? name)
    {
        return name?.Replace("_", " ");
    }
}
