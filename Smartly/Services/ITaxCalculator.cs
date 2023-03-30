using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartly.Services
{
    public interface ITaxCalculator
    {
        decimal CalculateIncomeTax(int annualSalary);
    }

}
