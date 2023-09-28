namespace InvoiceManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TurnOffCascadeOnDeleteProductInvoicePositions : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InvoicePositions", "ProductId", "dbo.Products");
            AddForeignKey("dbo.InvoicePositions", "ProductId", "dbo.Products", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InvoicePositions", "ProductId", "dbo.Products");
            AddForeignKey("dbo.InvoicePositions", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
