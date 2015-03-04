namespace TestTcc2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteAlbumClass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Albums", "GeneroId", "dbo.Generoes");
          //  DropForeignKey("dbo.Albums", "Artista_ArtistaId", "dbo.Artistas");
            DropIndex("dbo.Albums", new[] { "GeneroId" });
           // DropIndex("dbo.Albums", new[] { "Artista_ArtistaId" });
            DropTable("dbo.Albums");
            //DropTable("dbo.Artistas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Artistas",
                c => new
                    {
                        ArtistaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.ArtistaId);
            
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        AlbumId = c.Int(nullable: false, identity: true),
                        GeneroId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Titulo = c.String(),
                        ImagemAlbum = c.String(),
                        Artista_ArtistaId = c.Int(),
                    })
                .PrimaryKey(t => t.AlbumId);
            
            //CreateIndex("dbo.Albums", "Artista_ArtistaId");
            CreateIndex("dbo.Albums", "GeneroId");
           // AddForeignKey("dbo.Albums", "Artista_ArtistaId", "dbo.Artistas", "ArtistaId");
            AddForeignKey("dbo.Albums", "GeneroId", "dbo.Generoes", "GeneroId", cascadeDelete: true);
        }
    }
}
