namespace ContactsBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNavigationPropertyToEmailPhoneAddressModels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Addresses", "ContactAddress", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Addresses", "ContactId", c => c.Int(nullable: false));
            AlterColumn("dbo.Contacts", "FirstName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Contacts", "LastName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Emails", "ContactId", c => c.Int(nullable: false));
            AlterColumn("dbo.Phones", "PhoneNumber", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Phones", "ContactId", c => c.Int(nullable: false));
            CreateIndex("dbo.Addresses", "ContactId");
            CreateIndex("dbo.Emails", "ContactId");
            CreateIndex("dbo.Phones", "ContactId");
            AddForeignKey("dbo.Addresses", "ContactId", "dbo.Contacts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Emails", "ContactId", "dbo.Contacts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Phones", "ContactId", "dbo.Contacts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Phones", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Emails", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Addresses", "ContactId", "dbo.Contacts");
            DropIndex("dbo.Phones", new[] { "ContactId" });
            DropIndex("dbo.Emails", new[] { "ContactId" });
            DropIndex("dbo.Addresses", new[] { "ContactId" });
            AlterColumn("dbo.Phones", "ContactId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Phones", "PhoneNumber", c => c.String(maxLength: 255));
            AlterColumn("dbo.Emails", "ContactId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Contacts", "LastName", c => c.String(maxLength: 255));
            AlterColumn("dbo.Contacts", "FirstName", c => c.String(maxLength: 255));
            AlterColumn("dbo.Addresses", "ContactId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Addresses", "ContactAddress", c => c.String(maxLength: 255));
        }
    }
}
