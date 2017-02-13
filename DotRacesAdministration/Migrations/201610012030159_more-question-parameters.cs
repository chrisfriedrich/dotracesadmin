namespace DotRacesAdministration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class morequestionparameters : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.dotraces_Questions", "HasFollowUp", c => c.Boolean(nullable: false));
            AddColumn("dbo.dotraces_Questions", "FollowUpText", c => c.String());
            AddColumn("dbo.dotraces_Questions", "FeelingNoun", c => c.String());
            AddColumn("dbo.dotraces_Questions", "LowScaleDescription", c => c.String());
            AddColumn("dbo.dotraces_Questions", "HighScaleDescription", c => c.String());
            AddColumn("dbo.dotraces_Questions", "EnjoymentGroupQuestion", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.dotraces_Questions", "EnjoymentGroupQuestion");
            DropColumn("dbo.dotraces_Questions", "HighScaleDescription");
            DropColumn("dbo.dotraces_Questions", "LowScaleDescription");
            DropColumn("dbo.dotraces_Questions", "FeelingNoun");
            DropColumn("dbo.dotraces_Questions", "FollowUpText");
            DropColumn("dbo.dotraces_Questions", "HasFollowUp");
        }
    }
}
