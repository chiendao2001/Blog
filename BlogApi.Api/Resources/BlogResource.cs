using System;
using System.ComponentModel.DataAnnotations;

namespace BlogApi.Api.Resources
{
    public class BlogResource
    {
        [Required]
        public int Id { get; set; }

        //[Required]
        public int UserId { get; set; }

        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public UserResource User { get; set; }
    }
}
