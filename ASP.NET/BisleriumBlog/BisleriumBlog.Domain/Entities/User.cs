using System.Net;
using BisleriumBlog.Domain.Shared;
using Microsoft.AspNetCore.Identity;

namespace BisleriumBlog.Domain.Entities
{
    public class User : IdentityUser
    {
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public DateTime? LastModifiedTime { get; set; }
        public DateTime? DeletedTime { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? ModifiedBy { get; set; }
        public Guid? DeletedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
