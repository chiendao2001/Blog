using System;
using AutoMapper;
using BlogApi.Api.Resources;
using BlogApi.Core.Models;

namespace BlogApi.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<Blog, BlogResource>();
            CreateMap<Comment, CommentResource>();
            CreateMap<User, UserResource>();

            // Resource to Domain
            CreateMap<BlogResource, Blog>();
            CreateMap<CommentResource, Comment>();
            CreateMap<UserResource, User>();
        }
    }
}
