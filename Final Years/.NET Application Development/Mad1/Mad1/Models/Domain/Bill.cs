using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Mad1.Models.Domain
{
    public class Bill
    {
        [Key]
        public int BillId { get; set; }
        public DateOnly Date { get; set; }
        public double Amount { get; set; }
        public int StudentId { get; set; } // Foreign Key
        public Student Student { get; set; } // Refering to another class

    }
}
