namespace DataBaseAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DailyHoroscopeRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Zodiac = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Ticker = c.String(),
                        Analysis = c.String(),
                        Enter = c.String(),
                        Exit = c.String(),
                        HoldingPeriod = c.String(),
                        AvgHistReturn = c.Double(),
                        SuccessRate = c.Double(),
                        TestingPeriod = c.String(),
                        DataArray_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DataContents", t => t.DataArray_Id)
                .Index(t => t.DataArray_Id);
            
            CreateTable(
                "dbo.DataContents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoadedDate = c.DateTime(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FundFundOverviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        TotalFundReturn = c.Double(),
                        AvgSignalsReturn = c.Double(),
                        ProfitableSignals = c.Double(),
                        DataArray_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DataContents", t => t.DataArray_Id)
                .Index(t => t.DataArray_Id);
            
            CreateTable(
                "dbo.FundOverviewCharts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Zodiac = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Fund = c.Double(nullable: false),
                        SP500 = c.Double(nullable: false),
                        DataArray_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DataContents", t => t.DataArray_Id)
                .Index(t => t.DataArray_Id);
            
            CreateTable(
                "dbo.HistoricalSignalRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Zodiac = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Ticker = c.String(),
                        Type = c.String(),
                        Enter = c.DateTime(nullable: false),
                        Exit = c.DateTime(nullable: false),
                        HoldingPeriod = c.String(),
                        Return = c.Double(),
                        DataArray_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DataContents", t => t.DataArray_Id)
                .Index(t => t.DataArray_Id);
            
            CreateTable(
                "dbo.NewsLetters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Zodiac = c.Int(nullable: false),
                        Content = c.String(),
                        Date = c.DateTime(nullable: false),
                        DataArray_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DataContents", t => t.DataArray_Id)
                .Index(t => t.DataArray_Id);
            
            CreateTable(
                "dbo.Subscriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Zodiac = c.Int(nullable: false),
                        OfferSended = c.Boolean(nullable: false),
                        SubcrtiptionApproved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ZodiacFundOverviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Zodiac = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        TotalFundReturn = c.Double(),
                        AvgSignalsReturn = c.Double(),
                        ProfitableSignals = c.Double(),
                        DataArray_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DataContents", t => t.DataArray_Id)
                .Index(t => t.DataArray_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ZodiacFundOverviews", "DataArray_Id", "dbo.DataContents");
            DropForeignKey("dbo.NewsLetters", "DataArray_Id", "dbo.DataContents");
            DropForeignKey("dbo.HistoricalSignalRecords", "DataArray_Id", "dbo.DataContents");
            DropForeignKey("dbo.FundOverviewCharts", "DataArray_Id", "dbo.DataContents");
            DropForeignKey("dbo.FundFundOverviews", "DataArray_Id", "dbo.DataContents");
            DropForeignKey("dbo.DailyHoroscopeRecords", "DataArray_Id", "dbo.DataContents");
            DropIndex("dbo.ZodiacFundOverviews", new[] { "DataArray_Id" });
            DropIndex("dbo.NewsLetters", new[] { "DataArray_Id" });
            DropIndex("dbo.HistoricalSignalRecords", new[] { "DataArray_Id" });
            DropIndex("dbo.FundOverviewCharts", new[] { "DataArray_Id" });
            DropIndex("dbo.FundFundOverviews", new[] { "DataArray_Id" });
            DropIndex("dbo.DailyHoroscopeRecords", new[] { "DataArray_Id" });
            DropTable("dbo.ZodiacFundOverviews");
            DropTable("dbo.Subscriptions");
            DropTable("dbo.NewsLetters");
            DropTable("dbo.HistoricalSignalRecords");
            DropTable("dbo.FundOverviewCharts");
            DropTable("dbo.FundFundOverviews");
            DropTable("dbo.DataContents");
            DropTable("dbo.DailyHoroscopeRecords");
        }
    }
}
