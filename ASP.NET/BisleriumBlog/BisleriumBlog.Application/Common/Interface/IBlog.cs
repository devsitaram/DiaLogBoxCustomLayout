using BisleriumBlog.Application.DTOs.BlogDTOs;

namespace BisleriumBlog.Application.Common.Interface
{
    public interface IBlog
    {
        Task<ResponseBlog> BlogPost(BlogRequestDTO model);
        Task<ResponseBlog> GetBlogs();
        Task<ResponseBlog> DeleteBlogPost(int blogId);
        Task<ResponseBlog> UpdateBlog(int blogId, UpdateBlog model);
    }
}
