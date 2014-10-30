namespace TestTcc2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMusica : DbMigration
    {
        public override void Up()
        {

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
            DropTable("dbo.Musicas");
        }
    }
}
