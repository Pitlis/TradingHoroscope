using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Subscription
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public Zodiac Zodiac { get; set; }

        public bool OfferSended { get; set; }
        public bool SubcrtiptionApproved { get; set; }
    }
}
