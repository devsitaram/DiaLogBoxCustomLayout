using BisleriumBlog.Application.DTOs.UserDTOs;

namespace BisleriumBlog.Application.DTOs.CommentDTOs
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string? Comments { get; set; }
        public int PopularComments { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime LastModifiedTime { get; set; }
        public UserDTO? UserDTO { get; set; }
    }
}
