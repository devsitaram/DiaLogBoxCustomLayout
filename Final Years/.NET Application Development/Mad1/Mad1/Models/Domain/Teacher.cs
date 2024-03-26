using System.ComponentModel.DataAnnotations;

namespace Mad1.Models.Domain
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Student> Students { get; set; } // Referencing to many to many relationship
    }
}
