using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisleriumBlog.Application.DTOs.CommentDTOs
{
    public class RequestCommentDTO
    {
        public string? Content { get; set; }
        public int? BlogId { get; set; }
        public string? UserId { get; set; }
    }
}
