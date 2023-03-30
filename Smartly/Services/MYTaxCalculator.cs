using Smartly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartly.Services
{
    public class MYTaxCalculator : ITaxCalculator
    {
        private readonly List<TaxInfo> _taxInfo;

        public MYTaxCalculator(List<TaxInfo> taxInfo)
        {
            _taxInfo = taxInfo;
        }

        public decimal CalculateIncomeTax(int annualSalary)
        {
            return (decimal)(annualSalary * 0.03);
        }
    }
}
