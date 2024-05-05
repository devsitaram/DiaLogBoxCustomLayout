﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
