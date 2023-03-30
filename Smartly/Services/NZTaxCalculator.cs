using Smartly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartly.Services
{
    public class NZTaxCalculator : ITaxCalculator
    {
        private readonly List<TaxInfo> _taxInfo;

        public NZTaxCalculator(List<TaxInfo> taxInfo)
        {
            _taxInfo = taxInfo;
        }

        public decimal CalculateIncomeTax(int annualSalary)
        {
            decimal tax = 0;

            foreach (var rate in _taxInfo)
            {
                int taxableIncome = Math.Min(annualSalary, rate.UpperLimit) - rate.LowerLimit;
                if (taxableIncome > 0)
                {
                    tax += taxableIncome * (decimal)rate.TaxRate;
                }
            }

            return Math.Round(tax / 12m, 2);
        }
    }

}
