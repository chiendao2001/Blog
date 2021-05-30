using System;
using BlogApi.Core.Models;
using BlogApi.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Infrastructure
{
    public class BlogApiDbContext : DbContext
    {
        public BlogApiDbContext(DbContextOptions<BlogApiDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new BlogConfiguration());

            builder
                .ApplyConfiguration(new CommentConfiguration());

            builder
                .ApplyConfiguration(new UserConfiguration());
        }

        public DbSet<Comment> Blogs { get; set; }
        public DbSet<User> Comments { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
