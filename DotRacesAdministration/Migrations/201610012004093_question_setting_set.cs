namespace DotRacesAdministration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class question_setting_set : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.dotraces_Questions", "SettingSetID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.dotraces_Questions", "SettingSetID");
        }
    }
}
