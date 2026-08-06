using System.IO.Pipes;

namespace PayrollCalculator;

class Program
{
    static double TAX_RATE = 0.2;
    static void Main(string[] args)
    {
        Console.Write("Enter employee first name: ");
        string first = Console.ReadLine();
        
        Console.Write("Enter employee last name: ");
        string last = Console.ReadLine();

        Console.Write("Enter employee age: ");
        int age = int.Parse(Console.ReadLine());        

        var p = new Person(first, last, age);
        
        Console.Write("Hours worked: ");
        double hours = double.Parse(Console.ReadLine());

        Console.Write("Hourly rate: ");
        double rate = Convert.ToDouble(Console.ReadLine());

        double net_pay = CalculatePay(hours, rate);
        Console.WriteLine($"{p.fist} earned ${net_pay:F2} after tax.");
        
    }

    static double CalculatePay(double hours, double rate)
    {
        if (hours < 0 || rate < 0)
        {
            throw new ArgumentException("Hours and rate must be positive.");
        }

        double gross = hours * rate;
        double tax = gross * TAX_RATE;
        double net = gross - tax;

        return net;
    }
}

