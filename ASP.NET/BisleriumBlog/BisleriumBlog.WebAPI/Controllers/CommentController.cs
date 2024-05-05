using System.Windows.Input;
using BisleriumBlog.Application.Common.Interface;
using BisleriumBlog.Application.DTOs.CommentDTOs;
using BisleriumBlog.Application.DTOs.CommentDTOs.Update;
using BisleriumBlog.Application.Interface.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BisleriumBlog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IComment _comment;

        public CommentController(IComment comment)
        {
            _comment = comment;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("/api/post/comment")]
        public async Task<ResponseComments> PostComment(RequestCommentDTO model)
        {
            var result = await _comment.PostComment(model);
            return result;
        }

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
