namespace ContactsBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TryInsertData : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contacts", "AddressID", "dbo.Addresses");
            DropForeignKey("dbo.Contacts", "EmailId", "dbo.Emails");
            DropForeignKey("dbo.Contacts", "PhoneId", "dbo.Phones");
            DropIndex("dbo.Contacts", new[] { "EmailId" });
            DropIndex("dbo.Contacts", new[] { "PhoneId" });
            DropIndex("dbo.Contacts", new[] { "AddressID" });
            RenameColumn(table: "dbo.Contacts", name: "AddressID", newName: "Address_Id");
            RenameColumn(table: "dbo.Contacts", name: "EmailId", newName: "Email_Id");
            RenameColumn(table: "dbo.Contacts", name: "PhoneId", newName: "Phone_Id");
            AlterColumn("dbo.Contacts", "Email_Id", c => c.Int());
            AlterColumn("dbo.Contacts", "Phone_Id", c => c.Int());
            AlterColumn("dbo.Contacts", "Address_Id", c => c.Int());
            CreateIndex("dbo.Contacts", "Address_Id");
            CreateIndex("dbo.Contacts", "Email_Id");
            CreateIndex("dbo.Contacts", "Phone_Id");
            AddForeignKey("dbo.Contacts", "Address_Id", "dbo.Addresses", "Id");
            AddForeignKey("dbo.Contacts", "Email_Id", "dbo.Emails", "Id");
            AddForeignKey("dbo.Contacts", "Phone_Id", "dbo.Phones", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "Phone_Id", "dbo.Phones");
            DropForeignKey("dbo.Contacts", "Email_Id", "dbo.Emails");
            DropForeignKey("dbo.Contacts", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.Contacts", new[] { "Phone_Id" });
            DropIndex("dbo.Contacts", new[] { "Email_Id" });
            DropIndex("dbo.Contacts", new[] { "Address_Id" });
            AlterColumn("dbo.Contacts", "Address_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Contacts", "Phone_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Contacts", "Email_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Contacts", name: "Phone_Id", newName: "PhoneId");
            RenameColumn(table: "dbo.Contacts", name: "Email_Id", newName: "EmailId");
            RenameColumn(table: "dbo.Contacts", name: "Address_Id", newName: "AddressID");
            CreateIndex("dbo.Contacts", "AddressID");
            CreateIndex("dbo.Contacts", "PhoneId");
            CreateIndex("dbo.Contacts", "EmailId");
            AddForeignKey("dbo.Contacts", "PhoneId", "dbo.Phones", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Contacts", "EmailId", "dbo.Emails", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Contacts", "AddressID", "dbo.Addresses", "Id", cascadeDelete: true);
        }
    }
}
