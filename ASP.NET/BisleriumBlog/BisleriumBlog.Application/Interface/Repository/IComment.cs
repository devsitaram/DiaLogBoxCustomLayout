using BisleriumBlog.Application.DTOs.CommentDTOs;
using BisleriumBlog.Application.DTOs.CommentDTOs.Update;

namespace BisleriumBlog.Application.Interface.Repository
{
    public interface IComment
    {
        Task<ResponseComments> PostComment(RequestCommentDTO model);
        Task<ResponseComments> GetComment(int blogId);
        Task<ResponseComments> UpdateComment(int commentId, CommentUpdateRequest model);
        Task<ResponseComments> DeleteComment(int commentId);
    }
}
