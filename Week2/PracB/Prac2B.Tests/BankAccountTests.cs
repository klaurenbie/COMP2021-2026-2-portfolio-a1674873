namespace Prac2B.Tests;

public class BankAccountTests
{
    [Fact]
    public void Constructor_InitializesPropertiesCorrectly()
    {
        var b = new BankAccount.BankAccount("Test", 100m);

        Assert.Equal("Test", b.Owner);
        Assert.Equal(100m, b.Balance);
    }

    [Fact]
    public void Setters_ThrowArgumentException_WhenInvalidValuesProvided()
    {
        Assert.Throws<ArgumentException>(() => new BankAccount.BankAccount("10", 100m));
    }

    [Fact]
    public void Deposit_UpdatesBalanceCorrectly()
    {
        var b = new BankAccount.BankAccount("Test", 100m);
        b.Deposit(10);
        var expectedNewBalance = 100m +10m;
        Assert.Equal(expectedNewBalance, b.Balance);

        b.Deposit(10m);
        expectedNewBalance = 120m;
        Assert.Equal(expectedNewBalance, b.Balance);

        b.Deposit(Convert.ToDouble(10));
        expectedNewBalance = 130m;
        Assert.Equal(expectedNewBalance, b.Balance);

    }

    [Fact]
    public void Withdraw_UpdatesBalanceCorrectly()
    {
        var b = new BankAccount.BankAccount("Test", 100m);
        b.Withdraw(10);
        var expectedNewBalance = 100m -10m;
        Assert.Equal(expectedNewBalance, b.Balance);
    }

    [Fact]
    public void Withdraw_ThrowsErrorWhenLowBalance()
    {
        var b = new BankAccount.BankAccount("Test", 100m);
        Assert.Throws<ArgumentException>(() => b.Withdraw(110m));
    }
}
