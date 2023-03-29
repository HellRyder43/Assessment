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
        private readonly List<TaxInfo> _taxInfo;

        public PaySlipProcessor(List<TaxInfo> taxinfo)
        {
            _taxInfo = taxinfo;
        }

        public decimal CalculateGrossIncome(int annualSalary)
        {
            return Math.Round(annualSalary / 12m, 2);
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

        public decimal CalculateNetIncome(decimal grossIncome, decimal incomeTax)
        {
            return Math.Round(grossIncome - incomeTax, 2);
        }

        public decimal CalculateSuper(decimal grossIncome, double superRate)
        {
            return Math.Round(grossIncome * (decimal)(superRate / 100), 2);
        }
    }
}
