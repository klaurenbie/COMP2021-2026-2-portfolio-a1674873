using System.Dynamic;
using System.IO.Pipes;
using System.Windows.Markup;

namespace BankAccount;

public class BankAccount
{
    // Fields
    private string _owner;
    private decimal _balance;

    
    // Properties
    public string Owner
    {
        get {return _owner; }
        private set
        {
            if (!value.All(char.IsLetter))
            {
                throw new ArgumentException("Owner must be character-only representing full name.");
            }
            _owner = value;
        }
    }
    public decimal Balance
    {
        get {return _balance; }
        private set
        {
            _balance = value;
        }
    }

    // Constructor
    public BankAccount(string owner, decimal balance)
    {
        Owner = owner;
        Balance = balance;
    }

    // Methods

    public void Deposit(decimal amount)
    {
        Balance = Balance + amount;
        Console.WriteLine($"Deposit succeeded. Balance is now {Balance}$.");
    }

    public void Deposit(int amount)
    {
        Balance = Balance + amount;
        Console.WriteLine($"Deposit succeeded. Balance is now {Balance}$.");
    }

    public void Deposit(double amount)
    {
        Balance = Balance + Convert.ToDecimal(amount);
        Console.WriteLine($"Deposit succeeded. Balance is now {Balance}$.");
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= Balance)
        {
            Balance = Balance - amount;
            Console.WriteLine($"Withdrawal succeeded. Balance is now {Balance}$.");
        }
        else
        {
            throw new ArgumentException($"Balance is lower than Withdrawing Amount. Current balance: {Balance}$.");
        }
    }
}