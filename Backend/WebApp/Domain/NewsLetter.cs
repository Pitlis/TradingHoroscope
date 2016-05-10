using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class NewsLetter
    {
        public int Id { get; set; }
        public Zodiac Zodiac { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        
        public DataContent DataArray { get; set; }
    }
}
