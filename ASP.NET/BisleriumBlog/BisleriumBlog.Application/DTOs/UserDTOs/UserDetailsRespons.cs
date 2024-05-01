using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisleriumBlog.Application.DTOs.UserDTOs
{
    public class UserDetailsRespons
    {
        public bool? Status { get; set; }
        public string? Message { get; set; }
        public UserDetailsDTO? UserDetails { get; set; }
    }
}
