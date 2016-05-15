using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class FundFundOverview
    {
        [Index]
        public int Id { get; set; }
        [Index]
        public int Year { get; set; }

        public double? TotalFundReturn { get; set; }
        public double? AvgSignalsReturn { get; set; }
        public double? ProfitableSignals { get; set; }

        [Index]
        public DataContent DataArray { get; set; }
    }
}
