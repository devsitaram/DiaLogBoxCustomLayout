using BisleriumBlog.Application.DTOs.CommentDTOs;

namespace BisleriumBlog.Application.Interface.Repository
{
    public interface IComment
    {
        Task<ResponseComments> PostComment(RequestCommentDTO model);
        Task<ResponseComments> GetComment(int blogId);
    }
}
