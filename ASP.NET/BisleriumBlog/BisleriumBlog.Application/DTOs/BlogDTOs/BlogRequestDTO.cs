
using Microsoft.AspNetCore.Http;

namespace BisleriumBlog.Application.DTOs.BlogDTOs
{
    public class BlogRequestDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public IFormFile ImageFile { get; set; }
        public string? UserId { get; set; }
    }
}
