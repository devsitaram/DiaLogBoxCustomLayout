using BisleriumBlog.Application.Common.Interface;
using BisleriumBlog.Application.DTOs.BlogDTOs;
using BisleriumBlog.Application.DTOs.DashboardDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BisleriumBlog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlog _blog;
        private static IWebHostEnvironment _webHostEnvironment;

        public BlogController(IBlog blog, IWebHostEnvironment iWebHostEnvironment)
        {
            _blog = blog;
            _webHostEnvironment = iWebHostEnvironment;
        }

        // [Authorize(Roles = "Blogger")]
        [HttpPost]
        [Route("/api/blog/post")]
        public async Task<ResponseBlog> PostBlog([FromForm] BlogRequestDTO model)
        {
            // Check if the uploaded file is an image (upload image type)
            string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
            string fileExtension = Path.GetExtension(model.BlogImage.FileName);
            if (!allowedExtensions.Contains(fileExtension.ToLower()))
            {
                return new ResponseBlog
                {
                    Status = false,
                    Message = "Only image files (jpg, jpeg, png, gif, bmp) are allowed."
                };
            }

            // Check the file size (validation)
            long size = model.BlogImage.Length;
            if (size > 3 * 1024 * 1024) // 3 MB limit
            {
                return new ResponseBlog
                {
                    Status = false,
                    Message = "Image size must be less than 3 MB."
                };
            }

            string fileName = Path.GetRandomFileName() + fileExtension;
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "Images/BlogImages", fileName);

            string imageUrl = Path.Combine("/Images/BlogImages/", fileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await model.BlogImage.CopyToAsync(stream);
            }

            var result = await _blog.BlogPost(model, imageUrl);
            return result;
        }

        // [Authorize(Roles = "Blogger")]
        [HttpGet]
        [Route("/api/blog/{blogId}")]
        public async Task<ResponseBlogDetail> GetBlogs(int blogId)
        {
            var result = await _blog.GetBlogById(blogId);
            return result;
        }

        // [Authorize(Roles = "Blogger")]
        [HttpDelete]
        [Route("/api/delete/{blogId}")]
        public async Task<ResponseBlog> DeleteBlog(int blogId)
        {
            var result = await _blog.DeleteBlog(blogId);
            return result;
        }

        // [Authorize(Roles = "Blogger")]
        [HttpPut]
        [Route("/api/update/blog/{blogId}")]
        public async Task<ResponseBlog> UpdateBlog(int blogId, [FromForm] BlogRequestDTO model)
        {
            // Check if the uploaded file is an image (upload image type)
            string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
            string fileExtension = Path.GetExtension(model.BlogImage.FileName);
            if (!allowedExtensions.Contains(fileExtension.ToLower()))
            {
                return new ResponseBlog
                {
                    Status = false,
                    Message = "Only image files (jpg, jpeg, png, gif, bmp) are allowed."
                };
            }

            // Check the file size (validation)
            long size = model.BlogImage.Length;
            if (size > 3 * 1024 * 1024) // 3 MB limit
            {
                return new ResponseBlog
                {
                    Status = false,
                    Message = "Image size must be less than 3 MB."
                };
            }

            string fileName = Path.GetRandomFileName() + fileExtension;
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "Images/BlogImages", fileName);

            string imageUrl = Path.Combine("/Images/BlogImages/", fileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await model.BlogImage.CopyToAsync(stream);
            }

            var result = await _blog.UpdateBlog(blogId, imageUrl, model);
            return result;
        }

        // [Authorize(Roles = "Blogger")]
        [HttpGet]
        [Route("/api/user/blog/")]
        public async Task<PeginatedResponseBlogDTOs> GetBlogs(string userId)
        {
            var result = await _blog.GetBlogsByUserId(userId);
            return result;
        }

        // [Authorize(Roles = "Blogger")]
        [HttpGet]
        [Route("/api/all/blog/by/sorting/")]
        public async Task<PeginatedResponseBlogDTOs> GetBlogsBySorting(int pageNumber = 1, int pageSize = 10, string sortBy = "recency")
        {
            var result = await _blog.GetBlogsBySorting(pageNumber, pageSize, sortBy);
            return result;
        }

        // [Authorize(Roles = "Blogger")]
        [HttpGet]
        [Route("/api/activity/status/")]
        public async Task<DashboardResponseDTOs> GetDashboardActivityStats(int year, int month)
        {
            var result = await _blog.GetDashboardActivityStats(year, month);
            return result;
        }

    }
}
