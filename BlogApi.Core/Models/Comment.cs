using System;
namespace BlogApi.Core.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Content{ get; set; }

        public string Title { get; set; }

        public int BlogId { get; set; }

        public Blog Blog { get; set; }

        public User User { get; set; }
    }
}
