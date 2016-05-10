using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class FundOverviewChart
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Fund { get; set; }
        public double SP500 { get; set; }
        
        public DataContent DataArray { get; set; }
    }
}
