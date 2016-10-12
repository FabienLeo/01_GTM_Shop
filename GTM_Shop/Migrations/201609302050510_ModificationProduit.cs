namespace GTM_Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModificationProduit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produits", "Visuel", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Produits", "Visuel");
        }
    }
}
