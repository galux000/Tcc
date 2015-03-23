namespace TestTcc2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateUsuarioMusica : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UsuarioMusicas", "Nome", c => c.String());
            AddColumn("dbo.UsuarioMusicas", "NomeArtista", c => c.String());
            AddColumn("dbo.UsuarioMusicas", "path", c => c.String());
            AddColumn("dbo.UsuarioMusicas", "genero_GeneroId", c => c.Int());
            AddForeignKey("dbo.UsuarioMusicas", "genero_GeneroId", "dbo.Generoes", "GeneroId");
            CreateIndex("dbo.UsuarioMusicas", "genero_GeneroId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.UsuarioMusicas", new[] { "genero_GeneroId" });
            DropForeignKey("dbo.UsuarioMusicas", "genero_GeneroId", "dbo.Generoes");
            DropColumn("dbo.UsuarioMusicas", "genero_GeneroId");
            DropColumn("dbo.UsuarioMusicas", "path");
            DropColumn("dbo.UsuarioMusicas", "NomeArtista");
            DropColumn("dbo.UsuarioMusicas", "Nome");
        }
    }
}
