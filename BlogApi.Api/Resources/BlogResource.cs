using System;
namespace BlogApi.Api.Resources
{
    public class BlogResource
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public UserResource User { get; set; }
    }
}
