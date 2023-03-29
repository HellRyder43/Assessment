using CsvHelper;
using NLog;
using Smartly.Models;
using Smartly.Validator;
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
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public void Process(string inputFile, string outputFile, PaySlipProcessor calculator, EmployeeValidator validator)
        {
            try
            {
                using (var reader = new StreamReader(inputFile))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                using (var writer = new StreamWriter(outputFile))
                using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<EmployeeCsvMapper>();
                    var records = csv.GetRecords<Employee>().ToList();

                    Console.WriteLine($"\nNumber of Employees to process: {records.Count}");

                    csvWriter.WriteHeader<EmployeePaySlipCsv>();
                    csvWriter.NextRecord();

                    foreach (var employee in records)
                    {
                        if (!validator.IsValid(employee, out string errorMessage))
                        {
                            Console.WriteLine($"Invalid data for employee {employee.FirstName} {employee.LastName}: {errorMessage}");
                            continue;
                        }

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
            catch (Exception ex)
            {
                Logger.Error(ex, "An error occurred while processing the CSV files.");
            }
        }
    }
}
