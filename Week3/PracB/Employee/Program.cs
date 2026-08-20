using System.Reflection;

namespace Employee;

class Program
{
    static void Main(string[] args)
    {
        var e1 = new FullTimeEmployee(name:"Helen", 80000);
        var c1 = new Contractor("Fred", 45, 120.55m);

        Console.WriteLine($"{e1.Name} has a salary of ${e1.CalculatePay()}");
        Console.WriteLine($"{c1.Name} has a payment of ${c1.CalculatePay()}");
        Console.WriteLine($"{e1.GenerateReport()}\n{c1.GenerateReport()}") ;
    }
}
