﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BisleriumBlog.Application.Common.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using BisleriumBlog.Domain.Entities;
using BisleriumBlog.Application.DTOs.UserDTOs;


namespace BisleriumBlog.Infrastructure.Services
{
    public class AuthenticationService : IAuthentication
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthenticationService(UserManager<User> userManager, IConfiguration configration, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configration;
            _roleManager = roleManager;
        }

        // Register
        public async Task<ResponseDTO> Register(UserRegisterRequestDto model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return new ResponseDTO { Status = false, Message = "User already exists!" };

            User user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username,
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return new ResponseDTO
                    { Status = false, Message = "Enter the valid username password. Please check user details and try again." };

            // Assigning a role to the user
            if (!await _roleManager.RoleExistsAsync("Blogger"))
                await _roleManager.CreateAsync(new IdentityRole("Blogger"));

            await _userManager.AddToRoleAsync(user, "Blogger");

            return new ResponseDTO { Status = true, Message = "User created successfully!" };
        }

        // Login User
        public async Task<LoginResponseDTO> Login(UserLoginRequestDTO model)
        {

            var user = await _userManager.FindByNameAsync(model.Username);
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, true, false);

            if (result.Succeeded)
            {
                var token = await CreateJwtAccessToken(user);

                return new LoginResponseDTO()
                {
                    Message = "Login successful",
                    Status = true,
                    AccessToken = token
                };
            }

            return new LoginResponseDTO()
            {
                Message = "User login failed! Please check user details and try again!",
                Status = false
            };
        }

        // Generate the JWT token
        public async Task<string> CreateJwtAccessToken(User user)
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims(user);
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        // Get Signing Credentials
        private SigningCredentials GetSigningCredentials()
        {
            var jwtConfig = _configuration.GetSection("jwtConfig");
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig["secret"]!));
            return new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
        }

        // Claim the JWT token with user details
        private async Task<List<Claim>> GetClaims(User user)
        {
            var claims = new List<Claim>
            {
                new Claim("id", user.Id),
                new Claim("username", user.UserName),
                new Claim("email", user.Email),
            };
            var roles = await _userManager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                claims.Add(new Claim("role", role));
            }

            return claims;
        }

        // JWT token create
        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("jwtConfig");
            var tokenOptions = new JwtSecurityToken
            (
                issuer: jwtSettings["issuer"],
                audience: jwtSettings["audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(Convert.ToDouble(jwtSettings["expiresIn"])),
                signingCredentials: signingCredentials
            );

            return tokenOptions;
        }

        // Get all user details
        [Authorize]
        public async Task<IEnumerable<UserDetailsDTO>> GetUserDetails()
        {
            var users = await _userManager.Users.Select(x => new
            {
                x.Id,
                x.Email,
                x.UserName,
                x.PhoneNumber,
            }).ToListAsync();

            var userDetails = new List<UserDetailsDTO>();

            foreach (var userData in users)
            {
                var user = await _userManager.FindByIdAsync(userData.Id);
                var roles = await _userManager.GetRolesAsync(user);

                userDetails.Add(new UserDetailsDTO()
                {
                    Id = userData.Id,
                    Email = userData.Email,
                    UserName = userData.UserName,
                    PhoneNumber = userData.PhoneNumber,
                    Role = roles.FirstOrDefault()
                });
            }

            return userDetails;
        }

        /*// Get all user details
        [Authorize]
        public async Task<IEnumerable<UserDetailsDTO>> GetUserDetails()
        {
            var users = await _userManager.Users.Select(x => new
            {
                x.Id,
                x.Email,
                x.UserName,
                x.PhoneNumber,
            }).ToListAsync();

            var roles = await _userManager.GetRolesAsync(users);
            // either
            var userDetails = from userData in users
                              select new UserDetailsDTO()
                              {
                                  Id = userData.Id,
                                  Email = userData.Email,
                                  UserName = userData.UserName,
                                  PhoneNumber = userData.PhoneNumber
                                   Role = roles.FirstOrDefault()
                              };

            // OR
            var userDatas = new List<UserDetailsDTO>();
            foreach (var  in users)
            {
                userDatas.Add(new UserDetailsDTO()
                {
                    Id = item.Id,item
                    Email = item.Email,
                    UserName = item.UserName,
                    PhoneNumber = item.PhoneNumber,
                    Role = roles.FirstOrDefault()

                });
            }

            return userDetails; // userDatas;
        }*/


        // Reset Password (Forgot Password)
        public async Task<ResponseDTO> ForgotPassword(string email, string newPassword)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return new ResponseDTO { Status = false, Message = "User not found!" };

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, newPassword);
            if (!result.Succeeded)
                return new ResponseDTO { Status = false, Message = "Invalid your password!" };

            return new ResponseDTO { Status = true, Message = "Password reset successfully!" };
        }

        // Get Profile details
        public async Task<UserDetailsRespons> GetUserProfile(string userId)
        {

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return new UserDetailsRespons
                {
                    Status = false,
                    Message = "Invalid user profile!",
                };
            }

            var roles = await _userManager.GetRolesAsync(user);

            var userDetails = new UserDetailsDTO()
            {
                Id = userId,
                Email = user.Email,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                Role = roles.FirstOrDefault()
            };

             return new UserDetailsRespons
            {
                Status = true,
                Message = "User profile",
                UserDetails = userDetails
            };
        }

        // Update user profile details 
        public async Task<UserDetailsRespons> UpdateProfile(string userId, UserDetailsDTO model)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return new UserDetailsRespons { Status = false, Message = "User not found!" };

            user.Email = model.Email;
            user.UserName = model.UserName;
            user.PhoneNumber = model.PhoneNumber;

            var result = await _userManager.UpdateAsync(user);

            var userDetails = new UserDetailsDTO
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                Role = model.Role

            };

            if (result.Succeeded)
            {
                return new UserDetailsRespons
                {
                    Status = true,
                    Message = "Profile updated successfully!",
                    UserDetails = userDetails
                };
            }
            else
            {
                return new UserDetailsRespons
                {
                    Status = false,
                    Message = "Failed to update profile!",
                };
            }
        }
    }
}