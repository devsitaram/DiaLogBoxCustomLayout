using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BisleriumBlog.Application.DTOs.BlogVoteDTOs;
using BisleriumBlog.Application.DTOs.CommentVoteDTOs;
using BisleriumBlog.Application.DTOs.UserDTOs;

namespace BisleriumBlog.Application.Interface.Repository
{
    public interface IBlogVote
    {
        Task<ResponseCommentVoteDTO> GetNumberOfBlogVote(int blogId);
        Task<ResponseDTO> SetVoteInBlog(RequestBlogVoteDTO model);
    }
}
