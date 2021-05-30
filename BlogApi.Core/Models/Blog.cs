using System;
using System.Collections.Generic;

namespace BlogApi.Core.Models
{
    public class Blog
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public User User { get; set; }
    }
}
