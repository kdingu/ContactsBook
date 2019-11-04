namespace ContactsBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRelationshipKeys3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "Contact_Id", c => c.Int());
            AddColumn("dbo.Emails", "Contact_Id", c => c.Int());
            AddColumn("dbo.Phones", "Contact_Id", c => c.Int());
            CreateIndex("dbo.Addresses", "Contact_Id");
            CreateIndex("dbo.Emails", "Contact_Id");
            CreateIndex("dbo.Phones", "Contact_Id");
            AddForeignKey("dbo.Addresses", "Contact_Id", "dbo.Contacts", "Id");
            AddForeignKey("dbo.Emails", "Contact_Id", "dbo.Contacts", "Id");
            AddForeignKey("dbo.Phones", "Contact_Id", "dbo.Contacts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Phones", "Contact_Id", "dbo.Contacts");
            DropForeignKey("dbo.Emails", "Contact_Id", "dbo.Contacts");
            DropForeignKey("dbo.Addresses", "Contact_Id", "dbo.Contacts");
            DropIndex("dbo.Phones", new[] { "Contact_Id" });
            DropIndex("dbo.Emails", new[] { "Contact_Id" });
            DropIndex("dbo.Addresses", new[] { "Contact_Id" });
            DropColumn("dbo.Phones", "Contact_Id");
            DropColumn("dbo.Emails", "Contact_Id");
            DropColumn("dbo.Addresses", "Contact_Id");
        }
    }
}
