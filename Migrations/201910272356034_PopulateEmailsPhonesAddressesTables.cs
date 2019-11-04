namespace ContactsBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateEmailsPhonesAddressesTables : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Emails (EmailAddress, ContactId) VALUES ('Sadushkoka@gmail.com', '4')");
            Sql("INSERT INTO Emails (EmailAddress, ContactId) VALUES ('Sadushkoka@hotmail.com', '4')");
            Sql("INSERT INTO Emails (EmailAddress, ContactId) VALUES ('saniekoka@gmail.com', '9')");
            Sql("INSERT INTO Emails (EmailAddress, ContactId) VALUES ('bkaleci@gmail.com', '10')");
            Sql("INSERT INTO Emails (EmailAddress, ContactId) VALUES ('sabaudink@gmail.com', '11')");
            Sql("INSERT INTO Emails (EmailAddress, ContactId) VALUES ('dreqalie69@gmail.com', '12')");
            Sql("INSERT INTO Emails (EmailAddress, ContactId) VALUES ('dreqivet1@live.com', '12')");
            Sql("INSERT INTO Emails (EmailAddress, ContactId) VALUES ('dreqaliebomba@facebook.com', '12')");

            Sql("INSERT INTO Phones (PhoneNumber, ContactId) VALUES ('0695454887', '4')");
            Sql("INSERT INTO Phones (PhoneNumber, ContactId) VALUES ('0674454472', '9')");
            Sql("INSERT INTO Phones (PhoneNumber, ContactId) VALUES ('0685585584', '11')");
            Sql("INSERT INTO Phones (PhoneNumber, ContactId) VALUES ('0682099696', '12')");

            Sql("INSERT INTO Addresses (ContactAddress, ContactId) VALUES ('Rruga Bab Dud Kar Bun Ara', '4')");
            Sql("INSERT INTO Addresses (ContactAddress, ContactId) VALUES ('Rruga Bab Dud Kar Bun Ara', '9')");
            Sql("INSERT INTO Addresses (ContactAddress, ContactId) VALUES ('Rruga Komisarjatit aty afer lokalit te kati 2', '10')");
            Sql("INSERT INTO Addresses (ContactAddress, ContactId) VALUES ('Rruga Si ja kalove', '11')");
            Sql("INSERT INTO Addresses (ContactAddress, ContactId) VALUES ('Kodra Diellit', '12')");
        }
        
        public override void Down()
        {
        }
    }
}
