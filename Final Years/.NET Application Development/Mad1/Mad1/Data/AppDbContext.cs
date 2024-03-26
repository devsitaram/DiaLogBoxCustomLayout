using Mad1.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Mad1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Student> students { get; set; }

        public DbSet<Bill> Bills { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Teacher> Teachers { get; set; }
    }
}
