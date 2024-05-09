
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace BisleriumBlog.Application.DTOs.BlogDTOs
{
    public class BlogRequestDTO
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public IFormFile BlogImage { get; set; }
        [Required]
        public string? UserId { get; set; }
    }
}
