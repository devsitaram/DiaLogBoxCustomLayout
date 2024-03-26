using System.ComponentModel.DataAnnotations;

namespace Mad1.Models.Domain
{
    public class Student
    {
        [Key]
        public int LMUId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string FypTitle { get; set; }
        public Bill Bill { get; set; } // Reference one to one table
        public List<Book> Books { get; set; } // Reference one to many relationship
        public List<Teacher> Teachers { get; set; } // Reference one to many relationship
    }
}
