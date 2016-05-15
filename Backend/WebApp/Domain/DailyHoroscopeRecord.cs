using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class DailyHoroscopeRecord
    {
        [Index]
        public int Id { get; set; }
        [Index]
        public Zodiac Zodiac { get; set; }
        [Index]
        public DateTime Date { get; set; }

        public string Ticker { get; set; }
        public string Analysis { get; set; }
        public string Enter { get; set; }
        public string Exit { get; set; }
        public string HoldingPeriod { get; set; }
        public double? AvgHistReturn { get; set; }
        public double? SuccessRate { get; set; }
        public string TestingPeriod { get; set; }

        [Index]
        public DataContent DataArray { get; set; }
    }
}