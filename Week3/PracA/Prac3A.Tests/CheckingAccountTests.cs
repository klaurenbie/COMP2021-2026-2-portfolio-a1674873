namespace Prac3A.Tests;

public class CheckingAccountTests
{
    [Fact]
    public void Constructor_InitializesPropertiesCorrectly()
    {
        var b = new BankAccount.CheckingAccount("Test", 100m, 2m);

        Assert.Equal("Test", b.Owner);
        Assert.Equal(100m, b.Balance);
        Assert.Equal(2m, b.TransFee);
    }

    [Fact]
    public void Setters_ThrowArgumentException_WhenInvalidValuesProvided()
    {
        Assert.Throws<ArgumentException>(() => new BankAccount.SavingsAccount("10", 100m, 0.01m));
        Assert.Throws<ArgumentException>(() => new BankAccount.SavingsAccount("10", 100m, -1m));
    }

    [Fact]
    public void Deposit_UpdatesBalanceCorrectly()
    {
        var b = new BankAccount.CheckingAccount("Test", 100m, 2m);
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
        var b = new BankAccount.CheckingAccount("Test", 100m, 2m);
        b.Withdraw(10);
        var expectedNewBalance = 100m -10m - 2m;
        Assert.Equal(expectedNewBalance, b.Balance);
    }

    [Fact]
    public void Withdraw_ThrowsErrorWhenLowBalance()
    {
        var b = new BankAccount.CheckingAccount("Test", 100m, 2m);
        Assert.Throws<ArgumentException>(() => b.Withdraw(101m));
    }

    [Fact]
    public void DisplayAccountInfo_DisplaysCorrectly()
    {
        var b = new BankAccount.CheckingAccount("Test", 100m, 2m);
        var txt = b.DisplayAccountInfo();
        Assert.Contains("Test", txt);
        Assert.Contains("100", txt);
        Assert.Contains("$2", txt);
    }

}

