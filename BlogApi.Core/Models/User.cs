using System.Collections.Generic;

namespace BlogApi.Core.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public ICollection<Blog> Blogs { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
