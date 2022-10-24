using FM4017Library.Helpers;

namespace FM4017LibraryTests.Helpers;

[TestClass]
public class PrettifyTests
{
    [TestMethod]
    public void UnitTest()
    {
        string? actual, expected;

        actual = Prettify.Unit("CELSIUS_DEGREES");
        expected = "°C";
        Assert.AreEqual(expected, actual);

        actual = Prettify.Unit("PERCENTS");
        expected = "% RH";
        Assert.AreEqual(expected, actual);

        actual = Prettify.Unit("%");
        expected = "%";
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void NameTest()
    {
        string? actual, expected;

        actual = Prettify.Name("Some_Name");
        expected = "Some Name";
        Assert.AreEqual(expected, actual);

        actual = Prettify.Name("Some Name");
        expected = "Some Name";
        Assert.AreEqual(expected, actual);
    }
}