namespace BankAccount;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            var b = new BankAccount("Chris", 234.5m);
            Console.WriteLine($"Bank Account created. Owner: {b.Owner}, Balance: {b.Balance}$.");

            b.Deposit(15);
            b.Withdraw(100);
            b.Withdraw(500);
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