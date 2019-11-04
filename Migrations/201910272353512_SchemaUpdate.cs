namespace ContactsBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SchemaUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contacts", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.Contacts", "Email_Id", "dbo.Emails");
            DropForeignKey("dbo.Contacts", "Phone_Id", "dbo.Phones");
            DropIndex("dbo.Contacts", new[] { "Address_Id" });
            DropIndex("dbo.Contacts", new[] { "Email_Id" });
            DropIndex("dbo.Contacts", new[] { "Phone_Id" });
            AddColumn("dbo.Addresses", "ContactId", c => c.Byte(nullable: false));
            AddColumn("dbo.Emails", "ContactId", c => c.Byte(nullable: false));
            AddColumn("dbo.Phones", "ContactId", c => c.Byte(nullable: false));
            DropColumn("dbo.Contacts", "Address_Id");
            DropColumn("dbo.Contacts", "Email_Id");
            DropColumn("dbo.Contacts", "Phone_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "Phone_Id", c => c.Int());
            AddColumn("dbo.Contacts", "Email_Id", c => c.Int());
            AddColumn("dbo.Contacts", "Address_Id", c => c.Int());
            DropColumn("dbo.Phones", "ContactId");
            DropColumn("dbo.Emails", "ContactId");
            DropColumn("dbo.Addresses", "ContactId");
            CreateIndex("dbo.Contacts", "Phone_Id");
            CreateIndex("dbo.Contacts", "Email_Id");
            CreateIndex("dbo.Contacts", "Address_Id");
            AddForeignKey("dbo.Contacts", "Phone_Id", "dbo.Phones", "Id");
            AddForeignKey("dbo.Contacts", "Email_Id", "dbo.Emails", "Id");
            AddForeignKey("dbo.Contacts", "Address_Id", "dbo.Addresses", "Id");
        }
    }
}
