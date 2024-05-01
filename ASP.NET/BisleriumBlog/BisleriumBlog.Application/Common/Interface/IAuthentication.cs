using BisleriumBlog.Application.DTOs.UserDTOs;

namespace BisleriumBlog.Application.Common.Interface
{
    public interface IAuthentication
    {
        Task<ResponseDTO> Register(UserRegisterRequestDto model);
        Task<LoginResponseDTO> Login(UserLoginRequestDTO model);
        Task<ResponseDTO> ForgotPassword(string email, string password);
        Task<UserDetailsRespons> GetUserProfile(string userId);
        Task<UserDetailsRespons> UpdateProfile(UserDetailsDTO model);
        Task<IEnumerable<UserDetailsDTO>> GetUserDetails();
    }
}
