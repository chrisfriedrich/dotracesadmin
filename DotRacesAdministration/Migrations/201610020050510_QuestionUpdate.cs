namespace DotRacesAdministration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuestionUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.dotraces_Questions", "FinalGroupQuestion", c => c.Boolean(nullable: false));
            AddColumn("dbo.dotraces_Questions", "GroupQuestionNumber", c => c.Int(nullable: false));
            DropColumn("dbo.dotraces_Questions", "EnjoymentGroupQuestion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.dotraces_Questions", "EnjoymentGroupQuestion", c => c.Boolean(nullable: false));
            DropColumn("dbo.dotraces_Questions", "GroupQuestionNumber");
            DropColumn("dbo.dotraces_Questions", "FinalGroupQuestion");
        }
    }
}
