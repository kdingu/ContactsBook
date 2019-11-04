namespace ContactsBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateTablesWithTestData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.Emails (EmailAddress, ContactId) VALUES ('sadushkoka@hotmail.com', 1)");
            Sql("INSERT INTO dbo.Emails (EmailAddress, ContactId) VALUES ('sadushkoka@gmail.com', 1)");
            Sql("INSERT INTO dbo.Phones (PhoneNumber, ContactId) VALUES ('0696969699', 1)");
            Sql("INSERT INTO dbo.Phones (PhoneNumber, ContactId) VALUES ('0696969899', 1)");
            Sql("INSERT INTO dbo.Phones (PhoneNumber, ContactId) VALUES ('0694023441', 1)");
            Sql("INSERT INTO dbo.Addresses (ContactAddress, ContactId) VALUES ('Rruga Fisqur Karamaliu', 1)");
            Sql("INSERT INTO dbo.Contacts (FirstName, LastName, EmailId, PhoneId, AddressId) VALUES ('Sadush', 'Koka', 1, 1, 1)");
        }
        
        public override void Down()
        {
        }
    }
}
