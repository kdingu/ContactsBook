namespace ContactsBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateFieldLengths : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacts", "FirstName", c => c.String(maxLength: 255));
            AlterColumn("dbo.Contacts", "LastName", c => c.String(maxLength: 255));
            AlterColumn("dbo.Addresses", "ContactAddress", c => c.String(maxLength: 255));
            AlterColumn("dbo.Emails", "EmailAddress", c => c.String(maxLength: 255));
            AlterColumn("dbo.Phones", "PhoneNumber", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Phones", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Emails", "EmailAddress", c => c.String());
            AlterColumn("dbo.Addresses", "ContactAddress", c => c.String());
            AlterColumn("dbo.Contacts", "LastName", c => c.String());
            AlterColumn("dbo.Contacts", "FirstName", c => c.String());
        }
    }
}
