using BisleriumBlog.Application.Common.Interface;
using BisleriumBlog.Application.DTOs.BlogVoteDTOs;
using BisleriumBlog.Application.DTOs.CommentVoteDTOs;
using BisleriumBlog.Application.DTOs.UserDTOs;
using BisleriumBlog.Application.Interface.Repository;
using BisleriumBlog.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BisleriumBlog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogVoteController : ControllerBase
    {
        private readonly IBlogVote _blogVote;

        public BlogVoteController(IBlogVote blogVote)
        {
            _blogVote = blogVote;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("/api/react/blog/vote/{blogId}")]
        public async Task<ResponseDTO> PostCommentVote(RequestBlogVoteDTO model)
        {
            var result = await _blogVote.SetVoteInBlog(model);
            return result;
        }

        [HttpGet]
        [Route("/api/blog/vote")]
        public async Task<ResponseCommentVoteDTO> GetNumberOfComment(int blogId)
        {
            var result = await _blogVote.GetNumberOfBlogVote(blogId);
            return result;
        }
    }
}
