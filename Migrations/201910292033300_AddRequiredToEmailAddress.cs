namespace ContactsBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequiredToEmailAddress : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Emails", "EmailAddress", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Emails", "EmailAddress", c => c.String(maxLength: 255));
        }
    }
}
