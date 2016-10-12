namespace GTM_Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModificationCammande : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Commandes", "Commentaire", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Commandes", "Commentaire", c => c.String(nullable: false));
        }
    }
}
