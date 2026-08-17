
namespace BankAccount;

class Program
{
    static void Main (string[] args)
    {
        try
        {
            var s = new SavingsAccount("Chris", 234.5m, 1);
            Console.WriteLine($"Bank Account created. Owner: {s.Owner}, Balance: {s.Balance}$, Interest Rate: {s.InterestRate}");
            s.Deposit(15);
            s.Withdraw(100);
            s.ApplyInterest();

            var c = new CheckingAccount("Helen", 200m, 1);
            Console.WriteLine($"Bank Account created. Owner: {c.Owner}, Balance: {c.Balance}$, Transaction Fee: {c.TransFee}");

            s.Deposit(15);
            s.Withdraw(215);

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