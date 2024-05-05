using BisleriumBlog.Domain.Entities;

namespace BisleriumBlog.Application.DTOs.CommentDTOs
{
    public class ResponseComments
    {
        public bool? Status { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }
        // public IEnumerable<Comment>? Data { get; set; }
    }
}
