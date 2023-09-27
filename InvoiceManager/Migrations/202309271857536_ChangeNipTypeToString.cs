namespace InvoiceManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeNipTypeToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clients", "Nip", c => c.String());
            AlterColumn("dbo.AspNetUsers", "Nip", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Nip", c => c.Int(nullable: false));
            AlterColumn("dbo.Clients", "Nip", c => c.Int(nullable: false));
        }
    }
}
