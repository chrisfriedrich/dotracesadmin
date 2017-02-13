namespace DotRacesAdministration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class otherdifference : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.dotraces_Races", "OtherDifference1", c => c.Double());
            AddColumn("dbo.dotraces_Races", "OtherDifference2", c => c.Double());
            AddColumn("dbo.dotraces_Races", "OtherDifference3", c => c.Double());
            AddColumn("dbo.dotraces_Races", "OtherDifference4", c => c.Double());
            AddColumn("dbo.dotraces_Races", "OtherDifference5", c => c.Double());
            AddColumn("dbo.dotraces_Races", "OtherDifference6", c => c.Double());
            AddColumn("dbo.dotraces_Races", "OtherDifference7", c => c.Double());
            AddColumn("dbo.dotraces_Races", "OtherDifference8", c => c.Double());
            AddColumn("dbo.dotraces_Races", "OtherDifference9", c => c.Double());
            AddColumn("dbo.dotraces_Races", "OtherDifference10", c => c.Double());
            AddColumn("dbo.dotraces_Races", "OtherDifference11", c => c.Double());
            AddColumn("dbo.dotraces_Races", "OtherDifference12", c => c.Double());
            AddColumn("dbo.dotraces_Races", "OtherDifference13", c => c.Double());
            AddColumn("dbo.dotraces_Races", "OtherDifference14", c => c.Double());
            AddColumn("dbo.dotraces_Races", "OtherDifference15", c => c.Double());
            AddColumn("dbo.dotraces_Races", "OtherDifference16", c => c.Double());
        }
        
        public override void Down()
        {
            DropColumn("dbo.dotraces_Races", "OtherDifference16");
            DropColumn("dbo.dotraces_Races", "OtherDifference15");
            DropColumn("dbo.dotraces_Races", "OtherDifference14");
            DropColumn("dbo.dotraces_Races", "OtherDifference13");
            DropColumn("dbo.dotraces_Races", "OtherDifference12");
            DropColumn("dbo.dotraces_Races", "OtherDifference11");
            DropColumn("dbo.dotraces_Races", "OtherDifference10");
            DropColumn("dbo.dotraces_Races", "OtherDifference9");
            DropColumn("dbo.dotraces_Races", "OtherDifference8");
            DropColumn("dbo.dotraces_Races", "OtherDifference7");
            DropColumn("dbo.dotraces_Races", "OtherDifference6");
            DropColumn("dbo.dotraces_Races", "OtherDifference5");
            DropColumn("dbo.dotraces_Races", "OtherDifference4");
            DropColumn("dbo.dotraces_Races", "OtherDifference3");
            DropColumn("dbo.dotraces_Races", "OtherDifference2");
            DropColumn("dbo.dotraces_Races", "OtherDifference1");
        }
    }
}
