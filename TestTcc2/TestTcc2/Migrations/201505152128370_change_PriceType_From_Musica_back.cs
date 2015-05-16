namespace TestTcc2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_PriceType_From_Musica_back : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Musicas", "Preco", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Musicas", "Preco", c => c.String());
        }
    }
}
