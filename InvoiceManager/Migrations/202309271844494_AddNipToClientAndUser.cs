namespace InvoiceManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNipToClientAndUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "Nip", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Nip", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Nip");
            DropColumn("dbo.Clients", "Nip");
        }
    }
}
