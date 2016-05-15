using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class NewsLetter
    {
        [Index]
        public int Id { get; set; }
        [Index]
        public Zodiac Zodiac { get; set; }
        public string Content { get; set; }
        [Index]
        public DateTime Date { get; set; }

        [Index]
        public DataContent DataArray { get; set; }
    }
}
