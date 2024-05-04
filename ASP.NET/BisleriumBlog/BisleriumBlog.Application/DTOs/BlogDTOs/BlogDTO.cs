using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BisleriumBlog.Application.DTOs.CommentDTOs;
using BisleriumBlog.Application.DTOs.UserDTOs;
using BisleriumBlog.Domain.Entities;
using BisleriumBlog.Domain.Shared;

namespace BisleriumBlog.Application.DTOs.BlogDTOs
{
    public class BlogDTO
    {
        public int BlogId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }

        public string? ImageUrl { get; set; }

        public int PopularBlog { get; set; }

        public DateTime CreatedTime { get; set; }
        public DateTime? LastModifiedTime { get; set; }
        public DateTime? DeletedTime { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? ModifiedBy { get; set; }

        public UserDTO? UserDTO { get; set; }
        public IEnumerable<CommentDTO>? CommentDTOs { get; set; }

    }
}
