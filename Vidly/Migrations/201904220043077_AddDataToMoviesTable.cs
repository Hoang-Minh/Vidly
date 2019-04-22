namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataToMoviesTable : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into Movies (Name, ReleaseDate, DateAdded, NumberInStock, GenreId) Values ('Hangover', '20091106', GetDate(), 5, 1)");
        }
        
        public override void Down()
        {
        }
    }
}
