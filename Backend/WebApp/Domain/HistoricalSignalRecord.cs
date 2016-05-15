using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class HistoricalSignalRecord
    {
        [Index]
        public int Id { get; set; }
        [Index]
        public Zodiac Zodiac { get; set; }
        [Index]
        public DateTime Date { get; set; }

        public string Ticker { get; set; }
        public string Type { get; set; }
        public DateTime Enter { get; set; }
        public DateTime Exit { get; set; }
        public string HoldingPeriod { get; set; }
        public double? Return { get; set; }

        [Index]
        public DataContent DataArray { get; set; }
    }
}
