namespace TestTcc2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsuarioMusica_Add_GeneroID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UsuarioMusicas", "genero_GeneroId", "dbo.Generoes");
            DropIndex("dbo.UsuarioMusicas", new[] { "genero_GeneroId" });
            RenameColumn(table: "dbo.UsuarioMusicas", name: "genero_GeneroId", newName: "GeneroId");
            AddForeignKey("dbo.UsuarioMusicas", "GeneroId", "dbo.Generoes", "GeneroId", cascadeDelete: true);
            CreateIndex("dbo.UsuarioMusicas", "GeneroId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.UsuarioMusicas", new[] { "GeneroId" });
            DropForeignKey("dbo.UsuarioMusicas", "GeneroId", "dbo.Generoes");
            RenameColumn(table: "dbo.UsuarioMusicas", name: "GeneroId", newName: "genero_GeneroId");
            CreateIndex("dbo.UsuarioMusicas", "genero_GeneroId");
            AddForeignKey("dbo.UsuarioMusicas", "genero_GeneroId", "dbo.Generoes", "GeneroId");
        }
    }
}
