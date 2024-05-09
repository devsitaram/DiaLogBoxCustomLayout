using System.ComponentModel.DataAnnotations;
using BisleriumBlog.Domain.Shared;

namespace BisleriumBlog.Domain.Entities
{
    public class BlogHistory : BaseEntity
    {
        [Key]
        public int BlogHistoryId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? ImageUrl { get; set; }
        public int? PopularBlog { get; set; }
        public string? OldContent { get; set; }
        public int? BlogId { get; set; }
        public virtual Blog? Blog { get; set; }
        public string? UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
