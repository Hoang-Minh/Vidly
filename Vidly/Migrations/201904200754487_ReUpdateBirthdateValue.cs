namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReUpdateBirthdateValue : DbMigration
    {
        public override void Up()
        {
            Sql("Update Customers set Birthdate = '19831208' where Id = 1");
        }
        
        public override void Down()
        {
        }
    }
}
