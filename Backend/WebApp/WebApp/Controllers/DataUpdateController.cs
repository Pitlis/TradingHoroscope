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
    [Authorize(Roles = "admin")]
    public class DataUpdateController : ApiController
    {
        IRepository repo = new Repository();

        [HttpPost]
        [Route("api/DataUpdate/DailyHoroscope")]
        public void DailyHoroscope([FromBody]IList<DailyHoroscopeRecord> rows)
        {
            repo.CreateDailyHoroscopeRecords(rows);
        }

        [HttpPost]
        [Route("api/DataUpdate/ZodiacFundOverview")]
        public void ZodiacFundOverview([FromBody]IList<ZodiacFundOverview> rows)
        {
            repo.CreateZodiacFundOverview(rows);
        }

        [HttpPost]
        [Route("api/DataUpdate/FundFundOverview")]
        public void FundFundOverview([FromBody]IList<FundFundOverview> rows)
        {
            repo.CreateFundFundOverview(rows);
        }

        [HttpPost]
        [Route("api/DataUpdate/HistoricalSignals")]
        public void HistoricalSignals([FromBody]IList<HistoricalSignalRecord> rows)
        {
            repo.CreateHistoricalSignals(rows);
        }

        [HttpPost]
        [Route("api/DataUpdate/ChartData")]
        public void ChartData([FromBody]IList<FundOverviewChart> rows)
        {
            repo.CreateChartData(rows);
        }
        [HttpPost]
        [Route("api/DataUpdate/NewsLetters")]
        public void NewsLetters([FromBody]IList<NewsLetter> rows)
        {
            repo.CreateNewsLetters(rows);
        }

        // DELETE: api/DataUpdate/5
        [HttpDelete]
        public void Delete(int id)
        {
            try
            {
                repo.RemoveDataContent(id);
            }
            catch(Exception ex)
            {

            }
        }
    }
}
