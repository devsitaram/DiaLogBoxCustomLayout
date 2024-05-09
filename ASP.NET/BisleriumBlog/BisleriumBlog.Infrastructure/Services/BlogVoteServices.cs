using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BisleriumBlog.Application.DTOs.BlogVoteDTOs;
using BisleriumBlog.Application.DTOs.CommentVoteDTOs;
using BisleriumBlog.Application.DTOs.UserDTOs;
using BisleriumBlog.Application.Interface.Repository;
using BisleriumBlog.Domain.Entities;
using BisleriumBlog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BisleriumBlog.Infrastructure.Services
{
    public class BlogVoteServices: IBlogVote
    {
        private readonly AppDbContext _context;

        public BlogVoteServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseCommentVoteDTO> GetNumberOfBlogVote(int blogId)
        {
            try
            {
                // Get total number of up-Vote and Down-Vote from CommentVote table by CommentId
                var upVoteCount = await _context.BlogVote.CountAsync(v => v.BlogId == blogId && v.UpVote == 1);
                var downVoteCount = await _context.BlogVote.CountAsync(v => v.BlogId == blogId && v.DownVote == 1);

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

        public async Task<ResponseDTO> SetVoteInBlog(RequestBlogVoteDTO model)
        {
            try
            {
                // Fetch existing CommentVote for the given BlogId and UserId
                var existingVote = await _context.BlogVote.FirstOrDefaultAsync(v => v.BlogId == model.BlogId && v.UserId == model.UserId);

                // If the existing vote doesn't exist, create a new one
                if (existingVote == null)
                {
                    existingVote = new BlogVote
                    {
                        BlogId = model.BlogId,
                        UserId = model.UserId,
                        CreatedBy = new Guid(model.UserId),
                        CreatedTime = DateTime.Now,
                    };
                    _context.BlogVote.Add(existingVote);
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
                var upVoteCounts = await _context.BlogVote.CountAsync(v => v.BlogId == model.BlogId && v.UpVote == 1);
                var downVoteCounts = await _context.BlogVote.CountAsync(v => v.BlogId == model.BlogId && v.DownVote == 1);
                var totalComments = await _context.Blogs.CountAsync(c => c.BlogId == model.BlogId && !c.IsDeleted);

                // Calculate by popularity for comment
                var pularity = (upVoteCounts * 2) + (downVoteCounts * -1) + (totalComments * 1);

                // Update the comment's popularity in the database
                var comments = await _context.Blogs.FindAsync(model.BlogId);
                comments.PopularBlog = pularity;
                await _context.SaveChangesAsync();

                return new ResponseDTO
                {
                    Status = true,
                    Message = $"Vote success Up-Vote: {upVoteCounts}, Down-Vote: {downVoteCounts}, totalComments: {downVoteCounts}, Popularity: {pularity}"
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
