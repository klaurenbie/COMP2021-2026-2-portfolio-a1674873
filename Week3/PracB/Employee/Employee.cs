using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata;

namespace Employee;

public abstract class Employee
{
    // atributes
    public const decimal TaxRate = 0.2m;
    public required string Name {get; set;}

    // constructor
    [SetsRequiredMembers]
    public Employee(string name)
    {
        Name = name;
    }

    // method
    public abstract decimal CalculatePay();
}