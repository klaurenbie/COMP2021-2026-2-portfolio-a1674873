using Xunit;
using PayrollCalculator;

namespace Topic1A.Test;

public class PersonTests
{
    [Fact]
    public void FullName_ReturnsExpectedFormat()
    {
        var p = new Person("Alice", "Nguyen", 25);
        Assert.Equal("Nguyen, Alice", p.FullName());
    }
}
