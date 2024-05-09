using BisleriumBlog.Application.DTOs.BlogDTOs;
using BisleriumBlog.Application.DTOs.DashboardDTOs;

namespace BisleriumBlog.Application.Common.Interface
{
    public interface IBlog
    {
        Task<ResponseBlog> BlogPost(BlogRequestDTO model, string imageUrl);
        Task<ResponseBlogDetail> GetBlogById(int blogId);
        Task<ResponseBlog> DeleteBlog(int blogId);
        Task<ResponseBlog> UpdateBlog(int blogId, string imageUrl, BlogRequestDTO model);
        Task<PeginatedResponseBlogDTOs> GetBlogsByUserId(string userId);
        Task<PeginatedResponseBlogDTOs> GetBlogsBySorting(int pageNumber, int pageSize, string sortBy);
        Task<DashboardResponseDTOs> GetDashboardActivityStats(int? year, int? month);
    }
}
