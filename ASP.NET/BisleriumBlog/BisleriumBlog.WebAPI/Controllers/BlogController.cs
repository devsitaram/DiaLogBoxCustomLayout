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
        private static IWebHostEnvironment _webHostEnvironment;

        public BlogController(IBlog blog, IWebHostEnvironment iWebHostEnvironment)
        {
            _blog = blog;
            _webHostEnvironment = iWebHostEnvironment;
        }

        [HttpPost]
        [Route("/api/blog/post")]
        public async Task<ResponseBlog> Register([FromBody] BlogRequestDTO model)
        {
            var result = await _blog.BlogPost(model);
            return result;
        }

        [HttpPost]
        [Route("/api/image/post")]
        public async Task<string> UploadImage([FromForm] UploadFileDTO model)
        {
            if (model.File.Length > 0)
            {
                try
                {
                    if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\Images\\"))
                    {
                        Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\Images\\");
                    }

                    using (FileStream fileStream = System.IO.File.Create(_webHostEnvironment.WebRootPath + "\\Images" + model.File.FileName))
                    {
                        model.File.CopyTo(fileStream);
                        fileStream.Flush();
                        return "\\Images\\" + model.File.FileName;
                    }

                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            else
            {
                return "No file found";
            }
        }

        //[HttpPost]
        //[Route("/api/image/post")]
        //public async Task<string> UploadImage([FromForm] UploadFileDTO model)
        //{
        //    if (model.File != null && model.File.Length > 0)
        //    {
        //        try
        //        {
        //            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");

        //            if (!Directory.Exists(uploadsFolder))
        //            {
        //                Directory.CreateDirectory(uploadsFolder);
        //            }

        //            string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(model.File.FileName);
        //            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

        //            using (FileStream fileStream = System.IO.File.Create(filePath))
        //            {
        //                await model.File.CopyToAsync(fileStream);
        //                fileStream.Flush();
        //                return "/Images/" + uniqueFileName;
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            return ex.Message;
        //        }
        //    }
        //    else
        //    {
        //        return "No file found";
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
