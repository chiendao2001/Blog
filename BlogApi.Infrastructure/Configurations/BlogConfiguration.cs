using System;
using BlogApi.Core.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogApi.Infrastructure.Configurations
{
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder
                .HasKey(blog => blog.Id);

            builder
                .HasMany(blog => blog.Comments);

            builder
                .HasOne(blog => blog.User)
                .WithMany(user => user.Blogs)
                .HasForeignKey(blog => blog.UserId);
            
        }
    }
}
