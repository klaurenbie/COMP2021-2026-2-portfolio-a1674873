using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata;

namespace Employee;

public abstract class Employee
{
    // atributes
    protected const decimal TaxRate = 0.2m;
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