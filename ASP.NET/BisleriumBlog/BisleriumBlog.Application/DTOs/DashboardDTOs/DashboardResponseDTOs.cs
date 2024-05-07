using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisleriumBlog.Application.DTOs.DashboardDTOs
{
    public class DashboardResponseDTOs
    {
        public bool? Status { get; set; }
        public string? Message { get; set; }
        public DashboardStatsDTO? AllTimeStats { get; set; }
        public DashboardStatsDTO? MonthStats { get; set; }
    }
}
