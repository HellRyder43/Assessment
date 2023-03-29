using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartly.Models
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AnnualSalary { get; set; }
        public double SuperRate { get; set; }
        public string PayPeriod { get; set; }
    }

    public class EmployeePaySlipCsv
    {
        public string Name { get; set; }
        public string PayPeriod { get; set; }
        public string GrossIncome { get; set; }
        public string IncomeTax { get; set; }
        public string NetIncome { get; set; }
        public string SuperRate { get; set; }
    }
}
