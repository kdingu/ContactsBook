namespace ContactsBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRelationshipKeys : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contacts", "Addresses_Id", "dbo.Addresses");
            DropForeignKey("dbo.Contacts", "Emails_Id", "dbo.Emails");
            DropForeignKey("dbo.Contacts", "Phones_Id", "dbo.Phones");
            DropIndex("dbo.Contacts", new[] { "Addresses_Id" });
            DropIndex("dbo.Contacts", new[] { "Emails_Id" });
            DropIndex("dbo.Contacts", new[] { "Phones_Id" });
            RenameColumn(table: "dbo.Contacts", name: "Addresses_Id", newName: "AddressID");
            RenameColumn(table: "dbo.Contacts", name: "Emails_Id", newName: "EmailId");
            RenameColumn(table: "dbo.Contacts", name: "Phones_Id", newName: "PhoneId");
            AddColumn("dbo.Addresses", "ContactId", c => c.Int(nullable: false));
            AddColumn("dbo.Emails", "ContactId", c => c.Int(nullable: false));
            AddColumn("dbo.Phones", "ContactId", c => c.Int(nullable: false));
            AlterColumn("dbo.Contacts", "AddressID", c => c.Int(nullable: false));
            AlterColumn("dbo.Contacts", "EmailId", c => c.Int(nullable: false));
            AlterColumn("dbo.Contacts", "PhoneId", c => c.Int(nullable: false));
            CreateIndex("dbo.Contacts", "EmailId");
            CreateIndex("dbo.Contacts", "PhoneId");
            CreateIndex("dbo.Contacts", "AddressID");
            AddForeignKey("dbo.Contacts", "AddressID", "dbo.Addresses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Contacts", "EmailId", "dbo.Emails", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Contacts", "PhoneId", "dbo.Phones", "Id", cascadeDelete: true);
            DropColumn("dbo.Contacts", "Email");
            DropColumn("dbo.Contacts", "Phone");
            DropColumn("dbo.Contacts", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "Address", c => c.Int(nullable: false));
            AddColumn("dbo.Contacts", "Phone", c => c.Int(nullable: false));
            AddColumn("dbo.Contacts", "Email", c => c.Int(nullable: false));
            DropForeignKey("dbo.Contacts", "PhoneId", "dbo.Phones");
            DropForeignKey("dbo.Contacts", "EmailId", "dbo.Emails");
            DropForeignKey("dbo.Contacts", "AddressID", "dbo.Addresses");
            DropIndex("dbo.Contacts", new[] { "AddressID" });
            DropIndex("dbo.Contacts", new[] { "PhoneId" });
            DropIndex("dbo.Contacts", new[] { "EmailId" });
            AlterColumn("dbo.Contacts", "PhoneId", c => c.Int());
            AlterColumn("dbo.Contacts", "EmailId", c => c.Int());
            AlterColumn("dbo.Contacts", "AddressID", c => c.Int());
            DropColumn("dbo.Phones", "ContactId");
            DropColumn("dbo.Emails", "ContactId");
            DropColumn("dbo.Addresses", "ContactId");
            RenameColumn(table: "dbo.Contacts", name: "PhoneId", newName: "Phones_Id");
            RenameColumn(table: "dbo.Contacts", name: "EmailId", newName: "Emails_Id");
            RenameColumn(table: "dbo.Contacts", name: "AddressID", newName: "Addresses_Id");
            CreateIndex("dbo.Contacts", "Phones_Id");
            CreateIndex("dbo.Contacts", "Emails_Id");
            CreateIndex("dbo.Contacts", "Addresses_Id");
            AddForeignKey("dbo.Contacts", "Phones_Id", "dbo.Phones", "Id");
            AddForeignKey("dbo.Contacts", "Emails_Id", "dbo.Emails", "Id");
            AddForeignKey("dbo.Contacts", "Addresses_Id", "dbo.Addresses", "Id");
        }
    }
}
