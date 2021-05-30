using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlogApi.Core;
using BlogApi.Core.Models;
using BlogApi.Core.Services;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _unitOfWork.Users.GetAllAsync();
        }
        public async Task<User> GetUserById(int id)
        {
            return await _unitOfWork.Users.GetByIdAsync(id);
        }
        public async Task<User> CreateUser(User newUser)
        {
            await _unitOfWork.Users.AddAsync(newUser);
            _unitOfWork.CommitAsync();
            return newUser;
        }
        public void UpdateUser(User userToBeUpdated, User user)
        {
            userToBeUpdated.Username = user.Username;
            _unitOfWork.CommitAsync();
        }
        public void DeleteUser(User user)
        {
            _unitOfWork.Users.Remove(user);
            _unitOfWork.CommitAsync();
        }
    }
}
