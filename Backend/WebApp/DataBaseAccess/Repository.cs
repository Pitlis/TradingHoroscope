using Domain;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseAccess
{
    public class Repository: IRepository
    {
        public int CreateSubscription(Subscription s)
        {
            try
            {
                using (var ctx = new TragingHoroscopeContext())
                {
                    var ss = (from sub in ctx.Subscriptions select sub).ToList();
                    ctx.SaveChanges();
                    int result = s.Id;

                    return result;
                }
            }
            catch(Exception ex)
            {
                return -1;
            }
        }
    }
}
