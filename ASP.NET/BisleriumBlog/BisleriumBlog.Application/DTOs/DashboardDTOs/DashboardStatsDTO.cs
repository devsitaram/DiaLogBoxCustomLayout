using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisleriumBlog.Application.DTOs.DashboardDTOs
{
    public class DashboardStatsDTO
    {
        public int? TotalDownvotes { get; set; }
        public int TotalBlogPosts { get; set; }
        public int TotalComments { get; set; }
        public int? TotalUpvotes { get; set; }
    }
}
