using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BisleriumBlog.Domain.Entities;

namespace BisleriumBlog.Application.DTOs.BlogDTOs
{
    public class BlogComment
    {
        public Blog? Blog { get; set; }
        public IEnumerable<Comment>? Comment { get; set; }
    }
}
