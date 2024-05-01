using BisleriumBlog.Domain.Entities;

namespace BisleriumBlog.Application.DTOs.BlogDTOs
{
    public class ResponseBlog
    {
        public bool? Status { get; set; }
        public string? Message { get; set; }
        public IEnumerable<Blog>? Data { get; set; }
    }
}
