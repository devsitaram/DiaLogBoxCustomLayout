using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BisleriumBlog.Domain.Entities;
using BisleriumBlog.Application.Interface.Repository;
using BisleriumBlog.Infrastructure.Data;
using BisleriumBlog.Application.DTOs.UserDTOs;
using BisleriumBlog.Application.DTOs.CommentVoteDTOs;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection.Emit;
using Microsoft.AspNetCore.Http.Connections;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;

namespace BisleriumBlog.Infrastructure.Services
{
    public class CommentVoteServices : ICommentVote
    {
        private readonly AppDbContext _context;

        public CommentVoteServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseCommentVoteDTO> GetNumberOfCommentVote(int commentId)
        {
            try
            {
                // Get total number of up-Vote and Down-Vote from CommentVote table by CommentId
                var upVoteCount = await _context.CommentVote.CountAsync(v => v.CommentId == commentId && v.UpVote == 1);
                var downVoteCount = await _context.CommentVote.CountAsync(v => v.CommentId == commentId && v.DownVote == 1);

                return new ResponseCommentVoteDTO
                {
                    Status = true,
                    Message = "Vote counts retrieved successfully",
                    UpVote = upVoteCount,
                    DownVote = downVoteCount
                };
            }
            catch
            {
                return new ResponseCommentVoteDTO
                {
                    Status = false,
                    Message = "Sorry, something went wrong on our end. Please try again later."
                };
            }
        }

        public async Task<ResponseDTO> SetVoteInComment(RequestVoteDTO model)
        {
            try
            {
                // Fetch existing CommentVote for the given BlogId and UserId
                var existingVote = await _context.CommentVote.FirstOrDefaultAsync(v => v.CommentId == model.CommentId && v.UserId == model.UserId);

                // If the existing vote doesn't exist, create a new one
                if (existingVote == null)
                {
                    existingVote = new CommentVote
                    {
                        CommentId = model.CommentId,
                        UserId = model.UserId,
                        CreatedBy = new Guid(model.UserId),
                        CreatedTime = DateTime.Now,
                    };
                    _context.CommentVote.Add(existingVote);
                }
                else
                {
                    var oldUpVote = existingVote.UpVote;
                    var oldDownVote = existingVote.DownVote;
                    if (oldUpVote != null || oldDownVote != null)
                    {
                        existingVote.OldVote = oldUpVote != null ? oldUpVote : oldDownVote;
                    }
                }

                // Check the VoteType and update the CommentVote accordingly
                if (model.VoteType) // Upvote
                {
                    existingVote.UpVote = existingVote.UpVote == null ? 1 : null;
                    existingVote.DownVote = null;
                    existingVote.ModifiedBy = new Guid(model.UserId);
                    existingVote.LastModifiedTime = DateTime.Now;
                    existingVote.IsDeleted = false;
                    existingVote.DeletedBy = null;
                }
                else // Downvote
                {
                    existingVote.DownVote = existingVote.DownVote == null ? 1 : null;
                    existingVote.UpVote = null;
                    existingVote.ModifiedBy = new Guid(model.UserId);
                    existingVote.LastModifiedTime = DateTime.Now;
                    existingVote.IsDeleted = false;
                    existingVote.DeletedBy = null;
                }

                await _context.SaveChangesAsync();

                // Get current vote status
                var upVote = existingVote.UpVote;
                var downVote = existingVote.DownVote;
                if (upVote == null && downVote == null)
                {
                    existingVote.IsDeleted = true;
                    existingVote.DeletedBy = new Guid(model.UserId);
                    existingVote.DeletedTime = DateTime.Now;
                    await _context.SaveChangesAsync();
                }

                var delete = existingVote.IsDeleted;

                // popularity count
                var upVoteCounts = await _context.CommentVote.CountAsync(v => v.CommentId == model.CommentId && v.UpVote == 1);
                var downVoteCounts = await _context.CommentVote.CountAsync(v => v.CommentId == model.CommentId && v.DownVote == 1);
                var totalComments = 0; // Where the comment's have not comments so it is default value is 0 // await _context.Comment.CountAsync(c => c.BlogId = model.blogId && !c.IsDeleted);

                // Calculate by popularity for comment
                var pularity = (upVoteCounts * 2) + (downVoteCounts * -1) + (totalComments * 1);

                // Update the comment's popularity in the database
                var comments = await _context.Comment.FindAsync(model.CommentId);
                comments.PopularComments = pularity;
                int changes = await _context.SaveChangesAsync();
                if (changes <= 0) {
                    throw new Exception("Database not updated.");
                }
                return new ResponseDTO
                {
                    Status = true,
                    Message = $"Vote success Up-Vote Popularity: {pularity}"
                };
            }
            catch
            {
                return new ResponseDTO
                {
                    Status = false,
                    Message = "Sorry, something went wrong on our end. Please try again later."
                };
            }
        }
    }
}
