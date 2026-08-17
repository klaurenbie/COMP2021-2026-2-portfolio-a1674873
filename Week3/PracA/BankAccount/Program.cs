
namespace BankAccount;

class Program
{
    static void Main (string[] args)
    {
        try
        {
            var s = new SavingsAccount("Chris", 234.5m, 0.05m);
            Console.WriteLine(s.DisplayAccountInfo());
            s.Deposit(15);
            s.Withdraw(100);
            s.ApplyInterest();
            Console.WriteLine(s.DisplayAccountInfo());

            var c = new CheckingAccount("Helen", 200m, 1);
            Console.WriteLine($"Bank Account created. Owner: {c.Owner}, Balance: {c.Balance}$, Transaction Fee: {c.TransFee}");
            Console.WriteLine(c.DisplayAccountInfo());
            c.Deposit(15);
            c.Withdraw(215);

        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Please enter appropriate values");
        }

        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}