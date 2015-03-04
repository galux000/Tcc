namespace TestTcc2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MusicFree : DbMigration
    {
        public override void Up()
        {
           // DropForeignKey("dbo.Musicas", "UserName_UserId", "dbo.UserProfile");
            //DropIndex("dbo.Musicas", new[] { "UserName_UserId" });
         //   AddColumn("dbo.Musicas", "UserId", c => c.Int(nullable: false));
           // AddColumn("dbo.Musicas", "NomeArtista", c => c.String());
            AddColumn("dbo.Musicas", "isFree", c => c.Boolean(nullable: false));
            //DropColumn("dbo.Musicas", "UserName_UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Musicas", "UserName_UserId", c => c.Int());
            DropColumn("dbo.Musicas", "isFree");
            DropColumn("dbo.Musicas", "NomeArtista");
            DropColumn("dbo.Musicas", "UserId");
            CreateIndex("dbo.Musicas", "UserName_UserId");
            //AddForeignKey("dbo.Musicas", "UserName_UserId", "dbo.UserProfile", "UserId");
        }
    }
}
