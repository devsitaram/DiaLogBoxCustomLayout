﻿using BisleriumBlog.Application.Common.Interface;
using BisleriumBlog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using BisleriumBlog.Infrastructure.Data;
using BisleriumBlog.Application.DTOs.BlogDTOs;
using System.Data;
using BisleriumBlog.Application.DTOs.CommentDTOs;
using BisleriumBlog.Application.DTOs.UserDTOs;
using BisleriumBlog.Application.DTOs.DashboardDTOs;

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
        public async Task<ResponseBlog> BlogPost(BlogRequestDTO model, string imageUrl)
        {
            try
            {
                var blog = new Blog
                {
                    Title = model.Title,
                    Content = model.Content,
                    ImageUrl = imageUrl,
                    UserId = model.UserId,
                    CreatedTime = DateTime.Now,
                    CreatedBy = Guid.NewGuid(),
                    IsDeleted = false
                };

                // Data save in database
                _context.Blogs.Add(blog);
                await _context.SaveChangesAsync();

                //var allBlogs = await _context.Blogs
                //                              .Where(blog => !blog.IsDeleted)
                //                              .ToListAsync();

                return new ResponseBlog
                {
                    Status = true,
                    Message = "Blog successfully created.",
                };
            }
            catch
            {
                return new ResponseBlog
                {
                    Status = false,
                    Message = "Sorry, something went wrong on our end. Please try again later."
                };
            }
        }

        // Delete Blog
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
                        Message = "Blog post not found!"
                    };
                }

                // update data
                blog.IsDeleted = true;
                blog.DeletedTime = DateTime.Now;
                blog.DeletedBy = Guid.NewGuid();

                await _context.SaveChangesAsync(); // saved in database

                //var allBlogs = await _context.Blogs
                //                              .Where(b => !b.IsDeleted)
                //                              .ToListAsync();

                return new ResponseBlog
                {
                    Status = true,
                    Message = "Blog is successfully deleted!",
                };
            }
            catch
            {
                return new ResponseBlog
                {
                    Status = false,
                    Message = "Sorry, something went wrong on our end. Please try again later."
                };
            }
        }

        // Update Blog
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
                        Message = "Blog is not found!"
                    };
                }

                // old content
                var oldBlogContent = blog.Content;

                blog.Title = model.Title;
                blog.Content = model.Content;
                blog.OldContent = oldBlogContent;
                blog.LastModifiedTime = DateTime.Now;
                blog.ModifiedBy = Guid.NewGuid();

                await _context.SaveChangesAsync();

                //var allBlogs = await _context.Blogs
                //                              .Where(b => !b.IsDeleted)
                //                              .ToListAsync();

                return new ResponseBlog
                {
                    Status = true,
                    Message = "Blog is successfully Updated!"
                };
            }
            catch
            {
                return new ResponseBlog
                {
                    Status = false,
                    Message = "Sorry, something went wrong on our end. Please try again later.",
                };
            }
        }

        // Get all blog with peginated
        public async Task<PeginatedResponseBlogDTOs> GetBlogs(int pageNumber, int pageSize)
        {
            try
            {
                var totalBlogs = await _context.Blogs.Where(blog => !blog.IsDeleted).CountAsync();
                var totalPages = (int)Math.Ceiling((double)totalBlogs / pageSize);

                var pagedBlogs = await _context.Blogs
                    .Where(blog => !blog.IsDeleted)
                    .OrderByDescending(blog => blog.CreatedTime)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .Select(blog => new BlogDTO
                    {
                        BlogId = blog.BlogId,
                        Title = blog.Title,
                        Content = blog.Content,
                        ImageUrl = blog.ImageUrl,
                        PopularBlog = blog.PopularBlog,
                        CreatedTime = blog.CreatedTime,
                        LastModifiedTime = blog.LastModifiedTime,
                        CreatedBy = blog.CreatedBy,
                        ModifiedBy = blog.ModifiedBy,
                        CommentDTOs = _context.Comment
                            .Where(comment => comment.BlogId == blog.BlogId && !comment.IsDeleted)
                            .Select(comment => new CommentDTO
                            {
                                Id = comment.Id,
                                Comments = comment.Comments,
                                PopularComments = comment.PopularComments,
                                CreatedTime = comment.CreatedTime,
                                UserDTO = _context.Users
                                    .Where(user => comment.UserId == user.Id)
                                    .Select(user => new UserDTO
                                    {
                                        Id = user.Id,
                                        Username = user.UserName,
                                        Email = user.Email,
                                        PhoneNumber = user.PhoneNumber,
                                        Role = "Blogger"
                                    }).FirstOrDefault()
                            })
                            .ToList(),
                        UserDTO = _context.Users
                        .Where(user => blog.UserId == user.Id)
                        .Select(user => new UserDTO
                        {
                            Id = user.Id,
                            Username = user.UserName,
                            Email = user.Email,
                            PhoneNumber = user.PhoneNumber,
                            Role = "Blogger"

                        }).FirstOrDefault()
                    })
                    .ToListAsync();

                return new PeginatedResponseBlogDTOs
                {
                    Status = true,
                    Message = "Blogs retrieved successfully!",
                    BlogComment = pagedBlogs,
                    TotalPages = totalPages,
                    CurrentPage = pageNumber
                };
            }
            catch
            {
                return new PeginatedResponseBlogDTOs
                {
                    Status = false,
                    Message = "Sorry, something went wrong on our end. Please try again later."
                };
            }
        }

        // Get All Blog By User Id
        public async Task<PeginatedResponseBlogDTOs> GetBlogsByUserId(string userId)
        {
            try
            {
                var pagedBlogs = await _context.Blogs
                    .Where(blog => blog.UserId == userId && !blog.IsDeleted)
                    .OrderByDescending(blog => blog.CreatedTime)
                    .Select(blog => new BlogDTO
                    {
                        BlogId = blog.BlogId,
                        Title = blog.Title,
                        Content = blog.Content,
                        ImageUrl = blog.ImageUrl,
                        PopularBlog = blog.PopularBlog,
                        CreatedTime = blog.CreatedTime,
                        LastModifiedTime = blog.LastModifiedTime,
                        CreatedBy = blog.CreatedBy,
                        ModifiedBy = blog.ModifiedBy,
                        CommentDTOs = _context.Comment
                            .Where(comment => comment.BlogId == blog.BlogId && !comment.IsDeleted)
                            .Select(comment => new CommentDTO
                            {
                                Id = comment.Id,
                                Comments = comment.Comments,
                                PopularComments = comment.PopularComments,
                                CreatedTime = comment.CreatedTime,
                                UserDTO = _context.Users
                                    .Where(user => comment.UserId == user.Id)
                                    .Select(user => new UserDTO
                                    {
                                        Id = user.Id,
                                        Username = user.UserName,
                                        Email = user.Email,
                                        PhoneNumber = user.PhoneNumber,
                                        Role = "Blogger"
                                    }).FirstOrDefault()
                            })
                            .ToList(),
                        UserDTO = _context.Users
                        .Where(user => blog.UserId == user.Id)
                        .Select(user => new UserDTO
                        {
                            Id = user.Id,
                            Username = user.UserName,
                            Email = user.Email,
                            PhoneNumber = user.PhoneNumber,
                            Role = "Blogger"

                        }).FirstOrDefault()
                    })
                    .ToListAsync();

                return new PeginatedResponseBlogDTOs
                {
                    Status = true,
                    Message = "Blogs retrieved successfully!",
                    BlogComment = pagedBlogs,
                };
            }
            catch
            {
                return new PeginatedResponseBlogDTOs
                {
                    Status = false,
                    Message = "Sorry, something went wrong on our end. Please try again later."
                };
            }
        }

        // Sorting
        public async Task<PeginatedResponseBlogDTOs> GetBlogsBySorting(int pageNumber, int pageSize, string sortBy)
        {
            try
            {

                var query = _context.Blogs.Where(blog => !blog.IsDeleted);

                // Sorting
                switch (sortBy.ToLower())
                {
                    // Order by random
                    case "random":
                        query = query.OrderByDescending(_ => Guid.NewGuid());
                        break;

                    // Order by popularity
                    case "popularity":
                        query = query.OrderByDescending(blog => blog.PopularBlog);
                        break;

                    // Order by recency
                    case "recency":
                        query = query.OrderByDescending(blog => blog.CreatedTime);
                        break;

                    // Default sorting
                    default:
                        query = query.OrderByDescending(blog => blog.CreatedTime);
                        break;
                }

                var totalBlogs = await query.CountAsync();
                var totalPages = (int)Math.Ceiling((double)totalBlogs / pageSize);

                var pagedBlogs = await query
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .Select(blog => new BlogDTO
                    {
                        BlogId = blog.BlogId,
                        Title = blog.Title,
                        Content = blog.Content,
                        ImageUrl = blog.ImageUrl,
                        PopularBlog = blog.PopularBlog,
                        CreatedTime = blog.CreatedTime,
                        LastModifiedTime = blog.LastModifiedTime,
                        CreatedBy = blog.CreatedBy,
                        ModifiedBy = blog.ModifiedBy,
                        CommentDTOs = _context.Comment
                            .Where(comment => comment.BlogId == blog.BlogId && !comment.IsDeleted)
                            .Select(comment => new CommentDTO
                            {
                                Id = comment.Id,
                                Comments = comment.Comments,
                                PopularComments = comment.PopularComments,
                                CreatedTime = comment.CreatedTime,
                                UserDTO = _context.Users
                                    .Where(user => comment.UserId == user.Id)
                                    .Select(user => new UserDTO
                                    {
                                        Id = user.Id,
                                        Username = user.UserName,
                                        Email = user.Email,
                                        PhoneNumber = user.PhoneNumber,
                                        Role = "Blogger"
                                    }).FirstOrDefault()
                            })
                            .ToList(),
                        UserDTO = _context.Users
                            .Where(user => blog.UserId == user.Id)
                            .Select(user => new UserDTO
                            {
                                Id = user.Id,
                                Username = user.UserName,
                                Email = user.Email,
                                PhoneNumber = user.PhoneNumber,
                                Role = "Blogger"
                            }).FirstOrDefault()
                    })
                    .ToListAsync();

                return new PeginatedResponseBlogDTOs
                {
                    Status = true,
                    Message = "Blogs retrieved successfully!",
                    BlogComment = pagedBlogs,
                    TotalPages = totalPages,
                    CurrentPage = pageNumber
                };
            }
            catch (Exception ex)
            {
                // Log exception for debugging purposes
                Console.WriteLine(ex.Message);

                return new PeginatedResponseBlogDTOs
                {
                    Status = false,
                    Message = "Sorry, something went wrong on our end. Please try again later."
                };
            }
        }

        // 
        public async Task<DashboardResponseDTOs> GetDashboardActivityStats(int? year, int? month)
        {
            try
            {
                // Get all-time counts
                var allTimeStats = new DashboardStatsDTO
                {
                    TotalBlogPosts = await _context.Blogs.CountAsync(blog => !blog.IsDeleted),
                    TotalComments = await _context.Comment.CountAsync(comment => !comment.IsDeleted),
                    TotalUpvotes = await _context.BlogVote.SumAsync(blog => blog.UpVote),
                    TotalDownvotes = await _context.BlogVote.SumAsync(blog => blog.DownVote)
                };

                // Get month-specific counts
                DateTime firstDayOfMonth;
                if (year.HasValue && month.HasValue)
                {
                    firstDayOfMonth = new DateTime(year.Value, month.Value, 1);
                }
                else
                {
                    var today = DateTime.Today;
                    firstDayOfMonth = new DateTime(today.Year, today.Month, 1);
                }

                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

                var monthStats = new DashboardStatsDTO
                {
                    TotalBlogPosts = await _context.Blogs
                        .CountAsync(blog => !blog.IsDeleted && blog.CreatedTime >= firstDayOfMonth && blog.CreatedTime <= lastDayOfMonth),
                    TotalComments = await _context.Comment
                        .CountAsync(comment => !comment.IsDeleted && comment.CreatedTime >= firstDayOfMonth && comment.CreatedTime <= lastDayOfMonth),
                    TotalUpvotes = await _context.BlogVote
                        .Where(blog => blog.CreatedTime >= firstDayOfMonth && blog.CreatedTime <= lastDayOfMonth)
                        .SumAsync(blog => blog.UpVote),
                    TotalDownvotes = await _context.BlogVote
                        .Where(blog => blog.CreatedTime >= firstDayOfMonth && blog.CreatedTime <= lastDayOfMonth)
                        .SumAsync(blog => blog.DownVote)
                };

                return new DashboardResponseDTOs
                {
                    Status = false,
                    Message = "Get Activity successful",
                    AllTimeStats = allTimeStats,
                    MonthStats = monthStats
                };
            }
            catch
            {
                return new DashboardResponseDTOs
                {
                    Status = false,
                    Message = "Sorry, something went wrong on our end. Please try again later."
                };
            }
        }
    }
}