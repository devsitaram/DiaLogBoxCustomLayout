namespace BisleriumBlog.Application.DTOs.UserDTOs
{
    public class LoginResponseDTO
    {
        public bool? Status { get; set; }
        public string? Message { get; set; }
        public string? AccessToken { get; set; }
    }
}
