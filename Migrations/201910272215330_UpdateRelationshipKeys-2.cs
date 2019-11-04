namespace ContactsBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRelationshipKeys2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Addresses", "ContactId");
            DropColumn("dbo.Emails", "ContactId");
            DropColumn("dbo.Phones", "ContactId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Phones", "ContactId", c => c.Int(nullable: false));
            AddColumn("dbo.Emails", "ContactId", c => c.Int(nullable: false));
            AddColumn("dbo.Addresses", "ContactId", c => c.Int(nullable: false));
        }
    }
}
