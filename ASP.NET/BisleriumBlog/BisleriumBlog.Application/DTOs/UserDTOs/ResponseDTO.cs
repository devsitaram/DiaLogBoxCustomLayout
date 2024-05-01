namespace BisleriumBlog.Application.DTOs.UserDTOs
{
    public class ResponseDTO
    {
        public bool? Status { get; set; }
        public string? Message { get; set; }
    }

    public class ErrorMessageResponse
    {
        public string? Message { get; set; }
        public string? ContentType { get; set; }
        public int StatusCode { get; set; }
    }
}