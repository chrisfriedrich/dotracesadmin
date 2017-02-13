namespace DotRacesAdministration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixquestions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.dotraces_Questions", "QuestionRoundNum", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.dotraces_Questions", "QuestionRoundNum");
        }
    }
}
