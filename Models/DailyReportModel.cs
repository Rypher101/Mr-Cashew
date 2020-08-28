using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mr_Cashew.Models
{
    public class DailyReportModel
    {
        public DateTime date { get; set; }
        public decimal income { get; set; }
        public decimal expenses { get; set; }
        public decimal profit { get; set; }
    }
}
