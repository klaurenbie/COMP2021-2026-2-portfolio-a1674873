using Employee;

namespace Prac3B.Tests;

public class ContractorTests
{
    [Fact]
    public void CalculatePay_ReturnsCorrectSalary()
    {
        var c = new Contractor("Tegan", 50m, 100m);
        var expected = (50m * 100m) * (1 - 0.2m);
        Assert.Equal(expected, c.CalculatePay());
    }

    [Fact]
    public void GenerateReport_ReturnsCorrectValues()
    {
        var c = new Contractor("Tegan", 50m, 100m);
        var txt = c.GenerateReport();

        Assert.Contains("Tegan", txt);
        Assert.Contains("Hourly Rate: 50", txt);
        Assert.Contains("Hours worked: 100", txt);
        Assert.Contains("Total Pay: ", txt);
    }
}
