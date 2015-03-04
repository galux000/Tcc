namespace TestTcc2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMusicaTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Musicas", "UserName_UserId", c => c.Int());
            AlterColumn("dbo.Musicas", "Preco", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddForeignKey("dbo.Musicas", "UserName_UserId", "dbo.UserProfile", "UserId");
            CreateIndex("dbo.Musicas", "UserName_UserId");
            DropColumn("dbo.Musicas", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Musicas", "UserId", c => c.Int(nullable: false));
            DropIndex("dbo.Musicas", new[] { "UserName_UserId" });
            DropForeignKey("dbo.Musicas", "UserName_UserId", "dbo.UserProfile");
            AlterColumn("dbo.Musicas", "Preco", c => c.Int(nullable: false));
            DropColumn("dbo.Musicas", "UserName_UserId");
        }
    }
}
