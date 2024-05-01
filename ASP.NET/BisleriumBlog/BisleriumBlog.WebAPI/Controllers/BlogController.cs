using BisleriumBlog.Application.Common.Interface;
using BisleriumBlog.Application.DTOs.BlogDTOs;
using Microsoft.AspNetCore.Mvc;

namespace BisleriumBlog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlog _blog;

        public BlogController(IBlog blog)
        {
            _blog = blog;
        }

        [HttpPost]
        [Route("/api/blog/post")]
        public async Task<ResponseBlog> Register([FromBody] BlogRequestDTO model)
        {
            var result = await _blog.BlogPost(model);
            return result;
        }

        [HttpGet]
        [Route("/api/all/blog")]
        public async Task<PeginatedResponseBlogDTOs> GetBlogs(int pageNumber = 1, int pageSize = 10)
        {
            var result = await _blog.GetBlogs(pageNumber, pageSize);
            return result;
        }

        [HttpPatch]
        [Route("/api/delete/blog")]
        public async Task<ResponseBlog> DeleteBlog([FromQuery] int blogId)
        {
            var result = await _blog.DeleteBlogPost(blogId);
            return result;
        }

        [HttpPatch]
        [Route("/api/update/blog")]
        public async Task<ResponseBlog> Updateblog([FromQuery] int blodId, [FromBody]UpdateBlog model)
        {
            var result = await _blog.UpdateBlog(blodId, model);
            return result;
        }
    }
}
