using Smartly.Models;
using Smartly.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartly
{
    class Program
    {
        static void Main(string[] args)
        {
            //Load tax info from JSON file
            var taxRatesLoader = new TaxRatesLoader();
            List<TaxInfo> taxRates = taxRatesLoader.LoadTaxRates("Data/TaxRates.json");

            // Initialize PaySlipCalculator with the tax rates
            var paySlipCalculator = new PaySlipProcessor(taxRates);

            // Process the input CSV file and generate the output CSV file
            var csvProcessor = new CsvGenerator();
            csvProcessor.Process("Data/input.csv", "Data/output.csv", paySlipCalculator);
        }
    }
}
