using Smartly.Models;
using Smartly.Services;
using Smartly.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Smartly
{
    class Program
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Employee monthly payslip processor\n");
            Logger.Info("Application started.");

            //Load tax info from JSON file
            var taxRatesLoader = new TaxRatesLoader();
            List<TaxInfo> taxRates;

            try
            {
                taxRates = taxRatesLoader.LoadTaxRates("Data/TaxRates.json");
                Console.WriteLine("Taxable income are as follows:");
                foreach (var tax in taxRates.OrderBy(rate => rate.TaxRate)) 
                    Console.WriteLine($"${tax.LowerLimit}-"+$"${tax.UpperLimit}"+" Rate: "+ $"{tax.TaxRate}%");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Error loading tax rates.");
                return;
            }

            // Initialize PaySlipCalculator with the tax rates
            var paySlipCalculator = new PaySlipProcessor(taxRates);

            // Initialize EmployeeValidator
            var employeeValidator = new EmployeeValidator();

            // Process the input CSV file and generate the output CSV file
            var csvProcessor = new CsvGenerator();
            csvProcessor.Process("Data/input.csv", "Data/output.csv", paySlipCalculator, employeeValidator);

            Console.WriteLine("\nFinished processing the monthly payslip");
            Console.WriteLine("\nPlease find the result in Data\\output.csv");
            Console.WriteLine("\nYou may close this window");
            Logger.Info("Application finished.");
            Console.ReadLine();
        }
    }
}
