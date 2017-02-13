namespace DotRacesAdministration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class separators : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Separators",
                c => new
                    {
                        SeparatorID = c.Int(nullable: false, identity: true),
                        CurrentVersion = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SeparatorID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Separators");
        }
    }
}
