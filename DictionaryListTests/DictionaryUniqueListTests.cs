using DictionaryList;

namespace DictionaryListTests;

public class DictionaryUniqueListTests
{
    [Fact]
    public void TestAddAndContains()
    {
        var dict = new DictionaryUniqueList<string, int>();
        dict.Add("test", 1);
        Assert.True(dict.ContainsKey("test"));
        Assert.True(dict.ContainsValue("test", 1));
    }

    [Fact]
    public void TestAddDuplicateValue()
    {
        var dict = new DictionaryUniqueList<string, int>();
        dict.Add("test", 1);
        dict.Add("test", 1);
        var values = dict.Values("test");
        Assert.Single(values);
    }

    [Fact]
    public void TestRemoveKey()
    {
        var dict = new DictionaryUniqueList<string, int>();
        dict.Add("test", 1);
        dict.Remove("test");
        Assert.False(dict.ContainsKey("test"));
    }

    [Fact]
    public void TestRemoveValue()
    {
        var dict = new DictionaryUniqueList<string, int>();
        dict.Add("test", 1);
        dict.Remove("test", 1);
        Assert.False(dict.ContainsValue("test", 1));
    }

    [Fact]
    public void TestValues()
    {
        var dict = new DictionaryUniqueList<string, int>();
        dict.Add("test", 1);
        dict.Add("test", 2);
        var values = dict.Values("test");
        Assert.Contains(1, values);
        Assert.Contains(2, values);
    }

    [Fact]
    public void TestKeys()
    {
        var dict = new DictionaryUniqueList<string, int>();
        dict.Add("test", 1);
        dict.Add("anotherTest", 2);
        var keys = dict.Keys;
        Assert.Contains("test", keys);
        Assert.Contains("anotherTest", keys);
    }

    [Fact]
    public void TestRemoveNonExistentValue()
    {
        var dict = new DictionaryUniqueList<string, int>();
        dict.Add("test", 1);
        bool removed = dict.Remove("test", 2);
        Assert.False(removed);
        Assert.True(dict.ContainsValue("test", 1));
    }

    [Fact]
    public void TestValuesForNonExistentKey()
    {
        var dict = new DictionaryUniqueList<string, int>();
        var values = dict.Values("test");
        Assert.Empty(values);
    }
}