using System.Reflection;
using System.Runtime.CompilerServices;

namespace Employee;

class Program
{
    static void Main(string[] args)
    {   
        var e1 = new FullTimeEmployee(name:"Helen", 80000);
        var c1 = new Contractor("Fred", 45, 120.55m);
        var e2 = new FullTimeEmployee("Bill", 100000);
        var c2 = new Contractor("Alex", 30, 100);
        var c3 = new Contractor("Megan", 56, 30);

        List<Employee> employees = [e1, c1, e2, c2, c3];

        Console.WriteLine($"{e1.Name} has a salary of ${e1.CalculatePay()}");
        Console.WriteLine($"{c1.Name} has a payment of ${c1.CalculatePay()}");
        Console.WriteLine($"{e1.GenerateReport()}\n{c1.GenerateReport()}");

        foreach (Employee e in employees)
        {
            // Calculate pay
            var netPay = e.CalculatePay();
            var grossPay = netPay/(1 - Employee.TaxRate);
            var tax = grossPay - netPay;

            // Output
            Console.WriteLine($"{e.Name}: Pay {netPay:C0}. Tax: {tax:C0}.");
        }
    }
}
