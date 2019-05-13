using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCorePdfSample.Models
{
    public class CarCalculator
    {        
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public List<CarCalculatorDetail> CarDetails { get; set; }
        public string CSSLink { get; set; }
    }
}
