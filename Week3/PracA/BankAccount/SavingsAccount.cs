namespace BankAccount;

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

    public override string DisplayAccountInfo()
    {
        return $"{base.DisplayAccountInfo()}\nInterest rate: {InterestRate}";
    }
    
}
