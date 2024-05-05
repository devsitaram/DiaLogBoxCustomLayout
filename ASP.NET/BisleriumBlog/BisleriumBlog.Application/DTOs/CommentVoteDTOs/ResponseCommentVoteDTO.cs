using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisleriumBlog.Application.DTOs.CommentVoteDTOs
{
    public class ResponseCommentVoteDTO
    {
        public bool? Status { get; set; }
        public string? Message { get; set; }
        public object? UpVote { get; set; }
        public object? DownVote { get; set; }
    }
}
