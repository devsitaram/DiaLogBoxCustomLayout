using System.ComponentModel.DataAnnotations;

namespace Mad1.Models.Domain
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Auther { get; set; }
        public DateOnly RentDate { get; set; }
        public int StudentId { get; set; } // Foreign Key
        public Student Student { get; set; } // Refering to another class
    }
}
