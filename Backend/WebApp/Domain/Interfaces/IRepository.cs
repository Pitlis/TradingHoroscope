using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepository
    {
        int CreateSubscription(Subscription subscription);

        DataContent CreateDataContent(DataContent dContent);
        IList<DataContent> GetContentCards(string type);
        IList<FundOverviewChart> GetChartInfo(Zodiac zodiac);
        IList<HistoricalSignalRecord> GetHistoricalSignals(Zodiac zodiac);
        IDictionary<ZodiacFundOverview, FundFundOverview> GetFundOverview(Zodiac zodiac);

        void CreateDailyHoroscopeRecords(IList<DailyHoroscopeRecord> records);
        void CreateZodiacFundOverview(IList<ZodiacFundOverview> records);
        void CreateFundFundOverview(IList<FundFundOverview> records);
        void CreateHistoricalSignals(IList<HistoricalSignalRecord> records);
        void CreateChartData(IList<FundOverviewChart> records);
        void CreateNewsLetters(IList<NewsLetter> records);

        DailyHoroscopeRecord GetTodayHoroscope(Zodiac zodiac);

        void RemoveDataContent(int dcId);
    }
}
