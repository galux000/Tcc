namespace TestTcc2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        AlbumId = c.Int(nullable: false, identity: true),
                        GeneroId = c.Int(nullable: false),
                        ArtistaId = c.Int(nullable: false),
                        Titulo = c.String(),
                        ImagemAlbum = c.String(),
                    })
                .PrimaryKey(t => t.AlbumId)
                .ForeignKey("dbo.Generoes", t => t.GeneroId, cascadeDelete: true)
                .ForeignKey("dbo.Artistas", t => t.ArtistaId, cascadeDelete: true)
                .Index(t => t.GeneroId)
                .Index(t => t.ArtistaId);
            
            CreateTable(
                "dbo.Generoes",
                c => new
                    {
                        GeneroId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.GeneroId);
            
            CreateTable(
                "dbo.Artistas",
                c => new
                    {
                        ArtistaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.ArtistaId);
            
            CreateTable(
                "dbo.Musicas",
                c => new
                    {
                        MusicaId = c.Int(nullable: false, identity: true),
                        GeneroId = c.Int(nullable: false),
                        ArtistaId = c.Int(nullable: false),
                        Nome = c.String(),
                        Preco = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MusicaId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Albums", new[] { "ArtistaId" });
            DropIndex("dbo.Albums", new[] { "GeneroId" });
            DropForeignKey("dbo.Albums", "ArtistaId", "dbo.Artistas");
            DropForeignKey("dbo.Albums", "GeneroId", "dbo.Generoes");
            DropTable("dbo.Musicas");
            DropTable("dbo.Artistas");
            DropTable("dbo.Generoes");
            DropTable("dbo.Albums");
        }
    }
}
