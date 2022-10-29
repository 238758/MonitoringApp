using FM4017Library.Dtos;
using FM4017Library.Helpers;

namespace FM4017LibraryTests.Helpers;

[TestClass]
public class SignalNodeHelpersTests
{
    [TestMethod]
    public void ListUniqueUnitsTest()
    {
        List<SignalNode> signalNodes = new List<SignalNode>()
        {
            new SignalNode() { Unit = "°C"},
            new SignalNode() { Unit = "%"},
            new SignalNode() { Unit = "°C"},
            new SignalNode() { Unit = "°C"},
            new SignalNode() { Unit = "%"},
            new SignalNode() { Unit = "%"},
            new SignalNode() { Unit = "V"},
            new SignalNode() { Unit = null},
        };

        var actual = SignalNodeHelpers.ListAndOrderUniqueUnits(signalNodes);
        
        var expected = new List<SignalNode>()
        {
            new SignalNode() { Unit = "°C"},
            new SignalNode() { Unit = "%"},
            new SignalNode() { Unit = "V"},
            new SignalNode() { Unit = null},
        };

        Assert.AreEqual(4, actual!.Count);

        for (int i = 0; i < actual.Count; i++)
        {
            Assert.AreEqual(actual[i], expected[i].Unit);
            Console.WriteLine($"{i}: {actual[i]}");
        }
    }

    [TestMethod]
    public void SplitListToListsWithUniqueUnitTest()
    {
        List<SignalNode> signalNodes = new List<SignalNode>()
        {
            new SignalNode() { Unit = "°C", Timestamp = DateTime.Now},
            new SignalNode() { Unit = "%", Timestamp = DateTime.Now},
            new SignalNode() { Unit = "°C", Timestamp = DateTime.Now},
            new SignalNode() { Unit = "°C", Timestamp = DateTime.Now},
            new SignalNode() { Unit = "%", Timestamp = DateTime.Now},
            new SignalNode() { Unit = "%", Timestamp = DateTime.Now},
            new SignalNode() { Unit = null, Timestamp = DateTime.Now},
            new SignalNode() { Unit = "V", Timestamp = DateTime.Now},
        };

        var actual = SignalNodeHelpers.SplitListToListsWithUniqueUnit(signalNodes);

        actual[0].ForEach(x => Assert.AreEqual("°C", x.Unit));
        Assert.AreEqual(3, actual[0].Count);
        actual[1].ForEach(x => Assert.AreEqual("%", x.Unit));
        Assert.AreEqual(3, actual[1].Count);
        actual[2].ForEach(x => Assert.AreEqual(null, x.Unit));
        Assert.AreEqual(1, actual[2].Count);
        actual[3].ForEach(x => Assert.AreEqual("V", x.Unit));
        Assert.AreEqual(1, actual[3].Count);

        Assert.AreEqual(4, actual.Count);

        actual[0].ForEach(x => Console.WriteLine(x.Unit));
        actual[1].ForEach(x => Console.WriteLine(x.Unit));
        actual[2].ForEach(x => Console.WriteLine(x.Unit));
        actual[3].ForEach(x => Console.WriteLine(x.Unit));
    }
}
