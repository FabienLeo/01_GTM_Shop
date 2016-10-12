namespace GTM_Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModificationAllValidationAttribute : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Adresses", "RueLigne02", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Adresses", "RueLigne02", c => c.String(nullable: false));
        }
    }
}
