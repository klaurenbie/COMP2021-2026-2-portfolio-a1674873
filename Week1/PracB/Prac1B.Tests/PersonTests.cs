using Xunit;
using ToDo;
using Newtonsoft.Json.Bson;

namespace Prac1B.Tests;

public class PersonTests
{
    [Fact]
    public void FullName_ReturnsExpectedFormat()
    {
        var p = new Person("Alice", "Nguyen", 25);
        Assert.Equal("Nguyen, Alice", p.FullName());
    }

    [Fact]
    public void IsAdult_ReturnsTrue_WhenAgeIs18OrMore()
    {
        var p = new Person("Bob", "Smith", 18);
        Assert.True(p.IsAdult());

        p.Age = 17;
        Assert.False(p.IsAdult());

        p.Age = 20;
        Assert.True(p.IsAdult());
    }
}
