namespace CS_GUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        GameId = c.Int(nullable: false, identity: true),
                        Date = c.String(),
                        NameVictory = c.String(),
                        HowStep = c.Int(nullable: false),
                        NowPlaying = c.Int(nullable: false),
                        PrevX = c.Boolean(nullable: false),
                        Repeat = c.Boolean(nullable: false),
                        GameField_Size = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GameId);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        PlayerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TotalVic = c.Int(nullable: false),
                        CurVic = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlayerId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Players");
            DropTable("dbo.Games");
        }
    }
}
