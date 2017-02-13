namespace DotRacesAdministration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class osutables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.dotraces_OSUAnswers",
                c => new
                    {
                        AnswerID = c.Int(nullable: false, identity: true),
                        SurveyID = c.Int(nullable: false),
                        QuestionID = c.Int(nullable: false),
                        AnswerFlag = c.Boolean(),
                        AnswerValue = c.Int(),
                    })
                .PrimaryKey(t => t.AnswerID);
            
            CreateTable(
                "dbo.dotraces_OSUSurveys",
                c => new
                    {
                        SurveyID = c.Int(nullable: false, identity: true),
                        CreatedDate = c.DateTime(nullable: false),
                        IdentityCode = c.Int(),
                        SettingsID = c.Int(nullable: false),
                        PointTotal = c.Int(),
                        ChoseToBetFlag = c.Boolean(),
                        OSUWins = c.Int(),
                        UOWins = c.Int(),
                    })
                .PrimaryKey(t => t.SurveyID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.dotraces_OSUSurveys");
            DropTable("dbo.dotraces_OSUAnswers");
        }
    }
}
