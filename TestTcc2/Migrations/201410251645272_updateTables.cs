namespace TestTcc2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Albums", "ArtistaId", "dbo.Artistas");
            DropIndex("dbo.Albums", new[] { "ArtistaId" });
            RenameColumn(table: "dbo.Albums", name: "ArtistaId", newName: "Artista_ArtistaId");
            AddColumn("dbo.Albums", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Musicas", "UserId", c => c.Int(nullable: false));
            AddForeignKey("dbo.Albums", "Artista_ArtistaId", "dbo.Artistas", "ArtistaId");
            AddForeignKey("dbo.Musicas", "GeneroId", "dbo.Generoes", "GeneroId", cascadeDelete: true);
            CreateIndex("dbo.Albums", "Artista_ArtistaId");
            CreateIndex("dbo.Musicas", "GeneroId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Musicas", new[] { "GeneroId" });
            DropIndex("dbo.Albums", new[] { "Artista_ArtistaId" });
            DropForeignKey("dbo.Musicas", "GeneroId", "dbo.Generoes");
            DropForeignKey("dbo.Albums", "Artista_ArtistaId", "dbo.Artistas");
            DropColumn("dbo.Musicas", "UserId");
            DropColumn("dbo.Albums", "UserId");
            RenameColumn(table: "dbo.Albums", name: "Artista_ArtistaId", newName: "ArtistaId");
            CreateIndex("dbo.Albums", "ArtistaId");
            AddForeignKey("dbo.Albums", "ArtistaId", "dbo.Artistas", "ArtistaId", cascadeDelete: true);
        }
    }
}
