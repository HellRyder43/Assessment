using Newtonsoft.Json;
using NLog;
using Smartly.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartly.Services
{
    public class TaxRatesLoader
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public List<TaxInfo> LoadTaxRates(string fileName)
        {
            try
            {
                string json = File.ReadAllText(fileName);
                return JsonConvert.DeserializeObject<List<TaxInfo>>(json);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error loading tax rates from file: {0}. {ex}", fileName);
                throw;
            }
        }
    }
}
