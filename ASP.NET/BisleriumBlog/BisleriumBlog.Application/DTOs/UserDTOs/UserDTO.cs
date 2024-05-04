﻿using BisleriumBlog.Domain.Shared;

namespace BisleriumBlog.Application.DTOs.UserDTOs
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Role { get; set; }
    }
}
