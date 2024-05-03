using BisleriumBlog.Application.DTOs.CommentDTOs;
using BisleriumBlog.Application.Interface.Repository;
using BisleriumBlog.Domain.Entities;
using BisleriumBlog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BisleriumBlog.Infrastructure.Services
{
    public class CommentServices : IComment
    {
        private readonly AppDbContext _context;

        public CommentServices(AppDbContext context)
        {
            _context = context;
        }

        // Post Comment
        public async Task<ResponseComments> PostComment(RequestCommentDTO model)
        {
            try
            {
                var comment = new Comment
                {
                    Comments = model.Content,
                    BlogId = model.BlogId,
                    UserId = model.UserId,
                    CreatedTime = DateTime.Now,
                    CreatedBy = Guid.NewGuid(),
                    IsDeleted = false
                };

                _context.Comment.Add(comment);
                await _context.SaveChangesAsync();

                var allComments = await _context.Comment.Where(c => c.BlogId == model.BlogId && !c.IsDeleted).ToListAsync();

                return new ResponseComments
                {
                    Status = true,
                    Message = "Comment posted successfully!",
                    Data = allComments // Returning all comments for the specified blog
                };
            }
            catch
            {
                return new ResponseComments
                {
                    Status = false,
                    Message = "Sorry, something went wrong on our end. Please try again later.",
                    Data = null
                };
            }
        }

        // Get all comments by blog id
        public async Task<ResponseComments> GetComment(int Id)
        {
            try
            {
                if (Id <= 0)
                {
                    return new ResponseComments
                    {
                        Status = false,
                        Message = "Invalid Id",
                        Data = null
                    };
                }

                int blogId = Convert.ToInt32(Id);
                // Query to get all comments for the specified BlogId
                var allComments = await _context.Comment
                                                 .Where(comment => comment.BlogId == blogId && !comment.IsDeleted)
                                                 .ToListAsync();

                if (allComments.Count == 0)
                {
                    return new ResponseComments
                    {
                        Status = true,
                        Message = "No comments found",
                        Data = allComments
                    };
                }

                return new ResponseComments
                {
                    Status = true,
                    Message = "Success",
                    Data = allComments
                };

            }
            catch
            {
                return new ResponseComments
                {
                    Status = false,
                    Message = $"Sorry, something went wrong on our end. Please try again later. {Id}",
                    Data = null
                };
            }
        }

        /*public async Task<ResponseComments> GetComment(int Id)
        {
            try
            {
                var allComments = await _context.Comment
                                         .Where(comment => comment.BlogId == Id && !comment.IsDeleted)
                                         .ToListAsync();

                if (allComments.Count == 0)
                {
                    return new ResponseComments
                    {
                        Status = true,
                        Message = "Not Comment",
                        Data = allComments
                    };
                }

                return new ResponseComments
                {
                    Status = true,
                    Message = "Success",
                    Data = allComments
                };
            }
            catch
            {
                return new ResponseComments
                {
                    Status = false,
                    Message = $"Sorry, something went wrong on our end. Please try again later. {Id}",
                    Data = null
                };
            }
        }*/
    }
}

