using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class DailyHoroscopeRecord
    {
        public int Id { get; set; }
        public Zodiac Zodiac { get; set; }
        public DateTime Date { get; set; }
        public string Ticker { get; set; }
        public string Analysis { get; set; }
        public string Enter { get; set; }
        public string Exit { get; set; }
        public string HoldingPeriod { get; set; }
        public double AvgHistReturn { get; set; }
        public double SuccessRate { get; set; }
        public string TestingPeriod { get; set; }

        public DataContent DataArray { get; set; }
    }
}