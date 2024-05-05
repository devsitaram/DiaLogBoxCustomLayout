using BisleriumBlog.Application.DTOs.CommentVoteDTOs;
using BisleriumBlog.Application.DTOs.UserDTOs;

namespace BisleriumBlog.Application.Interface.Repository
{
    public interface ICommentVote
    {
        Task<ResponseDTO> SetVoteInComment(RequestVoteDTO model);
        Task<ResponseCommentVoteDTO> GetNumberOfCommentVote(int commentId);
    }
}
