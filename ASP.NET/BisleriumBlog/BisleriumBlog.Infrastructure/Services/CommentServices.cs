using BisleriumBlog.Application.DTOs.BlogDTOs;
using BisleriumBlog.Application.DTOs.CommentDTOs;
using BisleriumBlog.Application.DTOs.CommentDTOs.Update;
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
                };
            }
        }

        public async Task<ResponseComments> DeleteComment(int commentId)
        {
            try
            {
                var commment = await _context.Comment.FindAsync(commentId);

                if (commment == null)
                {
                    return new ResponseComments
                    {
                        Status = false,
                        Message = "Comment is not found!",
                    };
                }

                commment.IsDeleted = true;
                commment.DeletedTime = DateTime.Now;
                commment.DeletedBy = Guid.NewGuid();

                await _context.SaveChangesAsync();

                var allBlogs = await _context.Blogs
                                              .Where(b => !b.IsDeleted)
                                              .ToListAsync();

                return new ResponseComments
                {
                    Status = true,
                    Message = "Comment is successfully Deleted!",
                };
            }
            catch (Exception ex)
            {
                return new ResponseComments
                {
                    Status = false,
                    Message = $"Sorry, something went wrong on our end. Please try again later. {ex.Message}",
                };
            }
        }

        public async Task<ResponseComments> UpdateComment(int commentId, CommentUpdateRequest model)
        {
            try
            {
                var commment = await _context.Comment.FindAsync(commentId);

                if (commment == null)
                {
                    return new ResponseComments
                    {
                        Status = false,
                        Message = "Comment is not found!",
                    };
                }

                // get pewvious comment
                var oldComment = commment.Comments;

                commment.Comments = model.Comments;
                commment.OldComments = oldComment;
                commment.LastModifiedTime = DateTime.Now;
                commment.ModifiedBy = Guid.NewGuid();

                await _context.SaveChangesAsync();

                //var allBlogs = await _context.Comment
                //                              .Where(b => !b.IsDeleted)
                //                              .ToListAsync();

                return new ResponseComments
                {
                    Status = true,
                    Message = "Comment is successfully updated!",
                    Data = commment
                };
            }
            catch (Exception ex)
            {
                return new ResponseComments
                {
                    Status = false,
                    Message = $"Sorry, something went wrong on our end. Please try again later. {ex.Message}",
                };
            }
        }
    }
}

