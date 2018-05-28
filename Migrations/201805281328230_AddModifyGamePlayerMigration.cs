namespace CS_GUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModifyGamePlayerMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Games", "NowPlaying");
            DropColumn("dbo.Games", "PrevX");
            DropColumn("dbo.Games", "Repeat");
            DropColumn("dbo.Games", "GameField_Size");
            DropColumn("dbo.Players", "CurVic");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Players", "CurVic", c => c.Int(nullable: false));
            AddColumn("dbo.Games", "GameField_Size", c => c.Int(nullable: false));
            AddColumn("dbo.Games", "Repeat", c => c.Boolean(nullable: false));
            AddColumn("dbo.Games", "PrevX", c => c.Boolean(nullable: false));
            AddColumn("dbo.Games", "NowPlaying", c => c.Int(nullable: false));
        }
    }
}
