using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCorePdfSample.Models
{
    public class CarCalculatorDetail
    {
        public int Option { get; set; }
        public int VariantId { get; set; }
        public string VariantDesc { get; set; }
        public string VariantImageString { get; set; }
        public string SeriesDesc { get; set; }
        public int FinancingProductId { get; set; }
        public string FinancingProduct { get; set; }
        public string RRP { get; set; }
        public int DownPaymentPercentage { get; set; }
        public string DownPayment { get; set; }
        public int Tenure { get; set; }
        public string Mileage { get; set; }
        public int CampaignId { get; set; }
        public decimal Rate { get; set; }
        public string monthlyInstallment { get; set; }
        public string LastInstallment { get; set; }
        public string GFV { get; set; }
    }
}
