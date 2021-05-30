using System;
namespace BlogApi.Api.Resources
{
    public class CommentResource
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Content { get; set; }

        public string Title { get; set; }

        public int BlogId { get; set; }

        public UserResource User { get; set; }
        public BlogResource Blog { get; set; }
    }
}
