using FM4017Library.DataAccess.GraphQlQueries;

namespace FM4017LibraryTests.DataAccess;

[TestClass]
public class GraphQlQueriesTests
{
    [TestMethod]
    public void DeleteSpaceTest()
    {
        var actual = GraphQlQueries.DeleteSpace("1234");

        Console.WriteLine(actual);

    }

    [TestMethod]
    public void CreateSpaceTest()
    {
        var actual = GraphQlQueries.CreateSpace("MyName");

        Console.WriteLine(actual);

    }
}
