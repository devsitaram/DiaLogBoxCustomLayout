﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisleriumBlog.Application.DTOs.UserDTOs
{
    public class UpdateProfileResponse
    {
        public bool? Status { get; set; }
        public string? Message { get; set; }
        public UpdateProfileDTO? UpdateProfileDTO { get; set; }
    }
}