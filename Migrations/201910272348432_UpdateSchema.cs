namespace ContactsBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSchema : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contacts", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.Addresses", "Contact_Id", "dbo.Contacts");
            DropForeignKey("dbo.Contacts", "Email_Id", "dbo.Emails");
            DropForeignKey("dbo.Emails", "Contact_Id", "dbo.Contacts");
            DropForeignKey("dbo.Contacts", "Phone_Id", "dbo.Phones");
            DropForeignKey("dbo.Phones", "Contact_Id", "dbo.Contacts");
            DropIndex("dbo.Contacts", new[] { "Address_Id" });
            DropIndex("dbo.Contacts", new[] { "Email_Id" });
            DropIndex("dbo.Contacts", new[] { "Phone_Id" });
            DropIndex("dbo.Addresses", new[] { "Contact_Id" });
            DropIndex("dbo.Emails", new[] { "Contact_Id" });
            DropIndex("dbo.Phones", new[] { "Contact_Id" });
            DropColumn("dbo.Contacts", "Address_Id");
            DropColumn("dbo.Contacts", "Email_Id");
            DropColumn("dbo.Contacts", "Phone_Id");
            DropTable("dbo.Addresses");
            DropTable("dbo.Emails");
            DropTable("dbo.Phones");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhoneNumber = c.String(maxLength: 255),
                        Contact_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Emails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmailAddress = c.String(maxLength: 255),
                        Contact_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContactAddress = c.String(maxLength: 255),
                        Contact_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Contacts", "Phone_Id", c => c.Int());
            AddColumn("dbo.Contacts", "Email_Id", c => c.Int());
            AddColumn("dbo.Contacts", "Address_Id", c => c.Int());
            CreateIndex("dbo.Phones", "Contact_Id");
            CreateIndex("dbo.Emails", "Contact_Id");
            CreateIndex("dbo.Addresses", "Contact_Id");
            CreateIndex("dbo.Contacts", "Phone_Id");
            CreateIndex("dbo.Contacts", "Email_Id");
            CreateIndex("dbo.Contacts", "Address_Id");
            AddForeignKey("dbo.Phones", "Contact_Id", "dbo.Contacts", "Id");
            AddForeignKey("dbo.Contacts", "Phone_Id", "dbo.Phones", "Id");
            AddForeignKey("dbo.Emails", "Contact_Id", "dbo.Contacts", "Id");
            AddForeignKey("dbo.Contacts", "Email_Id", "dbo.Emails", "Id");
            AddForeignKey("dbo.Addresses", "Contact_Id", "dbo.Contacts", "Id");
            AddForeignKey("dbo.Contacts", "Address_Id", "dbo.Addresses", "Id");
        }
    }
}
