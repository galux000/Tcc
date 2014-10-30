namespace TestTcc2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TypeUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfile", "UserType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserProfile", "UserType");
        }
    }
}
