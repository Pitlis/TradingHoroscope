using Domain;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseAccess
{
    public class Repository : IRepository
    {
        public DailyHoroscopeRecord GetTodayHoroscope(Zodiac zodiac)
        {
            using (var ctx = new TragingHoroscopeContext())
            {
                var todayHoroscope = ctx.DailyHoroscopeRecords.Where(
                    h => h.Zodiac == zodiac &&
                    DbFunctions.TruncateTime(h.Date) == DateTime.Today.Date
                    ).FirstOrDefault();

                if(todayHoroscope == null)
                {
                    todayHoroscope = ctx.DailyHoroscopeRecords.Where(h => h.Zodiac == zodiac && DbFunctions.TruncateTime(h.Date) <= DateTime.Today.Date).OrderByDescending(h => h.Date).FirstOrDefault();
                    if(todayHoroscope != null)
                    {
                        return todayHoroscope;
                    }
                    else
                    {
                        return new DailyHoroscopeRecord()
                        {
                            Id = -1,
                            Zodiac = zodiac,
                            Date = DateTime.Today,
                            Ticker = "N/A",
                            Analysis = "N/A",
                            Enter = "N/A",
                            Exit = "N/A",
                            HoldingPeriod = "N/A",
                            TestingPeriod = "N/A"
                        };
                    }
                }
                else
                {
                    return todayHoroscope;
                }
            }
        }

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
            catch (Exception ex)
            {
                return -1;
            }
        }

        public DataContent CreateDataContent(DataContent dContent)
        {
            using (var ctx = new TragingHoroscopeContext())
            {
                ctx.DataContents.Add(dContent);
                ctx.SaveChanges();

                return dContent;
            }
        }
        public IList<DataContent> GetContentCards(string type)
        {
            using (var ctx = new TragingHoroscopeContext())
            {
                List<DataContent> result = new List<DataContent>();
                switch (type)
                {
                    case "DailyHoroscope":
                        result = (from dc in ctx.DataContents
                                  join r in ctx.DailyHoroscopeRecords on dc.Id equals r.DataArray.Id
                                  select dc).Distinct().ToList();
                        break;
                    case "ZodiacFundOverview":
                        result = (from dc in ctx.DataContents
                                  join r in ctx.ZodiacFundOverviews on dc.Id equals r.DataArray.Id
                                  select dc).Distinct().ToList();
                        break;
                    case "FundFundOverview":
                        result = (from dc in ctx.DataContents
                                  join r in ctx.FundFundOverviews on dc.Id equals r.DataArray.Id
                                  select dc).Distinct().ToList();
                        break;
                    case "HistoricalSignals":
                        result = (from dc in ctx.DataContents
                                  join r in ctx.HistoricalSignalRecords on dc.Id equals r.DataArray.Id
                                  select dc).Distinct().ToList();
                        break;
                    case "ChartData":
                        result = (from dc in ctx.DataContents
                                  join r in ctx.FundOverviewCharts on dc.Id equals r.DataArray.Id
                                  select dc).Distinct().ToList();
                        break;
                    case "NewsLetters":
                        result = (from dc in ctx.DataContents
                                  join r in ctx.NewsLetters on dc.Id equals r.DataArray.Id
                                  select dc).Distinct().ToList();
                        break;
                    default:
                        break;
                }
                return result;
            }
        }

        #region add data
        public void CreateDailyHoroscopeRecords(IList<DailyHoroscopeRecord> records)
        {
            using (var ctx = new TragingHoroscopeContext())
            {
                using (var transaction = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        DataContent dc = ctx.DataContents.Add(records[0].DataArray);
                        foreach (var item in records)
                        {
                            item.DataArray = dc;
                        }
                        ctx.DailyHoroscopeRecords.AddRange(records);
                        ctx.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                    }
                }
            }
        }
        public void CreateZodiacFundOverview(IList<ZodiacFundOverview> records)
        {
            using (var ctx = new TragingHoroscopeContext())
            {
                using (var transaction = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        DataContent dc = ctx.DataContents.Add(records[0].DataArray);
                        foreach (var item in records)
                        {
                            item.DataArray = dc;
                        }
                        ctx.ZodiacFundOverviews.AddRange(records);
                        ctx.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                    }
                }
            }
        }
        public void CreateFundFundOverview(IList<FundFundOverview> records)
        {
            using (var ctx = new TragingHoroscopeContext())
            {
                using (var transaction = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        DataContent dc = ctx.DataContents.Add(records[0].DataArray);
                        foreach (var item in records)
                        {
                            item.DataArray = dc;
                        }
                        ctx.FundFundOverviews.AddRange(records);
                        ctx.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                    }
                }
            }
        }
        public void CreateHistoricalSignals(IList<HistoricalSignalRecord> records)
        {
            using (var ctx = new TragingHoroscopeContext())
            {
                using (var transaction = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        DataContent dc = ctx.DataContents.Add(records[0].DataArray);
                        foreach (var item in records)
                        {
                            item.DataArray = dc;
                        }
                        ctx.HistoricalSignalRecords.AddRange(records);
                        ctx.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                    }
                }
            }
        }
        public void CreateChartData(IList<FundOverviewChart> records)
        {
            using (var ctx = new TragingHoroscopeContext())
            {
                using (var transaction = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        DataContent dc = ctx.DataContents.Add(records[0].DataArray);
                        foreach (var item in records)
                        {
                            item.DataArray = dc;
                        }
                        ctx.FundOverviewCharts.AddRange(records);
                        ctx.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                    }
                }
            }
        }
        public void CreateNewsLetters(IList<NewsLetter> records)
        {
            using (var ctx = new TragingHoroscopeContext())
            {
                using (var transaction = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        DataContent dc = ctx.DataContents.Add(records[0].DataArray);
                        foreach (var item in records)
                        {
                            item.DataArray = dc;
                        }
                        ctx.NewsLetters.AddRange(records);
                        ctx.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                    }
                }
            }
        }

        #endregion

        public void RemoveDataContent(int dcId)
        {
            using (var ctx = new TragingHoroscopeContext())
            {
                ctx.DailyHoroscopeRecords.RemoveRange(ctx.DailyHoroscopeRecords.Where(r => r.DataArray.Id == dcId));
                ctx.FundFundOverviews.RemoveRange(ctx.FundFundOverviews.Where(r => r.DataArray.Id == dcId));
                ctx.ZodiacFundOverviews.RemoveRange(ctx.ZodiacFundOverviews.Where(r => r.DataArray.Id == dcId));
                ctx.HistoricalSignalRecords.RemoveRange(ctx.HistoricalSignalRecords.Where(r => r.DataArray.Id == dcId));
                ctx.FundOverviewCharts.RemoveRange(ctx.FundOverviewCharts.Where(r => r.DataArray.Id == dcId));
                ctx.NewsLetters.RemoveRange(ctx.NewsLetters.Where(r => r.DataArray.Id == dcId));

                ctx.DataContents.RemoveRange(ctx.DataContents.Where(r => r.Id == dcId));

                ctx.SaveChanges();
            }
        }

        #region horoscope details info

        public IList<FundOverviewChart> GetChartInfo(Zodiac zodiac)
        {
            using (var ctx = new TragingHoroscopeContext())
            {
                var chartInfo = ctx.FundOverviewCharts.Where(
                    h => h.Zodiac == zodiac &&
                    h.Date <= DateTime.Today
                    ).ToList();
                return chartInfo;
            }
        }
        public IList<HistoricalSignalRecord> GetHistoricalSignals(Zodiac zodiac)
        {
            using (var ctx = new TragingHoroscopeContext())
            {
                var historicalSignals = ctx.HistoricalSignalRecords.Where(
                    h => h.Zodiac == zodiac
                    ).ToList();
                return historicalSignals;
            }
        }
        public IDictionary<ZodiacFundOverview, FundFundOverview> GetFundOverview(Zodiac zodiac)
        {
            Dictionary<ZodiacFundOverview, FundFundOverview> result = new Dictionary<ZodiacFundOverview, FundFundOverview>();
            using (var ctx = new TragingHoroscopeContext())
            {
                var fundFundOverview = ctx.FundFundOverviews.ToList();
                var zodiacFundOverview = ctx.ZodiacFundOverviews.Where(h => h.Zodiac == zodiac).ToList();
                int count = fundFundOverview.Count < zodiacFundOverview.Count ? fundFundOverview.Count : zodiacFundOverview.Count;
                for (int yearIndex = 0; yearIndex < count; yearIndex++)
                {
                    result.Add(zodiacFundOverview[yearIndex], fundFundOverview[yearIndex]);
                }
                return result;
            }
        }

        #endregion
    }
}
