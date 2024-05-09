using BisleriumBlog.Application.DTOs.CommentDTOs;
using BisleriumBlog.Application.DTOs.UserDTOs;

namespace BisleriumBlog.Application.DTOs.BlogDTOs
{
    public class BlogDTO
    {
        public int BlogId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }

        public string? ImageUrl { get; set; }

        public int PopularBlog { get; set; }

        public DateTime CreatedTime { get; set; }
        public DateTime? LastModifiedTime { get; set; }
        public DateTime? DeletedTime { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? ModifiedBy { get; set; }

        public UserDTO? UserDTO { get; set; }
        public IEnumerable<object>? CommentDTOs { get; set; }
        public int? TotalUpvotes { get; set; }
        public int? TotalDownvotes { get; set; }
        public int? TotalComments { get; set; }
    }
}
