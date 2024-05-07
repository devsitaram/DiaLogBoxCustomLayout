using BisleriumBlog.Application.Common.Interface;


namespace BisleriumBlog.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.UtcNow;
    }
}
