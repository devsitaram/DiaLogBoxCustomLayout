using BisleriumBlog.Application.DTOs.CommentVoteDTOs;
using BisleriumBlog.Application.DTOs.UserDTOs;
using BisleriumBlog.Application.Interface.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BisleriumBlog.WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CommentVoteController : ControllerBase
    {
        private readonly ICommentVote _commentVote;

        public CommentVoteController(ICommentVote commentVote)
        {
            _commentVote = commentVote;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("/api/post/comment/vote")]
        public async Task<ResponseDTO> PostCommentVote(RequestVoteDTO model)
        {
            var result = await _commentVote.SetVoteInComment(model);
            return result;
        }

        [HttpGet]
        [Route("/api/get/total/vote")]
        public async Task<ResponseCommentVoteDTO> GetNumberOfComment(int comnentId)
        {
            var result = await _commentVote.GetNumberOfCommentVote(comnentId);
            return result;
        }
    }
}
