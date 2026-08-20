using Employee;

namespace Prac3B.Tests;

public class FullTimeEmployeeTests
{
    [Fact]
    public void Constructor_InitializesPropertiesCorrectly()
    {
        var e = new FullTimeEmployee("Tegan", 100000m);
        Assert.Equal("Tegan", e.Name);
        Assert.Equal(100000m, e.AnnualSalary);
        Assert.Equal(Employee.Employee.TaxRate, 0.2m);
    }
    
    [Fact]
    public void CalculatePay_ReturnsCorrectSalary()
    {
        var e = new FullTimeEmployee("Tegan", 100000m);
        var expected = 100000m - 100000m * 0.2m;
        Assert.Equal(expected, e.CalculatePay());
    }

    [Fact]
    public void GenerateReport_ReturnsCorrectValues()
    {
        var e = new FullTimeEmployee("Tegan", 100000m);
        var txt = e.GenerateReport();

        Assert.Contains("Tegan", txt);
        Assert.Contains("Salary Before Tax: $100000", txt);
        Assert.Contains("Salary After Tax:", txt);
    }
}
