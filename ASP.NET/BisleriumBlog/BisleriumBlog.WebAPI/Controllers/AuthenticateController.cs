using BisleriumBlog.Application.Common.Interface;
using BisleriumBlog.Application.DTOs.UserDTOs;
using BisleriumBlog.WebAPI.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace BisleriumBlog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthentication _authenticationManager;
        private readonly IHubContext<Notification> _hubContext;


        public AuthenticateController(IAuthentication authenticationManager, IHubContext<Notification> hubContext)
        {
            _authenticationManager = authenticationManager;
            _hubContext = hubContext;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("/api/authenticate/register")]
        public async Task<ResponseDTO> Register([FromBody] UserRegisterRequestDto model)
        {
            //var connectionId = await _notification.getConnectionId();
            var result = await _authenticationManager.Register(model);
            return result;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("/api/authenticate/login")]
        public async Task<LoginResponseDTO> Login([FromBody] UserLoginRequestDTO user)
        {
            var result = await _authenticationManager.Login(user);
            return result;
        }

        [Authorize]
        [HttpPatch]
        [Route("/api/forgotpassword")]
        public async Task<ResponseDTO> ForgotPassword(string email, string password)
        {
            var result = await _authenticationManager.ForgotPassword(email, password);
            return result;

        }

        [Authorize]
        [HttpGet]
        [Route("/api/user/profile")]
        public async Task<ActionResult<UserDetailsRespons>> GetUserProfile([FromQuery] string userId)
        {
            var result = await _authenticationManager.GetUserProfile(userId);
            return result;
        }

        [Authorize]
        [HttpPatch]
        [Route("/api/update/profile")]
        public async Task<ActionResult<UpdateProfileResponse>> UpdateProfile([FromQuery] string userId, [FromBody] UpdateProfileDTO model)
        {
            var result = await _authenticationManager.UpdateProfile(userId, model);
            return result;
        }

        [HttpGet]
        [Route("/api/authenticate/getUserDetails")]
        public async Task<IEnumerable<UserDTO>> GetUserDetails()
        {
            var result = await _authenticationManager.GetUserDetails();
            return result;
        }

        [Authorize]
        [HttpPatch]
        [Route("/api/update/user/role")]
        public async Task<UserDetailsRespons> UpdateRole([FromQuery] string userId, [FromQuery] string userRole)
        {
            var result = await _authenticationManager.UpdateRole(userId, userRole);
            return result;
        }
    }
}