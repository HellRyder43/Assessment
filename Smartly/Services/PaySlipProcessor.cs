using Smartly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartly.Services
{
    public class PaySlipProcessor
    {
        private readonly ITaxCalculator _taxCalculator;

        public PaySlipProcessor(ITaxCalculator taxCalculator)
        {
            _taxCalculator = taxCalculator;
        }

        public decimal CalculateGrossIncome(int annualSalary)
        {
            return Math.Round(annualSalary / 12m, 2);
        }

        public decimal CalculateNetIncome(decimal grossIncome, decimal incomeTax)
        {
            return Math.Round(grossIncome - incomeTax, 2);
        }

        public decimal CalculateIncomeTax(int annualSalary)
        {
            return _taxCalculator.CalculateIncomeTax(annualSalary);
        }

        public decimal CalculateSuper(decimal grossIncome, double superRate)
        {
            return Math.Round(grossIncome * (decimal)(superRate), 2);
        }
    }
}
