using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BisleriumBlog.Domain.Shared;

namespace BisleriumBlog.Domain.Entities
{
    public class Comment : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string? Comments { get; set; }
        
        public string? OldComments { get; set; }
        public int PopularComments { get; set; }

        // Foreign key Blog
        public int? BlogId { get; set; }
        public virtual Blog? Blog { get; set; }

        // Foreign key User
        public string? UserId { get; set; }
        public virtual User? User { get; set; }

    }
}
