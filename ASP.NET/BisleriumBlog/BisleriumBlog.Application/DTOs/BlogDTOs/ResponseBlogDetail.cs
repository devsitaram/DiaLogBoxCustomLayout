namespace BisleriumBlog.Application.DTOs.BlogDTOs
{
    public class ResponseBlogDetail
    {
        public bool? Status { get; set; }
        public string? Message { get; set; }
        public IEnumerable<object>? BlogDetails { get; set; }
        public int? TotalUpvotes { get; set; }
        public int? TotalDownvotes { get; set; }
        public int? TotalComments { get; set; }
    }
}
