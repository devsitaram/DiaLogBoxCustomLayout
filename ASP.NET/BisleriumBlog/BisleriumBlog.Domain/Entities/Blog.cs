using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BisleriumBlog.Domain.Shared;


namespace BisleriumBlog.Domain.Entities
{
    public class Blog : BaseEntity
    {
        [Key]
        public int BlogId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public int PopularBlog { get; set; }
        public string? OldContent { get; set; }

        // Foreign key
        public string? UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
