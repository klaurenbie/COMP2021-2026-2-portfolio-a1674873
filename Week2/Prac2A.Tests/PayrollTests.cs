using System.Security;

namespace Prac2A.Tests;

public class PayrollTests
{
    [Fact]
    public void Constructor_InitializesPropertiesCorrectly()
    {
        var payroll = new PayrollCalculator.Payroll(0.2m, 40, 15.5m);

        Assert.Equal(0.2m, payroll.TaxRate);
        Assert.Equal(40, payroll.Hours);
        Assert.Equal(15.5m, payroll.Rate);
    }

    [Fact]
    public void Setters_ThrowArgumentException_WhenInvalidValuesProvided()
    {
        Assert.Throws<ArgumentException>(() => new PayrollCalculator.Payroll(-0.1m, 40, 15.5m));
        Assert.Throws<ArgumentException>(() => new PayrollCalculator.Payroll(1.1m, 40, 15.5m));
        Assert.Throws<ArgumentException>(() => new PayrollCalculator.Payroll(0.2m, -5, 15.5m));
        Assert.Throws<ArgumentException>(() => new PayrollCalculator.Payroll(0.2m, 40, -10m));
    }

    [Fact]
    public void CalculateNetPay_ReturnsCorrectValue()
    {
        var payroll = new PayrollCalculator.Payroll(0.2m, 40, 15.5m);
        var expectedNetPay = 40 * 15.5m * (1 - 0.2m);
        Assert.Equal(expectedNetPay, payroll.CalculateNetPay());
    }

    [Fact]
    public void ChangeTaxRate_UpdatesTaxRateCorrectly()
    {
        var payroll = new PayrollCalculator.Payroll(0.2m, 40, 15.5m);
        payroll.ChangeTaxRate(0.25m);
        Assert.Equal(0.25m, payroll.TaxRate);
    }
}
