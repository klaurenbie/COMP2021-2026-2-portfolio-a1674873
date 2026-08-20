using System.Diagnostics.CodeAnalysis;

namespace Employee;

public class Contractor: Employee, IReportable
{
    // attributes
    decimal Rate {get; set;}
    decimal Hours {get; set;}

    // constructor
    [SetsRequiredMembers]
    public Contractor(string name, decimal rate, decimal hours): base(name)
    {
        Rate = rate;
        Hours = hours;
    }

    // method
    public override decimal CalculatePay()
    {
        decimal Pay = Rate * Hours;
        return Pay * (1 - TaxRate);
    }
    
    public string GenerateReport()
    {
        return $"Contractor: {Name}\nHourly Rate: {Rate}\nHours worked: {Hours}\nTotal Pay: ${CalculatePay()}";
    }
}