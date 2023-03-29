using CsvHelper;
using Smartly.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartly.Services
{
    public class CsvGenerator
    {
        public void Process(string inputFile, string outputFile, PaySlipProcessor calculator)
        {
            using (var reader = new StreamReader(inputFile))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            using (var writer = new StreamWriter(outputFile))
            using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<EmployeeCsvMapper>();
                var records = csv.GetRecords<Employee>().ToList();

                csvWriter.WriteHeader<EmployeePaySlipCsv>();
                csvWriter.NextRecord();

                foreach (var employee in records)
                {
                    decimal grossIncome = calculator.CalculateGrossIncome(employee.AnnualSalary);
                    decimal incomeTax = calculator.CalculateIncomeTax(employee.AnnualSalary);
                    decimal netIncome = calculator.CalculateNetIncome(grossIncome, incomeTax);
                    decimal superAmount = calculator.CalculateSuper(grossIncome, employee.SuperRate);

                    csvWriter.WriteField($"{employee.FirstName} {employee.LastName}");
                    csvWriter.WriteField(employee.PayPeriod);
                    csvWriter.WriteField(grossIncome);
                    csvWriter.WriteField(incomeTax);
                    csvWriter.WriteField(netIncome);
                    csvWriter.WriteField(superAmount);
                    csvWriter.NextRecord();
                }
            }
        }
    }
}
