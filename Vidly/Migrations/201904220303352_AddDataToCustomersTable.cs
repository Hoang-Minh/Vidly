namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataToCustomersTable : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into Customers (Name, IsSubscribedToNewsletter, MembershipTypeId, Birthdate) Values ('Stephanie Nelson', 0, 3, '19951105')");
            Sql("Insert Into Customers (Name, IsSubscribedToNewsletter, MembershipTypeId, Birthdate) Values ('Tom Hanks', 1, 4, '19820415')");
            Sql("Insert Into Customers (Name, IsSubscribedToNewsletter, MembershipTypeId, Birthdate) Values ('Michelle William', 0, 3, '19790430')");
            Sql("Insert Into Customers (Name, IsSubscribedToNewsletter, MembershipTypeId, Birthdate) Values ('John Smith', 1, 1, '19911129')");
        }
        
        public override void Down()
        {
        }
    }
}
