namespace DotRacesAdministration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class namechange : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.dotraces_Separators", newName: "dotraces_Separators");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.dotraces_Separators", newName: "dotraces_Separators");
        }
    }
}
