using BisleriumBlog.Application.Common.Interface;
using BisleriumBlog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using BisleriumBlog.Infrastructure.Data;
using BisleriumBlog.Application.DTOs.BlogDTOs;
using System.Data;

namespace BisleriumBlog.Infrastructure.Services
{
    public class BlogServices : IBlog
    {
        private readonly AppDbContext _context;

        public BlogServices(AppDbContext context)
        {
            _context = context;
        }

        // Post the blog
        public async Task<ResponseBlog> BlogPost(Application.DTOs.BlogDTOs.BlogRequestDTO model)
        {
            try
            {
                var blog = new Blog
                {
                    Title = model.Title,
                    Content = model.Content,
                    ImageUrl = model.ImageUrl,
                    UserId = model.UserId,
                    CreatedTime = DateTime.Now,
                    CreatedBy = Guid.NewGuid(),
                    IsDeleted = false
                };

                _context.Blogs.Add(blog);
                await _context.SaveChangesAsync();

                var allBlogs = await _context.Blogs
                                              .Where(blog => !blog.IsDeleted)
                                              .ToListAsync();

                return new ResponseBlog
                {
                    Status = true,
                    Message = "Blog post created successfully!",
                    Data = allBlogs // Returning all blogs
                };
            }
            catch (Exception ex)
            {
                return new ResponseBlog
                {
                    Status = false,
                    Message = $"Failed to create blog post: {ex.Message}. Inner exception: {ex.InnerException?.Message}",
                    Data = null
                };
            }
        }

        // Get all blog with Peginated
        public async Task<PeginatedResponseBlogDTOs> GetBlogs(int pageNumber, int pageSize)
        {
            try
            {
                var totalBlogs = await _context.Blogs.Where(blog => !blog.IsDeleted).CountAsync();
                var totalPages = (int)Math.Ceiling((double)totalBlogs / pageSize);

                var blogs = await _context.Blogs
                                          .Where(blog => !blog.IsDeleted)
                                          .OrderByDescending(blog => blog.CreatedTime)
                                          .Skip((pageNumber - 1) * pageSize)
                                          .Take(pageSize)
                                          .ToListAsync();

                return new PeginatedResponseBlogDTOs
                {
                    Status = true,
                    Message = "Blogs retrieved successfully!",
                    Data = blogs,
                    TotalPages = totalPages,
                    CurrentPage = pageNumber
                };
            }
            catch (Exception ex)
            {
                return new PeginatedResponseBlogDTOs
                {
                    Status = false,
                    Message = $"Failed to retrieve blogs: {ex.Message}",
                    Data = null
                };
            }
        }

        // Delete
        public async Task<ResponseBlog> DeleteBlogPost(int blogId)
        {
            try
            {
                var blog = await _context.Blogs.FindAsync(blogId);

                if (blog == null)
                {
                    return new ResponseBlog
                    {
                        Status = false,
                        Message = "Blog post not found!",
                        Data = null
                    };
                }

                blog.IsDeleted = true;
                blog.DeletedTime = DateTime.Now;
                blog.DeletedBy = Guid.NewGuid();

                await _context.SaveChangesAsync();

                var allBlogs = await _context.Blogs
                                              .Where(b => !b.IsDeleted)
                                              .ToListAsync();

                return new ResponseBlog
                {
                    Status = true,
                    Message = "Blog is successfully deleted!",
                    Data = allBlogs // Returning all undeleted blogs
                };
            }
            catch (Exception ex)
            {
                return new ResponseBlog
                {
                    Status = false,
                    Message = $"Failed to delete blog post: {ex.Message}. Inner exception: {ex.InnerException?.Message}",
                    Data = null
                };
            }
        }

        // Update 
        public async Task<ResponseBlog> UpdateBlog(int blogId, UpdateBlog model)
        {
            try
            {
                var blog = await _context.Blogs.FindAsync(blogId);

                if (blog == null)
                {
                    return new ResponseBlog
                    {
                        Status = false,
                        Message = "Blog is not found!",
                        Data = null
                    };
                }

                blog.Content = model.Content;
                blog.Title = model.Title;
                blog.LastModifiedTime = DateTime.Now;
                blog.ModifiedBy = Guid.NewGuid();

                await _context.SaveChangesAsync();

                var allBlogs = await _context.Blogs
                                              .Where(b => !b.IsDeleted)
                                              .ToListAsync();

                return new ResponseBlog
                {
                    Status = true,
                    Message = "Blog is successfully Updated!",
                    Data = allBlogs // Returning all undeleted blogs
                };
            }
            catch (Exception ex)
            {
                return new ResponseBlog
                {
                    Status = false,
                    Message = $"Failed to update blog post: {ex.Message}. Inner exception: {ex.InnerException?.Message}",
                    Data = null
                };
            }
        }
    }
}
