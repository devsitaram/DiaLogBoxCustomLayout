using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisleriumBlog.Domain.Shared
{
    public class Validators
    {
        public string FormatFileSize(long size)
        {
            if (size <= 0) return "0 B";
            string[] units = { "B", "KB", "MB", "GB", "TB" };
            int digitGroups = (int)(Math.Log10(size) / Math.Log10(1024));
            return string.Format("{0} {1}", (double)size / Math.Pow(1024, digitGroups), units[digitGroups]);
        }
    }
}
