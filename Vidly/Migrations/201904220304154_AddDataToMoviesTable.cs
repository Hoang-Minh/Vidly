namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataToMoviesTable : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into Movies (Name, ReleaseDate, DateAdded, NumberInStock, GenreId) Values ('Hangover', '20091106', GetDate(), 5, 1)");
            Sql("Insert Into Movies (Name, ReleaseDate, DateAdded, NumberInStock, GenreId) Values ('Die Hard', '19980715', GetDate(), 10, 2)");
            Sql("Insert Into Movies (Name, ReleaseDate, DateAdded, NumberInStock, GenreId) Values ('Terminator', '19841026', GetDate(), 2, 1)");
            Sql("Insert Into Movies (Name, ReleaseDate, DateAdded, NumberInStock, GenreId) Values ('Toy Story', '19951122', GetDate(), 6, 3)");
            Sql("Insert Into Movies (Name, ReleaseDate, DateAdded, NumberInStock, GenreId) Values ('Titanic', '19971219', GetDate(), 1, 4)");
        }
        
        public override void Down()
        {
        }
    }
}
