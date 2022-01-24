// See https://aka.ms/new-console-template for more information
//using BookLibrary;
using DbFirstLibrary;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

//var options = new DbContextOptionsBuilder<BooksContext>()
//       .UseSqlite("Filename=../../../MyLocalLibrary.db").Options;

//using var db = new BooksContext(options);
//db.Database.EnsureCreated();

var options = new DbContextOptionsBuilder<MyLocalLibraryContext>()
       .UseSqlite("Filename=../../../MyLocalLibrary.db").Options;

using var db = new MyLocalLibraryContext(options);
db.Database.EnsureCreated();


//var authors = CreateFakeData();
//await db.Authors.AddRangeAsync(authors);
//await db.SaveChangesAsync();


foreach (var auth in db.Authors.Include(a=> a.Books))
{
    Console.WriteLine(auth);
    foreach (var book in auth.Books)
    {
        Console.WriteLine(book);
    }
}


var recentBooks = from book in db.Books where book.YearOfPublication > 1985 select book;
foreach (var book in recentBooks.Include(b=> b.Author))
{
    Console.WriteLine($"{book} by {book.Author}");

}



static IEnumerable<Author> CreateFakeData()
{
    var authors = new List<Author>
    {
        new Author
        {
            Name = "Siva", Books = new List<Book>
            {
               new Book { Title = "Title1", YearOfPublication = 2000 },
               new Book { Title = "Title2", YearOfPublication = 2001 },
               new Book { Title = "Title3", YearOfPublication = 2002 },
            }
       },
       new Author
       {
           Name = "Sankar", Books = new List<Book>
            {
               new Book { Title = "Title4", YearOfPublication = 2003 },
               new Book { Title = "Title5", YearOfPublication = 2004 },
               new Book { Title = "Title6", YearOfPublication = 2005 },
            }
       }
    };
    return authors;
}