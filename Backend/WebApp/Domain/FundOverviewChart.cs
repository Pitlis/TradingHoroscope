﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class FundOverviewChart
    {
        [Index]
        public int Id { get; set; }
        [Index]
        public Zodiac Zodiac { get; set; }
        [Index]
        public DateTime Date { get; set; }

        public double Fund { get; set; }
        public double SP500 { get; set; }

        [Index]
        public DataContent DataArray { get; set; }
    }
}
