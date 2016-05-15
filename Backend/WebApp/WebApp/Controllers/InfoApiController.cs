using DataBaseAccess;
using Domain;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApp.Controllers
{
    public class InfoApiController : ApiController
    {
        IRepository repo = new Repository();

        [HttpGet]
        [Route("api/InfoApi/chartInfo/{zodiac}")]
        public IList<FundOverviewChart> GetChartInfo(string zodiac)
        {
            IList<FundOverviewChart> result = new List<FundOverviewChart>();
            try
            {
                Zodiac z = (Zodiac)Enum.Parse(typeof(Zodiac), zodiac);
                result = repo.GetChartInfo(z);
            }
            catch
            {
            }
            return result;
        }

        [HttpGet]
        [Route("api/InfoApi/historicalSignals/{zodiac}")]
        public IList<HistoricalSignalRecord> GetHistoricalSignals(string zodiac)
        {
            IList<HistoricalSignalRecord> result = new List<HistoricalSignalRecord>();
            try
            {
                Zodiac z = (Zodiac)Enum.Parse(typeof(Zodiac), zodiac);
                result = repo.GetHistoricalSignals(z);
            }
            catch
            {
            }
            return result;
        }

        [HttpGet]
        [Route("api/InfoApi/fundOverview/{zodiac}")]
        public List<KeyValuePair<ZodiacFundOverview, FundFundOverview>> GetFundOverview(string zodiac)
        {
            List< KeyValuePair < ZodiacFundOverview, FundFundOverview>> result = new List<KeyValuePair<ZodiacFundOverview, FundFundOverview>>();
            try
            {
                Zodiac z = (Zodiac)Enum.Parse(typeof(Zodiac), zodiac);
                result = repo.GetFundOverview(z).ToList<KeyValuePair<ZodiacFundOverview, FundFundOverview>>();
            }
            catch(Exception ex)
            {
            }
            return result;
        }
    }
}
