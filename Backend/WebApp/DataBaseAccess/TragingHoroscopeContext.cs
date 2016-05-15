using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseAccess
{
    class TragingHoroscopeContext : DbContext
    {
        public TragingHoroscopeContext() : base("name=TradingHoroscopeDataBase")
        {
            Database.SetInitializer<TragingHoroscopeContext>(new CreateDatabaseIfNotExists<TragingHoroscopeContext>());
        }

        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<DataContent> DataContents { get; set; }

        public DbSet<DailyHoroscopeRecord> DailyHoroscopeRecords { get; set; }
        public DbSet<ZodiacFundOverview> ZodiacFundOverviews { get; set; }
        public DbSet<FundFundOverview> FundFundOverviews { get; set; }
        public DbSet<HistoricalSignalRecord> HistoricalSignalRecords { get; set; }
        public DbSet<FundOverviewChart> FundOverviewCharts { get; set; }
        public DbSet<NewsLetter> NewsLetters { get; set; }
    }
}
