using System.Diagnostics.CodeAnalysis;

namespace Employee;

public class FullTimeEmployee: Employee, IReportable
{
    // attributes
    public decimal AnnualSalary {get; set;}

    // constructor
    [SetsRequiredMembers]
    public FullTimeEmployee(string name, decimal annualSal): base(name)
    {
        AnnualSalary = annualSal;
    }

    // method
    public override decimal CalculatePay()
    {
        decimal Tax = AnnualSalary * TaxRate;
        return AnnualSalary - Tax;
    }

    public string GenerateReport()
    {
        return $"Employee: {Name}\nSalary Before Tax: ${AnnualSalary}\nSalary After Tax: ${CalculatePay()}";
    }

}