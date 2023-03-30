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
            var errorMessages = new StringBuilder();

            if (string.IsNullOrEmpty(employee.FirstName) || string.IsNullOrEmpty(employee.LastName))
            {
                errorMessages.AppendLine("First name and last name cannot be empty.");
            }

            if (employee.AnnualSalary < 0)
            {
                errorMessages.AppendLine("Annual salary cannot be empty or negative.");
            }

            if (employee.SuperRate < 0 || employee.SuperRate > 50)
            {
                errorMessages.AppendLine("Super rate must be between 0% and 50% inclusive.");
            }

            if (string.IsNullOrEmpty(employee.PayPeriod))
            {
                errorMessages.AppendLine("Pay period cannot be empty.");
            }

            errorMessage = errorMessages.ToString();

            // If there are no error messages, the employee is considered valid
            return string.IsNullOrEmpty(errorMessage);
        }
    }
}
