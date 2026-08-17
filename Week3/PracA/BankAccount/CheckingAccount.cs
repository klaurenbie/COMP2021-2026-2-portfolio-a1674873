namespace BankAccount;
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
    public override string DisplayAccountInfo()
    {
        var txt = $"{base.DisplayAccountInfo()}\nTransaction Fee: ${TransFee}";
        return txt;
        
    }
}

