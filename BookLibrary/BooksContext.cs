using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class BooksContext : DbContext
    {
        public BooksContext(DbContextOptions<BooksContext> options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var books = modelBuilder.Entity<Book>();

            books.ToTable("Volumes");
            books.Property(b => b.Title).IsRequired();
            // books.HasKey(b => b.ISBN); if single, multiple follow below
            books.HasKey(b => new { b.ISBN, b.Title });
            books.Ignore(b => b.Price);
            books.HasOne(b => b.Author).WithMany(a => a.Books).HasForeignKey("Id_Author").IsRequired(); // if we want customised id then mentione
            books.Property(b => b.YearOfPublication).HasColumnName("Year");
            books.Property(b => b.Title).HasColumnType("varchar(20)");
            books.Property(b => b.Title).HasMaxLength(20);
            books.Property(b => b.Price).HasColumnType("decimal(5, 2)");
            books.Property(b => b.SomeDate).HasColumnType("date");

        }

    }
}
