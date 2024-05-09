using System.Net;
using BisleriumBlog.Domain.Shared;
using Microsoft.AspNetCore.Identity;

namespace BisleriumBlog.Domain.Entities
{
    public class User : IdentityUser
    {
        public string? ConnectionId { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? LastModifiedTime { get; set; }
        public DateTime? DeletedTime { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? ModifiedBy { get; set; }
        public Guid? DeletedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
