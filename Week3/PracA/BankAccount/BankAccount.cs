using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.IO.Pipes;
using System.Numerics;
using System.Windows.Markup;

namespace BankAccount;

public abstract class BankAccount
{
    // Fields
    private string _owner;
    private decimal _balance;

    
    // Properties
    public string Owner
    {
        get {return _owner; }
        protected set
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
        protected set
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

    public virtual void Withdraw(decimal amount)
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

public class CheckingAccount: BankAccount
{
    private decimal _transFee;
    
    // property
    public decimal TransFee
    {
        get {return _transFee;}

        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Transaction fee must not be negative.");
            }
            else
            {
                _transFee = value;
            }
        }
    }

    // Constructor
    public CheckingAccount(string owner, decimal balance, decimal transFee): base(owner, balance)
    {
        TransFee = transFee;
    }

    // Method
    public override void Withdraw(decimal amount)
    {
        var total = amount + TransFee;
        if (total <= Balance)
        {
            Balance = Balance - total;
        }
        else
        {
            throw new ArgumentException($"Balance is lower than Withdrawing Amount. Current balance: {Balance}$.");
        }
    }
}


public class SavingsAccount: BankAccount
{
    private decimal _interestRate;
    
    // property
    public decimal InterestRate
    {
        get {return _interestRate;}

        set
        {
            if (value > 1 || value < 0)
            {
                throw new ArgumentException("Interest rate must be between 0 and 1.");
            }
            else
            {
                _interestRate = value;
            }
        }
    }

    // Constructor
    public SavingsAccount(string owner, decimal balance, decimal interestRate): base(owner, balance)
    {
        InterestRate = interestRate;
    }

    // Method
    public void ApplyInterest()
    {
        Balance = Balance * (1 + InterestRate);
    }
    
}
