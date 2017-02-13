namespace DotRacesAdministration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class surveywins : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.dotraces_Surveys", "OSUWins", c => c.Int());
            AddColumn("dbo.dotraces_Surveys", "UOWins", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.dotraces_Surveys", "UOWins");
            DropColumn("dbo.dotraces_Surveys", "OSUWins");
        }
    }
}
