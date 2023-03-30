using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartly.Models
{
    public sealed class EmployeeCsvMapper : ClassMap<Employee>
    {
        public EmployeeCsvMapper()
        {
            Map(m => m.FirstName).Name("first name");
            Map(m => m.LastName).Name("last name");
            Map(m => m.AnnualSalary).Name("annual salary").Convert(args =>
            {
                var annualSalaryStr = args.Row.GetField("super rate (%)").Trim().TrimEnd('%');
                return int.TryParse(annualSalaryStr, out int annualSalary) ? annualSalary : -1;
            });
            Map(m => m.SuperRate).Name("super rate (%)").Convert(args =>
            {
                var superRateStr = args.Row.GetField("super rate (%)").Trim().TrimEnd('%');
                return double.TryParse(superRateStr, out double superRate) ? superRate / 100 : -1;
            });
            Map(m => m.PayPeriod).Name("pay period");
        }
    }
}
