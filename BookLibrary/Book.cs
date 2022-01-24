using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// #nullable enable

namespace BookLibrary
{
    [Table("Volumes")]
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        //[Column(TypeName = "varchar (20)")]
        //or
        [MaxLength(20)] // it will create nvarchar(20)
        public string Title { get; set; }
        [Column("Year")]
        public int YearOfPublication { get; set; }
        [NotMapped]
        public string ISBN { get; set; }
        [Column(TypeName = "decimal(5,2)")]
        public decimal Price { get; set; }
        [Column(TypeName = "date")]
        public DateTime SomeDate { get; set; }
        public int Id_Author { get; set; } // if want to use customised names then [ForeignKey]
        [ForeignKey(nameof(Id_Author))]
        public Author Author { get; set; }
        public int AuthorId { get; set; }

        // Incase #nullable enable or project level nullable enable use below for reference types no null
        // public Author Author { get; set; } = null!;

        public override string ToString()
        {
            return $"{Title} ({YearOfPublication})";
        }

    }
}