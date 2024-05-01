using System.ComponentModel.DataAnnotations;

namespace BisleriumBlog.Application.DTOs.UserDTOs
{
    public class UserLoginRequestDTO
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }


}
