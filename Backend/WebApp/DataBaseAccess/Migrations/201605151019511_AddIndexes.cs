namespace DataBaseAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIndexes : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.DailyHoroscopeRecords", "Id");
            CreateIndex("dbo.DailyHoroscopeRecords", "Zodiac");
            CreateIndex("dbo.DailyHoroscopeRecords", "Date");
            CreateIndex("dbo.FundFundOverviews", "Id");
            CreateIndex("dbo.FundFundOverviews", "Year");
            CreateIndex("dbo.FundOverviewCharts", "Id");
            CreateIndex("dbo.FundOverviewCharts", "Zodiac");
            CreateIndex("dbo.FundOverviewCharts", "Date");
            CreateIndex("dbo.HistoricalSignalRecords", "Id");
            CreateIndex("dbo.HistoricalSignalRecords", "Zodiac");
            CreateIndex("dbo.HistoricalSignalRecords", "Date");
            CreateIndex("dbo.NewsLetters", "Id");
            CreateIndex("dbo.NewsLetters", "Zodiac");
            CreateIndex("dbo.NewsLetters", "Date");
            CreateIndex("dbo.ZodiacFundOverviews", "Id");
            CreateIndex("dbo.ZodiacFundOverviews", "Zodiac");
            CreateIndex("dbo.ZodiacFundOverviews", "Year");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ZodiacFundOverviews", new[] { "Year" });
            DropIndex("dbo.ZodiacFundOverviews", new[] { "Zodiac" });
            DropIndex("dbo.ZodiacFundOverviews", new[] { "Id" });
            DropIndex("dbo.NewsLetters", new[] { "Date" });
            DropIndex("dbo.NewsLetters", new[] { "Zodiac" });
            DropIndex("dbo.NewsLetters", new[] { "Id" });
            DropIndex("dbo.HistoricalSignalRecords", new[] { "Date" });
            DropIndex("dbo.HistoricalSignalRecords", new[] { "Zodiac" });
            DropIndex("dbo.HistoricalSignalRecords", new[] { "Id" });
            DropIndex("dbo.FundOverviewCharts", new[] { "Date" });
            DropIndex("dbo.FundOverviewCharts", new[] { "Zodiac" });
            DropIndex("dbo.FundOverviewCharts", new[] { "Id" });
            DropIndex("dbo.FundFundOverviews", new[] { "Year" });
            DropIndex("dbo.FundFundOverviews", new[] { "Id" });
            DropIndex("dbo.DailyHoroscopeRecords", new[] { "Date" });
            DropIndex("dbo.DailyHoroscopeRecords", new[] { "Zodiac" });
            DropIndex("dbo.DailyHoroscopeRecords", new[] { "Id" });
        }
    }
}
