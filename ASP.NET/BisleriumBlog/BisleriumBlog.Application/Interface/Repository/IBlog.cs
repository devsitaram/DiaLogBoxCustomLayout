using BisleriumBlog.Application.DTOs.BlogDTOs;
using BisleriumBlog.Application.DTOs.DashboardDTOs;

namespace BisleriumBlog.Application.Common.Interface
{
    public interface IBlog
    {
        Task<ResponseBlog> BlogPost(BlogRequestDTO model, string imageUrl);
        Task<PeginatedResponseBlogDTOs> GetBlogs(int pageNumber, int pageSize);
        Task<ResponseBlog> DeleteBlogPost(int blogId);
        Task<ResponseBlog> UpdateBlog(int blogId, UpdateBlog model);
        Task<PeginatedResponseBlogDTOs> GetBlogsByUserId(string userId);
        Task<PeginatedResponseBlogDTOs> GetBlogsBySorting(int pageNumber, int pageSize, string sortBy);
        Task<DashboardResponseDTOs> GetDashboardActivityStats(int? year, int? month);
    }
}
