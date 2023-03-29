using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartly.Model
{
    public class TaxInfo
    {
        public int LowerLimit { get; set; }
        public int UpperLimit { get; set; }
        public double TaxRate { get; set; }
    }

}
