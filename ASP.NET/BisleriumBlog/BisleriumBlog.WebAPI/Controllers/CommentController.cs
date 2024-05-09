using BisleriumBlog.Application.DTOs.CommentDTOs;
using BisleriumBlog.Application.DTOs.CommentDTOs.Update;
using BisleriumBlog.Application.Interface.Repository;
using BisleriumBlog.WebAPI.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace BisleriumBlog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IComment _comment;
        private readonly IHubContext<Notification> _Rhub;

        public CommentController(IComment comment, IHubContext<Notification> Rhub)
        {
            _comment = comment;
            _Rhub = Rhub;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("/api/post/comment")]
        public async Task<IActionResult> PostComment(string connectionId, RequestCommentDTO model)
        {
            var result = await _comment.PostComment(model);
            if (result.Status == true)
            {
                await _Rhub.Clients.Client(connectionId).SendAsync("The blogger can commented your post.");
                return Ok(result);
            }
            return BadRequest(result);
        }

        //[HttpPost]
        //[AllowAnonymous]
        //[Route("/api/post/comment")]
        //public async Task<ResponseComments> PostComment(RequestCommentDTO model)
        //{
        //    var result = await _comment.PostComment(model);
        //    if (result.Status == true)
        //    {
        //        await _Rhub.Clients.Users(model.UserId).SendAsync("Comment Added");

        //    }
        //    return result;
        //}

        [HttpGet]
        [AllowAnonymous]
        [Route("/api/get/comment")]
        public async Task<ResponseComments> GetComments(int blogId)
        {
            var result = await _comment.GetComment(blogId);
            return result;
        }

        [HttpPatch]
        [AllowAnonymous]
        [Route("/api/update/comment")]
        public async Task<ResponseComments> UpdateComment(int commentId, CommentUpdateRequest model)
        {
            var result = await _comment.UpdateComment(commentId, model);
            return result;
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("/api/delete/comment")]
        public async Task<ResponseComments> DeleteComment(int commentId)
        {
            var result = await _comment.DeleteComment(commentId);
            return result;
        }
    }
}
