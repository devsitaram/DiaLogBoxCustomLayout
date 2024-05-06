using System.ComponentModel.DataAnnotations;
namespace BisleriumBlog.Application.DTOs.CommentVoteDTOs
{
    public class RequestVoteDTO
    {
        [Required]
        public bool VoteType { get; set; }
        [Required]
        public int CommentId { get; set; }
        [Required]
        public string UserId { get; set; }

    }
}
