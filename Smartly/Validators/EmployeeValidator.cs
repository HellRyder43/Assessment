using Smartly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartly.Validator
{
    public class EmployeeValidator
    {
        public bool IsValid(Employee employee, out string errorMessage)
        {
            if (string.IsNullOrEmpty(employee.FirstName) || string.IsNullOrEmpty(employee.LastName))
            {
                errorMessage = "First name and last name cannot be empty.";
                return false;
            }

            if (employee.AnnualSalary < 0)
            {
                errorMessage = "Annual salary cannot be negative.";
                return false;
            }

            if (employee.SuperRate < 0 || employee.SuperRate > 50)
            {
                errorMessage = "Super rate must be between 0% and 50% inclusive.";
                return false;
            }

            if (string.IsNullOrEmpty(employee.PayPeriod))
            {
                errorMessage = "Pay period cannot be empty.";
                return false;
            }

            errorMessage = null;
            return true;
        }
    }
}
