using System.ComponentModel.DataAnnotations;
using BisleriumBlog.Domain.Shared;

namespace BisleriumBlog.Domain.Entities
{
    public class CommentVote : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int? UpVote { get; set; }
        public int? DownVote { get; set; }
        public int? OldVote { get; set; }

        // Foreign key Comment
        public int? CommentId { get; set; }
        public virtual Comment? Comment { get; set; }

        // Foreign key User
        public string? UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
