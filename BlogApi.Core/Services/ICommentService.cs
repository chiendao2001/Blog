using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlogApi.Core.Models;

namespace BlogApi.Core.Services
{
    public interface ICommentService
    {
        Task<Comment> GetCommentById(int id);
        Task<IEnumerable<Comment>> GetAllComments();
        Task<Comment> CreateComment(Comment newComment);
        void UpdateComment(Comment commentToBeUpdated, Comment comment);
        void DeleteComment(Comment comment);
    }
}
