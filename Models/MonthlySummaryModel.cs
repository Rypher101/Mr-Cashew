using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mr_Cashew.Models
{
    public class MonthlySummaryModel
    {
        public decimal bIncome { get; set; }
        public decimal bCost { get; set; }
        public decimal bTransport { get; set; }
        public decimal tIncome { get; set; }
        public decimal tCost { get; set; }
        public decimal tTransport { get; set; }
        public decimal BuyingTransport { get; set; }
        public decimal totCost { get; set; }
        public decimal totExpenses { get; set; }
        public decimal totIncome { get; set; }
        public decimal netProfit { get; set; }
        public DateTime date { get; set; }
    }
}
