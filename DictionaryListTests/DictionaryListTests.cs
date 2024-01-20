using DictionaryList;

namespace DictionaryListTests;

public class DictionaryListTests
{

    [Fact]
    public void TestAdd()
    {
        var dictionaryList = new DictionaryList<string, int>();
        dictionaryList.Add("test", 1);

        Assert.True(dictionaryList.ContainsKey("test"));
        Assert.Equal(1, dictionaryList.CountElementsByKey("test"));
    }

    [Fact]
    public void TestAddMultiple()
    {
        var dictionaryList = new DictionaryList<string, int>();
        dictionaryList.AddMultiple("test", new List<int> { 1, 2, 3 });

        Assert.True(dictionaryList.ContainsKey("test"));
        Assert.Equal(3, dictionaryList.CountElementsByKey("test"));
    }

    [Fact]
    public void TestGet()
    {
        var dictionaryList = new DictionaryList<string, int>();
        dictionaryList.Add("test", 1);

        var values = dictionaryList.Get("test");

        Assert.Contains(1, values);
    }

    [Fact]
    public void TestRemove()
    {
        var dictionaryList = new DictionaryList<string, int>();
        dictionaryList.Add("test", 1);
        dictionaryList.Remove("test");

        Assert.False(dictionaryList.ContainsKey("test"));
    }

    [Fact]
    public void TestCountElementsByKey()
    {
        var dictionaryList = new DictionaryList<string, int>();
        dictionaryList.AddMultiple("test", new List<int> { 1, 2, 3 });

        Assert.Equal(3, dictionaryList.CountElementsByKey("test"));
    }

    [Fact]
    public void TestContainsKey()
    {
        var dictionaryList = new DictionaryList<string, int>();
        dictionaryList.Add("test", 1);

        Assert.True(dictionaryList.ContainsKey("test"));
        Assert.False(dictionaryList.ContainsKey("notExist"));
    }

    [Fact]
    public void TestGetNonExistentKey()
    {
        var dictionaryList = new DictionaryList<string, int>();

        var values = dictionaryList.Get("notExist");

        Assert.Empty(values);
    }

    [Fact]
    public void TestRemoveNonExistentKey()
    {
        var dictionaryList = new DictionaryList<string, int>();

        // This should not throw an exception
        dictionaryList.Remove("notExist");

        Assert.False(dictionaryList.ContainsKey("notExist"));
    }
}