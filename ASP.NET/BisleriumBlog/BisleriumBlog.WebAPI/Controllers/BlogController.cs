using BisleriumBlog.Application.Common.Interface;
using BisleriumBlog.Application.DTOs.BlogDTOs;
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

        [HttpPost]
        [Route("/api/blog/post")]
        public async Task<ResponseBlog> PostBlog([FromForm] BlogRequestDTO model)
        {
            // Check if the uploaded file is an image (upload image type)
            string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
            string fileExtension = Path.GetExtension(model.ImageFile.FileName);
            if (!allowedExtensions.Contains(fileExtension.ToLower()))
            {
                return new ResponseBlog
                {
                    Status = false,
                    Message = "Only image files (jpg, jpeg, png, gif, bmp) are allowed."
                };
            }

            // Check the file size (validation)
            long size = model.ImageFile.Length;
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
                await model.ImageFile.CopyToAsync(stream);
            }

            var result = await _blog.BlogPost(model, imageUrl);
            return result;
        }

        //[HttpPost]
        //[Route("/api/blog/post")]
        //public async Task<ResponseBlog> Register([FromForm] BlogRequestDTO model)
        //{

        //    string fileName = Path.GetRandomFileName() + Path.GetExtension(model.ImageFile.FileName);
        //    string path = Path.Combine(_webHostEnvironment.WebRootPath, "Images/BlogImages", fileName);
        //    also check the image file type like jpg, jpeg, png, ... Only required the image
        //    long size = path.Length;
        //    // Check if the file size is greater than 3 MB
        //    if (size > 3 * 1024 * 1024)
        //    {
        //        return new ResponseBlog
        //        {
        //            Status = false,
        //            Message = "Image size must be less than 3 MB."
        //        };
        //    }
        //    else
        //    {
        //        string imageUrl = Path.Combine("/Images/BlogImages/", fileName);
        //        using (var stream = new FileStream(path, FileMode.Create))
        //        {
        //            await model.ImageFile.CopyToAsync(stream);
        //        }

        //        var result = await _blog.BlogPost(model, imageUrl);
        //        return result;
        //    }
        //}

        [HttpGet]
        [Route("/api/all/blog")]
        public async Task<PeginatedResponseBlogDTOs> GetBlogs(int pageNumber = 1, int pageSize = 10)
        {
            var result = await _blog.GetBlogs(pageNumber, pageSize);
            return result;
        }

        [HttpDelete]
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
