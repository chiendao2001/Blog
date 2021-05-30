using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlogApi.Core;
using BlogApi.Core.Models;
using BlogApi.Core.Services;

namespace Services
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Comment> GetCommentById(int id)
        {
            return await _unitOfWork.Comments.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Comment>> GetAllComments()
        {
            return await _unitOfWork.Comments.GetAllAsync();
        }

        public async Task<Comment> CreateComment(Comment blog)
        {
            await _unitOfWork.Comments.AddAsync(blog);
             _unitOfWork.CommitAsync();
            return blog;
        }

        public void DeleteComment(Comment comment)
        {
            _unitOfWork.Comments.Remove(comment);
            _unitOfWork.CommitAsync();
        }

        public void UpdateComment(Comment commentToBeUpdated, Comment comment)
        {
            commentToBeUpdated.Title = comment.Title;
            commentToBeUpdated.Content = comment.Content;
            commentToBeUpdated.UserId = comment.UserId;
            _unitOfWork.CommitAsync();
        }
    }
}
