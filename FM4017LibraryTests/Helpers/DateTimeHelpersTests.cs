using FM4017Library.Helpers;
using System.Globalization;

namespace FM4017Library.Tests.Helpers;

[TestClass]
public class DateTimeHelpersTests
{
    [TestMethod]
    public void DateTimeHelpersTest()
    {
        string expected = "2021-12-17T14:30:21.000+00:00";

        string dateInput = "17.12.21";
        var parsedDate = DateTime.Parse(dateInput);
        parsedDate = parsedDate.AddHours(14);
        parsedDate = parsedDate.AddMinutes(30);
        parsedDate = parsedDate.AddSeconds(21);

        string actual = DateTimeHelpers.DateTimeToD4Format(parsedDate);

        Console.WriteLine(DateTime.Now);
        Console.WriteLine(DateTimeHelpers.DateTimeToD4Format(DateTime.Now));

        Assert.AreEqual(expected, actual);
    }
}
