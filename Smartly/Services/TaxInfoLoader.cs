using Newtonsoft.Json;
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
        public List<TaxInfo> LoadTaxRates(string fileName)
        {
            string json = File.ReadAllText(fileName);
            return JsonConvert.DeserializeObject<List<TaxInfo>>(json);
        }
    }
}
