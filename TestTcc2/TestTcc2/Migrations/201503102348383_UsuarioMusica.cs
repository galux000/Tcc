namespace TestTcc2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsuarioMusica : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UsuarioMusicas",
                c => new
                    {
                        UsuarioMusicaId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        MusicaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioMusicaId)
                .ForeignKey("dbo.UserProfile", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Musicas", t => t.MusicaId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.MusicaId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UsuarioMusicas");
        }
    }
}
