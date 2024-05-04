using BisleriumBlog.Domain.Entities;

namespace BisleriumBlog.Application.DTOs.BlogDTOs
{
    public class PeginatedResponseBlogDTOs
    {
        public bool? Status { get; set; }
        public string? Message { get; set; }
        public IEnumerable<object>? BlogComment { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
    }
}
