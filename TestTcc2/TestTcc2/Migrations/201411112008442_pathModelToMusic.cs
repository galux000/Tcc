namespace TestTcc2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pathModelToMusic : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Musicas", "path", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Musicas", "path");
        }
    }
}
