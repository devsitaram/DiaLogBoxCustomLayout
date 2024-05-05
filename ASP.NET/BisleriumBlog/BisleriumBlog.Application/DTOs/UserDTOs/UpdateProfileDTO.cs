using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BisleriumBlog.Domain.Shared;

namespace BisleriumBlog.Application.DTOs.UserDTOs
{
    public class UpdateProfileDTO
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Role { get; set; }

    }
}
