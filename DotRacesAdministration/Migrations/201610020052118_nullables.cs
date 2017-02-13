namespace DotRacesAdministration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullables : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.dotraces_Questions", "FinalGroupQuestion", c => c.Boolean());
            AlterColumn("dbo.dotraces_Questions", "GroupQuestionNumber", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.dotraces_Questions", "GroupQuestionNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.dotraces_Questions", "FinalGroupQuestion", c => c.Boolean(nullable: false));
        }
    }
}
