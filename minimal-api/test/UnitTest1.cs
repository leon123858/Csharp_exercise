namespace test;
using minimal_api.Services;

public class Tests
{
    [SetUp]
    public void Setup() { }

    [Test]
    public void Test1()
    {
        TodoService service;
        Assert.AreEqual(4, 4);
        Assert.Pass();
    }
}
