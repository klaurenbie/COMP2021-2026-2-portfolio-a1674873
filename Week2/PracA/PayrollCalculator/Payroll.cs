using System.IO.Pipes;
using System.Runtime.ExceptionServices;

namespace PayrollCalculator;

public class Payroll
{   
    // Fields
    private decimal _taxRate;
    private double _hours;
    private decimal _rate;

    // Properties
    public decimal TaxRate
    {
        get { return _taxRate; }
        private set
        {
            if (value < 0 || value > 1)
            {
                throw new ArgumentException("Tax rate must be between 0 and 1.");
            }
            _taxRate = value;
        }
    }
    public double Hours
    {
        get { return _hours; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Hours must be positive.");
            }
            _hours = value;
        }
    }
    public decimal Rate
    {
        get { return _rate; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Rate must be positive.");
            }
            _rate = value;
        }
    }

    // Constructor
    public Payroll(decimal taxRate, double hours, decimal rate)
    {
        TaxRate = taxRate;
        Hours = hours;
        Rate = rate;
    }
    
    // Methods

    public decimal CalculateNetPay()
    {
        decimal gross = (decimal)_hours * _rate;
        decimal tax = gross * _taxRate;
        decimal net = gross - tax;

        return net;
    }


    public void ChangeTaxRate(decimal newTaxRate)
    {
        TaxRate = newTaxRate;
    }
        
}
